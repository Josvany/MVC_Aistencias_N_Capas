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
        public static Categorias_Entity Listar(Guid IdCat)
        {
            return CategoriaDat.Listar(IdCat);
        }

    }
}
