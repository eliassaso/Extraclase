using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Extraclase.Models
{
    public class Temas
    {
       
            public int ID { get; set; }
            public string Materia { get; set; }
            public string Grado { get; set; }
            [Display(Name = "Tema")]
            public string Tema { get; set; }
        
    }
}