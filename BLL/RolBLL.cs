using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public class RolBLL
    {
        public static List<Rol_Entity> Listar()
        {
            return RolDal.Listar();
        }

        public static Rol_Entity Listar(Guid IdRol)
        {
            return RolDal.Listar(IdRol);
        }

        public static bool Create(Rol_Entity objRol)
        {
            return RolDal.Create(objRol);
        }
    }
}
