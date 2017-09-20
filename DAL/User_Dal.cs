using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Capa_Conexion;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class User_Dal
    {
        public static List<User_Entity> Listar()
        {
            var objUser = new List<User_Entity>();
            try
            {
                Conexion.IniciarSesion();
                var dt = Conexion.GDatos.TraerDataTable("SP_Listar", "TBL_USER");
                foreach (DataRow item in dt.Rows)
                {
                    objUser.Add(new User_Entity
                    {
                        User_Int_Id = (Guid)(item["USE_INT_ID"]),
                        Use_Inf_Int_Id = item["USE_INF_INT_ID"] == DBNull.Value ? Guid.Empty : (Guid)item["USE_INF_INT_ID"],
                        Use_Login = item["USE_LOGIN"].ToString(),
                        Use_Pass = item["CAT_PASS"].ToString(),
                        Rol_Int_Id = (Guid)item["ROL_INT_ID"],
                        Use_Status = (bool)item["USE_STATUS"]
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
            return objUser;
        }


        public static bool Listar(string Uselogin, string Usepass)
        {
            bool flag = false;
            var objUser = new User_Entity();
            try
            {
                //var dt = Conexion.GDatos.TraerDataTable("",idCat);
                DataTable dt = Conexion.GDatos.TraerDataTable("SP_Listar", "TBL_USER");
                var row = (from User in dt.AsEnumerable()
                           where User.Field<string>("USE_LOGIN") == Uselogin && User.Field<string>("USE_PASS") == Usepass
                           select User).ToList();
                if (row.Count > 0)
                {
                    objUser.Use_Login = (string)row[0].ItemArray[2];
                    flag = true;
                    //objCat.Typ_Use_Name = row[0].ItemArray[1].ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return flag;
        }

        public static bool Create(User_Entity Objuser)
        {
            bool flag = false;
            try
            {
                Conexion.GDatos.Ejecutar("SP_IM_USER", Objuser.User_Int_Id, Objuser.Use_Inf_Int_Id, Objuser.Use_Login, Objuser.Use_Pass, Objuser.Rol_Int_Id, Objuser.Use_Status);
                flag = true;
            }
            catch (Exception)
            {

                throw;
            }
            return flag;
        }
    }
}
