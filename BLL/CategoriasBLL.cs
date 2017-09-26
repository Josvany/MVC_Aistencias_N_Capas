using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public class CategoriasBLL
    {
        public static List<Categorias_Entity> Listar()
        {
            return CategoriaDat.Listar();
        }
        public static List<Categorias_Entity> Listar(Guid IdCat)
        {
            return CategoriaDat.Listar(IdCat);
        }

        public static bool Create(Categorias_Entity objCat)
        {
            return CategoriaDat.Create(objCat);
        }
    }
}
