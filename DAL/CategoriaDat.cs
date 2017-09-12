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
                var dt = Conexion.Leer("SP_Listar", "CAT_CATEGORIA");

                foreach (DataRow item in dt.Rows)
                {
                    objCat.Add(new Categorias_Entity
                    {
                        CatIntIdValue = (Guid)(item["CAT_INT_ID"]),
                        CatNombreValue = item["CAT_NOMBRE"].ToString(),
                        CatStatusValue = Convert.ToBoolean(item["CAT_STATUS"]),
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

        public static Categorias_Entity Listar(Guid IdCat)
        {
            var objCat = new Categorias_Entity();
            try
            {
                var dt = Conexion.Leer("Listar_Cat", IdCat);
                if (dt.Rows.Count > 0)
                {
                    objCat.CatIntIdValue = (Guid)dt.Rows[0][0];
                    objCat.CatNombreValue = dt.Rows[0][1].ToString();
                    objCat.CatCodigoValue = dt.Rows[0][2].ToString();
                    objCat.CatStatusValue = (bool)dt.Rows[0][3];
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objCat;
        }
    }
}