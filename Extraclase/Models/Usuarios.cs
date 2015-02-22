using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Extraclase.Models
{
    public class Usuarios
    {
        public int ID { get; set; }

        [Display(Name = "Usuario")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Administrador?")]
        public string Admin { get; set; }
    }
}