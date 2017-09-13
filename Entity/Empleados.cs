using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Empleados
    {
        public void EmpleadoEntity()
        {
         

        }
        public int IdEmpleado { get; set; }
        [Required(ErrorMessage = "El Nombre no puede ser vacio")]
        [StringLength(75)]

        public string Nombres { get; set; }
        public bool Status { get; set; }
        [Required(ErrorMessage = "Debe seleccionar un departamento")]
        public int IdDepartament { get; set; }

        public string Departamento { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un turno")]
        public int IdTurno { get; set; }

        public string Turno { get; set; }

        [Required(ErrorMessage = "Salario no puede ser menor o igual a 0")]
        [Range(typeof(double), "4000.00", "25000.00")]
        public double Salario { get; set; }
        [Required(ErrorMessage = "Día libre no puede ser vacio")]
        public string DiaLibre { get; set; }

        


    }
}
