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
    public class PagoDal
    {
        public static List<Pago_Entity> Listar()
        {
            var objPago = new List<Pago_Entity>();
            try
            {
                Conexion.IniciarSesion();

                var dt = Conexion.GDatos.TraerDataTable("SP_Listar", "CAT_PAGO");

                foreach (DataRow item in dt.Rows)
                {
                    objPago.Add(new Pago_Entity
                    {
                        Pag_Int_Id = (Guid)(item["PAG_INT_ID"]),
                        Pag_Name = item["PAG_NOMBRE"].ToString()
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objPago;
        }
    }
}