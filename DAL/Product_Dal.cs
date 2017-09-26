using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Capa_Conexion;
using System.Data;

namespace DAL
{
    public class Product_Dal
    {
        public static List<Product_Entity> Listar()
        {

            var objProd = new List<Product_Entity>();
            try
            {
                Conexion.IniciarSesion();

                var dt = Conexion.GDatos.TraerDataTable("SP_Listar", "TBL_PRODUCTO");

                foreach (DataRow item in dt.Rows)
                {
                    objProd.Add(new Product_Entity
                    {
                        Prod_Int_Id = (Guid)(item["PROD_INT_ID"]),
                        Prod_Name = item["PROD_NOMBRE"].ToString(),
                        Prod_System_Name = item["PROD_SYS_NAME"].ToString(),
                        Prod_Sale_P = decimal.Parse(item["PROD_PRE_V"].ToString()),
                        Prod_P_C = decimal.Parse(item["PROD_PRE_C"].ToString()),
                        Prod_Cant = (int)item["PROD_CANT"],
                        Cat_Int_Id = (Guid)item["CAT_INT_ID"],
                        Prod_Status = (bool)item["PROD_NOMBRE"],
                        Prod_Img = (byte[])item["PROD_NOMBRE"]

                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
            return objProd;
        }
    }
}
