using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public class User_BLL
    {
        public static List<User_Entity> Listar()
        {
            return User_Dal.Listar();
        }
        public static List<User_Entity> Listar(string use_login)
        {
            return User_Dal.Listar(use_login);
        }
        public static bool Listar(string Uselogin, string Usepass)
        {
            return User_Dal.Listar(Uselogin, Usepass);
        }

        public static bool Create(User_Entity Objuser)
        {
            return User_Dal.Create(Objuser);
        }
    }
}
