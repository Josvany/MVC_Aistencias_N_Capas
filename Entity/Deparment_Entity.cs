using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Deparment_Entity
    {
        public int IdDepartament { get; set; }
        [Required (ErrorMessage = "Departamento no puede ser vacio")]
        [StringLength(75)]
        public string Departament { get; set;}



    }
}
