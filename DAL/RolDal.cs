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
    public class RolDal
    {
        public static List<Rol_Entity> Listar()
        {
            var objRol = new List<Rol_Entity>();
            try
            {
                Conexion.IniciarSesion();

                var dt = Conexion.GDatos.TraerDataTable("SP_Listar", "CAT_ROL");

                foreach (DataRow item in dt.Rows)
                {
                    objRol.Add(new Rol_Entity
                    {
                        Rol_Int_Id = (Guid)(item["ROL_INT_ID"]),
                        Rol_Name = item["ROL_NAME"].ToString(),
                        
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
            return objRol;
        }

        public static Rol_Entity Listar(Guid IdRol)
        {
            var objCat = new Rol_Entity();
            try
            {
                //var dt = Conexion.GDatos.TraerDataTable("",idCat);
                DataTable dt = Conexion.GDatos.TraerDataTable("SP_Listar", "CAT_ROL");
                var row = (from Cat in dt.AsEnumerable()
                           where Cat.Field<Guid>("ROL_INT_ID") == IdRol
                           select Cat).ToList();
                if (row.Count > 0)
                {

                    objCat.Rol_Int_Id = (Guid)row[0].ItemArray[0];
                    objCat.Rol_Name = row[0].ItemArray[1].ToString();

                }
            }
            catch (Exception)
            {

                throw;
            }
            return objCat;
        }

        public static bool Create(Rol_Entity objRol)
        {
            bool flag = false;

            try
            {
                Conexion.GDatos.Ejecutar("SP_IM_ROL", objRol.Rol_Int_Id, objRol.Rol_Name);
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
