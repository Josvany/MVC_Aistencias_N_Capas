using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Entity
{
    public class TasaCambioEntity
    {
        [DataType (DataType.Date)]
        public DateTime Fecha { get; set; }
        public string Valor { get; set; }
    }
}
