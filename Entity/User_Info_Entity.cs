using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class User_Info_Entity
    {
        public User_Info_Entity()
        {
            Type_User_Entity = new Type_User_Entity();
            User_Entity = new User_Entity();
        }
        public Guid Use_Inf_Int_Id { get; set; }
        public Guid Typ_Use_Int_id { get; set; }

        [Required(ErrorMessage = "Nombre Obligatorio")]
        [Display(Name ="Primer Nombre")]
        public string Use_Inf_F_Name { get; set; }

        [Display(Name = "Segundo Nombre")]
        //[Required(ErrorMessage = "Segundo Nombre Obligatorio")]
        public string Use_Inf_FS_Name { get; set; }

        [Required(ErrorMessage = "Primer apellido obligatorio")]
        [Display(Name = "Primer Apellido")]
        public string Use_Inf_L_Name { get; set; }

        [Display(Name = "Segundo Apellido")]
        public string Use_Inf_LS_Name { get; set; }

        [Required(ErrorMessage = "Seleccionar fecha de nacimiento")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime Use_Inf_Date { get; set; }

        [Required(ErrorMessage = "Cedula obligatoria")]
        [Display(Name = "Cédula")]
        public string Use_Inf_ICard { get; set; }

        [Display(Name = "Teléfono O Celular")]
        public string Use_Inf_Phone { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Ingresar Email Valido")]
        [Display(Name = "Email")]
        public string Use_Inf_Email { get; set; }

        public Type_User_Entity Type_User_Entity { get; set; }
        public User_Entity User_Entity { get; set; }

    }
}
