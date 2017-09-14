using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Rol_Entity
    {
        public Guid Rol_Int_Id { get; set; }
        [Required (ErrorMessage = "Ingresar Nombre")]
        [Display (Name = "Nombre rol")]
        public string Rol_Name { get; set; }

    }
}
