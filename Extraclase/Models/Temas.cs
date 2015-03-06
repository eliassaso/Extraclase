using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Extraclase.Models
{
    public class Temas
    {
            /*public Temas()
            {
                this.IdList = new SelectList(new List<int>());
                this.EmployeeList = new SelectList(new List<string>() { "Sin datos" });
            }*/
            public int ID { get; set; }
            //public SelectList IdList { get; set; }

            public string Materia { get; set; }
            //public SelectList MateriaList { get; set; }

            public string Grado { get; set; }
            //public SelectList GradoList { get; set; }

            [Display(Name = "Tema")]
            public string Tema { get; set; }

            /*[DisplayName("Empleado")]
            public SelectList EmployeeList { get; set; }
            public List<int> EmployeesSelected { get; set; }*/
        
    }
}