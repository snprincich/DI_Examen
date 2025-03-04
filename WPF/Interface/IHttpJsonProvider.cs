using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WPF.DTOs;

namespace WPF.Interface
{
    public interface IHttpJsonProvider<T> where T : class
    {
        Task<IEnumerable<T?>> GetAsync(string path);
        Task Authenticate(string path, HttpClient httpClient, HttpResponseMessage request);
        Task<T?> PatchAsync(string path, T data);
        Task<T?> PostAsync(string path, T data);
        Task<UserDTO> LoginAsync(LoginDTO loginDTO);
        Task<UserDTO> RegistroAsync(RegistroDTO registroDTO);
        Task DeleteAll(string url);
        Task<bool> Delete(string path, int id);
    }
}
