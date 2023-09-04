using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace PruebaPracticaVersion2.Models
{
    public class Countries1
    {
        [Required]
        [Display(Name = "Nombre")]

        public string name { get; set; }

        [Required]
        [Display(Name = "Código")]
        public string code { get; set; }

        [Required]
        [Display(Name = "Bandera")]

        public string flag { get; set; }
    }
}