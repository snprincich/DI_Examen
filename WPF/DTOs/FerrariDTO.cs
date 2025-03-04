using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WPF.DTOs
{
    public class FerrariDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("image")]
        public string Image { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("anoSalida")]
        public string AnoSalida { get; set; }
        [JsonPropertyName("cv")]
        public string Cv { get; set; }
        [JsonPropertyName("precioEstimado")]
        public string PrecioEstimado { get; set; }
        [JsonPropertyName("pujaInicial")]
        public string PujaInicial { get; set; }
    }
}
