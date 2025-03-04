﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Entity
{
    public class FerrariEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Image { get; set; }

        [MaxLength (50)]
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string AnoSalida { get; set; }

        [Required]
        public string Cv { get; set; }

        [Required]
        public string PrecioEstimado { get; set; }

        [Required]
        public string PujaInicial { get; set; }
    }
     
}

