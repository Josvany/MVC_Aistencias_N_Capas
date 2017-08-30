using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Turnos_Entity
    {
        public int IdTuno { get; set; }
        [Required(ErrorMessage = "El turno no puede ser vacio")]
        [StringLength(75)]
        public string Turnos { get; set; }

        public DateTime TurnInit { get; set; }
        public DateTime TurnEnd { get; set; }
        public float Horas { get; set; }
        public DateTime AlmInit { get; set; }
        public DateTime AlmEnd { get; set; }

    }
}
