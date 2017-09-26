using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Conexion;
using Entity;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Use_Inf_Dal
    {
        public static User_Info_Entity Listar(Guid Use_Inf_Int_Id)
        {
            var objInfUse = new User_Info_Entity();

            try
            {
                Conexion.IniciarSesion();
                var dt = Conexion.GDatos.TraerDataTable("SP_Listar", "TBL_USER_INFO");

                var row = (from User in dt.AsEnumerable()
                           where User.Field<Guid>("USE_INF_INT_ID") == Use_Inf_Int_Id
                           select User).ToList();
                foreach (DataRow item in row)
                {

                    objInfUse.Use_Inf_Int_Id = (Guid)(item["USE_INF_INT_ID"]);
                    objInfUse.Typ_Use_Int_id = item["CAT_TYP_USER"] == DBNull.Value ? Guid.Empty : (Guid)item["CAT_TYP_USER"];
                    objInfUse.Use_Inf_F_Name = item["USE_INF_PRIMER_N"].ToString();
                    objInfUse.Use_Inf_FS_Name = item["USE_INF_SEGUNDO_N"].ToString();
                    objInfUse.Use_Inf_L_Name = item["USE_INF_PRIMER_A"].ToString();
                    objInfUse.Use_Inf_LS_Name = item["USE_INF_SEGUNDO_A"].ToString();
                    objInfUse.Use_Inf_Date = Convert.ToDateTime(item["USE_INF_FECHA_NAC"]);
                    objInfUse.Use_Inf_ICard = item["USE_INF_CED"].ToString();
                    objInfUse.Use_Inf_Phone = item["USE_INF_TEL"].ToString();
                    objInfUse.Use_Inf_Email = item["USE_INF_EMAIL"].ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return objInfUse;

        }

        public static bool Create(User_Info_Entity ObjuserInf, string Use_Login)
        {
            bool flag = false;
            try
            {
                Conexion.IniciarSesion();
                Conexion.GDatos.Ejecutar("SP_IM_USER_INFO", ObjuserInf.Use_Inf_Int_Id == Guid.Empty ? Guid.NewGuid() : ObjuserInf.Use_Inf_Int_Id,
                                                            ObjuserInf.Typ_Use_Int_id, ObjuserInf.Use_Inf_F_Name,
                                                            ObjuserInf.Use_Inf_FS_Name, ObjuserInf.Use_Inf_L_Name,
                                                            ObjuserInf.Use_Inf_LS_Name, ObjuserInf.Use_Inf_Date,
                                                            ObjuserInf.Use_Inf_ICard, ObjuserInf.Use_Inf_Phone,
                                                            ObjuserInf.Use_Inf_Email, Use_Login);
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
