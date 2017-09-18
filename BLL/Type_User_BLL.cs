using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public class Type_User_BLL
    {
        public static List<Type_User_Entity> Listar()
        {
            return Type_User_Dal.Listar();
        }

        public static Type_User_Entity Listar(Guid IdType)
        {
            return Type_User_Dal.Listar(IdType);
        }
        public static bool Create(Type_User_Entity objEntity)
        {
            return Type_User_Dal.Create(objEntity);
        }
    }
}
