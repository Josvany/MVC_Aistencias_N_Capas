using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class User_Entity
    {
        public User_Entity()
        {
            Rol_Entity = new Rol_Entity();
        }
        public Guid User_Int_Id { get; set; }

        public Guid Use_Ing_Int_Id { get; set; }
        [Required(ErrorMessage = "Ingresar ")]
        [Display(Name = "Nombre de Usuario")]
        public string Use_Login { get; set; }
        [Display(Name = "Contraseña")]
        public string Use_Pass { get; set; }
        [Display(Name = "Estado")]
        public bool Use_Status { get; set; }
        [Display(Name = "Rol")]
        public Guid Rol_Int_Id { get; set; }

        public Rol_Entity Rol_Entity { get; set; }
    }
}
