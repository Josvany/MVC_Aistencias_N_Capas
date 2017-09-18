using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Type_User_Entity
    {
        //public Type_User_Entity()
        //{

        //}
        public Guid Typ_Use_Int_id { get; set; }

        [Required(ErrorMessage ="Ingresar un tipo de usuario")]
        [Display(Name = "Tipo de Usuario")]
        public string Typ_Use_Name { get; set; }

    }
}
