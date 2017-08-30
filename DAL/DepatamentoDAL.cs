using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Capa_Conexion;
using System.Data;
using System.Data.SqlClient;
// DAL = DATA ACCES LOGIN
namespace DAL
{
    public class DepatamentoDAL
    {
        public static List<Deparment_Entity>Listar()
        {
            var objDepartament = new List<Deparment_Entity>();
            try
            {
                var dt = Conexion.Leer("Usp_ListarDepartamento");

                foreach (DataRow item in dt.Rows)
                {
                    objDepartament.Add(new Deparment_Entity
                    {
                        IdDepartament = Convert.ToInt32(item["IdDepartamento"]),
                        Departament = item["Departamento"].ToString()
                    });
                }

                //for (int i = 0; i < dt.Rows.Count - 1; i++)
                //{
                //    objDepartament.Add(new Deparment_Entity
                //    {
                //        IdDepartament = Convert.ToInt32(dt.Rows[i][0]),
                //        Departament = dt.Rows[i][0].ToString()
                //    });
                //}

            }
            catch (Exception)
            {

                throw;
            }
            return objDepartament;
        }
    }
}