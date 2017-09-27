using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Pago_Entity
    {
        public Guid Pag_Int_Id { get; set; }

        [Required(ErrorMessage = "Ingresar forma de Pago")]
        [Display(Name = "Forma de Pago")]
        public string Pag_Name { get; set; }

    }
}
