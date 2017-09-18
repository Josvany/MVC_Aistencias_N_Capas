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
