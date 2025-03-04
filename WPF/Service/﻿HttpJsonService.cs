using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using WPF.DTOs;
using WPF.Interface;
using WPF_UI.Constants;

using WPF_UI.Services;

namespace WPF.Services
{
    internal class HttpJsonService<T> : IHttpJsonProvider<T> where T : class
    {
        private Credenciales _credenciales = App.Current.Services.GetService<Credenciales>();
        
        
        public async Task<IEnumerable<T?>> GetAsync(string path)
        {
            try
            {
                using HttpClient httpClient = new HttpClient();
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_credenciales.Token}");
                    HttpResponseMessage request = await httpClient.GetAsync($"{ConstantesApi.BASE_URL}{path}");
                    if (request.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        await Authenticate(path, httpClient, request);
                        request = await httpClient.GetAsync($"{ConstantesApi.BASE_URL}{path}");
                    }
                    string dataRequest = await request.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<IEnumerable<T>>(dataRequest);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return default;
        }

        public async Task Authenticate(string path, HttpClient httpClient, HttpResponseMessage request)
        {
            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(_credenciales.GetCredenciales()), Encoding.UTF8, "application/json");

            HttpResponseMessage requestToken = await httpClient.PostAsync($"{ConstantesApi.BASE_URL}{ConstantesApi.LOGIN_PATH}", httpContent);

            string dataTokenRequest = await requestToken.Content.ReadAsStringAsync();
            UserDTO tokenUser = JsonSerializer.Deserialize<UserDTO>(dataTokenRequest);

            _credenciales.Token = tokenUser?.Result?.Token ?? string.Empty;
            httpClient.DefaultRequestHeaders.Remove("Authorization");
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_credenciales.Token}");


        }

        public async Task<UserDTO> LoginAsync(LoginDTO loginDTO)
        {
            try
            {
                _credenciales.SetCredenciales(loginDTO);

                using HttpClient httpClient = new HttpClient();
                {
                    HttpContent httpContent = new StringContent(JsonSerializer.Serialize(loginDTO), Encoding.UTF8, "application/json");
                    HttpResponseMessage requestToken = await httpClient.PostAsync($"{ConstantesApi.BASE_URL}{ConstantesApi.LOGIN_PATH}", httpContent);

                    string dataTokenRequest = await requestToken.Content.ReadAsStringAsync();
                    UserDTO tokenUser = JsonSerializer.Deserialize<UserDTO>(dataTokenRequest);

                    _credenciales.Token = tokenUser?.Result?.Token ?? string.Empty;
                    httpClient.DefaultRequestHeaders.Remove("Authorization");
                    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_credenciales.Token}");

                    return tokenUser;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return default;
        }

        public async Task<UserDTO> RegistroAsync(RegistroDTO registroDTO)
        {
            try
            {
                using HttpClient httpClient = new HttpClient();
                {
                    HttpContent httpContent = new StringContent(JsonSerializer.Serialize(registroDTO), Encoding.UTF8, "application/json");
                    HttpResponseMessage requestToken = await httpClient.PostAsync($"{ConstantesApi.BASE_URL}{ConstantesApi.REGISTER_PATH}", httpContent);

                    string dataTokenRequest = await requestToken.Content.ReadAsStringAsync();
                    UserDTO tokenUser = JsonSerializer.Deserialize<UserDTO>(dataTokenRequest);

                    return tokenUser;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return default;
        }



        public async Task<T?> PostAsync(string path, T data)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {

                    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_credenciales.Token}");
                    string jsonContent = JsonSerializer.Serialize(data);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PostAsync($"{ConstantesApi.BASE_URL}{path}", content);
                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        await Authenticate(path, httpClient, response);
                        response = await httpClient.PostAsync($"{ConstantesApi.BASE_URL}{path}", content);
                        if (response.IsSuccessStatusCode)
                        {
                            string responseBody = await response.Content.ReadAsStringAsync();
                            return JsonSerializer.Deserialize<T>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        }
                        else
                        {
                            Console.WriteLine("Error en la respuesta: " + response.StatusCode);
                        }
                    }
                    string dataRequest = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<T>(dataRequest);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la solicitud POST: {ex.Message}");
            }
            return default;
        }

        public async Task<T?> PatchAsync(string path, T data)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_credenciales.Token}");
                    string jsonContent = JsonSerializer.Serialize(data,
                     new JsonSerializerOptions
                     {
                         DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
                         WriteIndented = true  // Hace que el JSON sea más legible (con saltos de línea y espacios)
                     });
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    HttpResponseMessage request = await httpClient.PatchAsync($"{ConstantesApi.BASE_URL}{path}", content);

                    if (request.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        await Authenticate(path, httpClient, request);
                        request = await httpClient.PatchAsync($"{ConstantesApi.BASE_URL}{path}", content);
                        if (request.IsSuccessStatusCode)
                        {
                            string responseBody = await request.Content.ReadAsStringAsync();
                            return JsonSerializer.Deserialize<T>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        }
                        else
                        {
                            Console.WriteLine("Error en la respuesta: " + request.StatusCode);
                        }
                    }
                    string dataRequest = await request.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<T>(dataRequest);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la solicitud PATCH: {ex.Message}");
            }
            return default;
        }

        public async Task DeleteAll(string path)
        {
            using HttpClient httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(path);
            if (!response.IsSuccessStatusCode)
            {
                string errorDetails = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error:{response.StatusCode}");
                Console.WriteLine($"Detalles:{errorDetails}");

            }
        }

        public async Task<bool> Delete(string path, int id)
        {
            try
            {
            using HttpClient httpClient = new HttpClient();
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_credenciales.Token}");
                    HttpResponseMessage request = await httpClient.DeleteAsync($"{ConstantesApi.BASE_URL}{path}{id}");
                    if (request.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        await Authenticate(path, httpClient, request);
                        request = await httpClient.DeleteAsync($"{ConstantesApi.BASE_URL}{path}{id}");
                    }
                    return request.IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
    }
 }
