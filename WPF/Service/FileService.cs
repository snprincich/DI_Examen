using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WPF.Interface;

namespace WPF.Service
{
    public class FileService<T> : IFileService<T> where T : class
    {
        public IEnumerable<T> Load(string filePath)
        {
            if (!File.Exists(filePath)) return new List<T>();
            var content = File.ReadAllText(filePath);
            if (content.Contains('['))
            {
                return JsonSerializer.Deserialize<List<T>>(content) ?? new List<T>();
            }
            else
            {
                T objeto = JsonSerializer.Deserialize<T>(content) ?? default;
                List<T> list = new List<T>();
                list.Add(objeto);
                return list.AsEnumerable();
            }

        }

        public void Save(string filePath, IEnumerable<T> data)
        {
            var content = JsonSerializer.Serialize(data);
            File.WriteAllText(filePath, content);
        }

        public void Save(string filePath, T data)
        {
            var content = JsonSerializer.Serialize(data);
            File.WriteAllText(filePath, content);
        }
    }
}
