using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Entity
{
    public class Product_Entity
    {
        public Product_Entity()
        {
            Categorias_Entity = new Categorias_Entity();
        }
        public Guid Prod_Int_Id { get; set; }

        [Display(Name = "Nombre Producto")]
        [Required(ErrorMessage = "Ingresar nombre")]
        public string Prod_Name { get; set; }
        [Display(Name = "Codigo")]
        [Required(ErrorMessage = "Ingresar codigo")]
        public string Prod_System_Name { get; set; }

        [Display(Name = "Precio de Venta")]
        [Required(ErrorMessage = "Ingresar precio de venta")]
        public decimal Prod_Sale_P { get; set; }

        [Display(Name = "Precio de Compra")]
        [Required(ErrorMessage = "Ingresar precio de compra")]
        public decimal Prod_P_C { get; set; }

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "Ingresar cantidad")]
        public int Prod_Cant { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Ingresar Categoria")]
        public Guid Cat_Int_Id { get; set; }
        public string Cat_Name { get; set; }

        [Display(Name = "Estado")]
        public bool Prod_Status { get; set; }

        public byte[] Prod_Img { get; set; }

        public Categorias_Entity Categorias_Entity { get; set; }
    }
}
