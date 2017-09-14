using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Productos_Entity
    {
        public Productos_Entity()
        {
            Categorias_Entity = new Categorias_Entity();
        }
        public Guid Prod_Int_Id { get; set; }

        [Required(ErrorMessage = "Favor ingresar el Nombre")]
        [Display(Name = "Nombre Producto")]
        public string Producto_Name { get; set; }

        [Required(ErrorMessage = "Favor ingresar el codigo")]
        [Display(Name = "Codigo Producto")]
        public string Prod_Codig { get; set; }

        [Required(ErrorMessage = "Favor ingresar el precio venta")]
        [Display(Name = "Precio Producto")]
        public double Precio_venta { get; set; }

        [Required(ErrorMessage = "Favor ingresar el precio de compra")]
        [Display(Name = "Precio Producto")]
        public double Precio_Compra { get; set; }

        [Required(ErrorMessage = "Favor ingresar el precio")]
        [Display(Name = "Precio Producto")]
        public double Precio_Catidad { get; set; }

        [Required(ErrorMessage = "Favor seleccionar una categoria")]
        [Display(Name = "Categoria")]
        public Guid Prod_Cat { get; set; }

        [Display(Name = "Categoria")]
        public bool Prod_Status { get; set; }

        public Categorias_Entity Categorias_Entity { get; set; }

    }
}
