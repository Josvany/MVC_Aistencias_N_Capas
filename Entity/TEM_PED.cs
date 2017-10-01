using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class TEM_PED
    {
        public TEM_PED()
        {
            Pago_Entity = new Pago_Entity();
        }
        public Guid Tem_Int_Id { get; set; }
        public Guid Cat_int_id { get; set; }
        public string Use_Login { get; set; }
        public Guid Prod_Int_Id { get; set; }
        [Display(Name ="Nombre Producto")]
        public string Name_Prod { get; set; }
        [Display(Name = "Cantidad Producto")]
        public int Cant_Prod { get; set; }
        [Display(Name = "Nombre Precio")]
        public decimal Precio_Prod { get; set; }
        public DateTime Fecha { get; set; }

        public Pago_Entity Pago_Entity { get; set; }
    }
}
