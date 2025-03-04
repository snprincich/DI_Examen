using WPF.DTOs;


//EL MODEL CONTIENE SOLO INFORMACION QUE NECESITAMOS EN WPF
//PODEMOS TENER VARIOS MODEL DEL MISMO DTO SI QUEREMOS MOSTRAR DIFERENTE INFO EN DIFERENTES SITIOS
namespace WPF.Models
{
    public class FerrariModel
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AnoSalida { get; set; }
        public string Cv { get; set; }
        public string PrecioEstimado { get; set; }
        public string PujaInicial { get; set; }

        public static FerrariModel CreateModelFromDTO(FerrariDTO ferrari)
        {
            return new FerrariModel
            {
                Id = ferrari.Id,
                Image = ferrari.Image,
                Name = ferrari.Name,
                Description = ferrari.Description,
                AnoSalida = ferrari.AnoSalida,
                Cv = ferrari.Cv,
                PrecioEstimado = ferrari.PrecioEstimado,
                PujaInicial = ferrari.PujaInicial
            };
        }
    }
}

