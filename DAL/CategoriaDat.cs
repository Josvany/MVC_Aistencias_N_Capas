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
    public class CategoriaDat
    {
        public static List<Categorias_Entity> Listar()
        {
            var objCat = new List<Categorias_Entity>();
            try
            {
                Conexion.IniciarSesion();

                var dt = Conexion.GDatos.TraerDataTable("SP_Listar", "CAT_CATEGORIA");

                foreach (DataRow item in dt.Rows)
                {
                    objCat.Add(new Categorias_Entity
                    {
                        CatIntIdValue = (Guid)(item["CAT_INT_ID"]),
                        CatNombreValue = item["CAT_NOMBRE"].ToString(),
                        CatStatusValue = (item["CAT_STATUS"]) == DBNull.Value ? false : (bool)(item["CAT_STATUS"]),
                        CatCodigoValue = Convert.ToString(item["CAT_SYS_NAME"])
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
            return objCat;
        }

        public static List<Categorias_Entity> Listar(Guid IdCat)
        {
            var objCat = new List<Categorias_Entity>();
            try
            {
                //var dt = Conexion.GDatos.TraerDataTable("",idCat);
                DataTable dt = Conexion.GDatos.TraerDataTable("SP_Listar", "CAT_CATEGORIA");
                var row = (from Cat in dt.AsEnumerable()
                           where Cat.Field<Guid>("CAT_INT_ID") == IdCat
                           select Cat).ToList();
                if (row.Count > 0)
                {

                    objCat.Add(new Categorias_Entity
                    {
                        CatIntIdValue = (Guid)row[0].ItemArray[0],
                        CatNombreValue = row[0].ItemArray[1].ToString(),
                        CatCodigoValue = row[0].ItemArray[2].ToString(),
                        CatStatusValue = (bool)row[0].ItemArray[3]
                    });

                }
            }
            catch (Exception)
            {

                throw;
            }
            return objCat;
        }

        public static bool Create(Categorias_Entity objCat)
        {
            bool flag = false;

            try
            {
                Conexion.GDatos.Ejecutar("SP_IM_Categoria", objCat.CatIntIdValue, objCat.CatNombreValue, objCat.CatCodigoValue, objCat.CatStatusValue);
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