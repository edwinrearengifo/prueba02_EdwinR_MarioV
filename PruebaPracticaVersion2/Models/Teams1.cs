using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace PruebaPracticaVersion2.Models
{
    public class Teams1
    {
        [Required]
        [Display(Name = "Id equipo")]

        public int id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Id Liga")]

        public int league { get; set; }

        [Required]
        [Display(Name = "Temporada")]

        public int season { get; set; }

        [Required]
        [Display(Name = "País")]

        public string country { get; set; }

        [Required]
        [Display(Name = "Código")]

        public string code { get; set; }

        [Required]
        [Display(Name = "Evento")]

        public int venue { get; set; }
        [Required]
        [Display(Name = "Búsqueda")]

        public string search { get; set; }
    }
}