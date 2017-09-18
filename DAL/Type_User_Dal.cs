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
    public class Type_User_Dal
    {
        public static List<Type_User_Entity> Listar()
        {

            var objTypeUser = new List<Type_User_Entity>();
            try
            {
                Conexion.IniciarSesion();

                var dt = Conexion.GDatos.TraerDataTable("SP_Listar", "CAT_TYPE_USER");

                foreach (DataRow item in dt.Rows)
                {
                    objTypeUser.Add(new Type_User_Entity
                    {
                        Typ_Use_Int_id = (Guid)(item["CAT_TYP_USER"]),
                        Typ_Use_Name = item["CAT_TYP_NAME"].ToString(),

                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
            return objTypeUser;
        }

        public static Type_User_Entity Listar(Guid IdType)
        {
            var objCat = new Type_User_Entity();
            try
            {
                //var dt = Conexion.GDatos.TraerDataTable("",idCat);
                DataTable dt = Conexion.GDatos.TraerDataTable("SP_Listar", "CAT_TYPE_USER");
                var row = (from Cat in dt.AsEnumerable()
                           where Cat.Field<Guid>("CAT_TYP_USER") == IdType
                           select Cat).ToList();
                if (row.Count > 0)
                {
                    objCat.Typ_Use_Int_id = (Guid)row[0].ItemArray[0];
                    objCat.Typ_Use_Name = row[0].ItemArray[1].ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return objCat;
        }

        public static bool Create(Type_User_Entity objEntity)
        {
            bool flag = false;
            try
            {
                Conexion.GDatos.Ejecutar("SP_IM_TYPE_USER", objEntity.Typ_Use_Int_id, objEntity.Typ_Use_Name);
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
