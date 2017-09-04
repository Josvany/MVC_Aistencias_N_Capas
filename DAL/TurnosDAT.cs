using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Capa_Conexion;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace DAL
{
    public class TurnosDAT
    {
        public static List<Turnos_Entity> Listar()
        {
            var objTurn = new List<Turnos_Entity>();
            try
            {
                var dt = Conexion.Leer("Usp_ListarTurnos");

                foreach (DataRow item in dt.Rows)
                {
                    objTurn.Add(new Turnos_Entity
                    {
                        IdTuno = Convert.ToInt32(item["IdTurno"]),
                        Turnos = item["Turno"].ToString(),
                        //TurnInit =( DateTime)item["Lunes_Sabado_Inicio"],//(new CultureInfo("en-US")),
                        //TurnEnd = (DateTime)(item["Lunes_Sabado_Fin"]),
                        //Horas = float.Parse(item["Turno"].ToString()),
                        //AlmInit = (DateTime)(item["Almuerzo_Inicio"]),
                        //AlmEnd = (DateTime)(item["Almuerzo_Fin"])

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
            catch (Exception ex)
            {

                throw;
            }
            return objTurn;
        }


        
    }
}
