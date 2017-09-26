using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Factura_Entity
    {
        public Guid Fact_Int_Id { get; set; }

        [Display(Name = "Número de Factura")]
        public string Fac_Number { get; set; }

        [Display(Name = "Forma de Pago")]
        [Required(ErrorMessage = "Ingresar Forma de Pago")]
        public Guid Pag_Int_Id { get; set; }

        public DateTime Fecha_Factura { get; set; }

        public Guid Use_Inf_Int_Id { get; set; }

        [Display(Name = "Usuario")]
        public Guid Use_Int_Id { get; set; }

        [Display(Name = "Total")]
        public decimal Fac_Sub_Total { get; set; }


        [Display(Name = "Descuento")]
        public decimal Fac_Descuento { get; set; }


        [Display(Name = "Iva")]
        public decimal Fac_Iva { get; set; }

    }
}
