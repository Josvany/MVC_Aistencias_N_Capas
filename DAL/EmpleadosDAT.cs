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
    public class EmpleadosDAT
    {
        public static List<Empleados> Listar()
        {
            var objEmpleado = new List<Empleados>();
            try
            {
                var dt = Conexion.Leer("Usp_ListarEmpleados");

                foreach (DataRow item in dt.Rows)
                {
                    objEmpleado.Add(new Empleados
                    {
                        IdEmpleado = Convert.ToInt32(item["IdEmpleados"]),
                        Nombres = item["Nombres"].ToString(),
                        Status = Convert.ToBoolean(item["Activo"]),
                        IdDepartament = Convert.ToInt32(item["IdDepartamento"]),
                        IdTurno = int.Parse(item["IdTurno"].ToString()),
                        Salario = Convert.ToDouble(item["Salario"]),
                        DiaLibre = Convert.ToString(item["DiaLibre"]),
                        Turno = item["Turno"].ToString(),
                        Departamento = item["Departamento"].ToString()


                    });
                }


            }
            catch (Exception)
            {

                throw;
            }
            return objEmpleado;
        }

        public static Empleados Listar(int IdEmpleados)
        {
            var objemple = new Empleados();

            try
            {
                var dt = Conexion.Leer("Usp_ObtenerEmpleados", IdEmpleados);
                if (dt.Rows.Count > 0)
                {
                    objemple.IdEmpleado = (int)dt.Rows[0][0];
                    objemple.Nombres = dt.Rows[0][1].ToString();
                    objemple.Status = (bool)dt.Rows[0][2];
                    objemple.IdDepartament = (int)dt.Rows[0][3];
                    objemple.IdTurno = (int)dt.Rows[0][4];
                    objemple.Salario = (double)dt.Rows[0][5];
                    objemple.DiaLibre = dt.Rows[0][6].ToString();
                    objemple.Departamento = dt.Rows[0][7].ToString();
                    objemple.Turno = dt.Rows[0][8].ToString();
                   
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return objemple;
        }

        public DataTable ListarDT(int IdEmpleado)
        {
            DataTable dt = null;
            try
            {
                dt = Conexion.Leer("Usp_ObtenerEmpleados", IdEmpleado);
            }
            catch (Exception ex)
            {

                throw;
            }
            return dt;
        }

        public static bool Create( Empleados objEmple)
        {
            bool flag = false;
            try
            {
                using (var cn = Conexion.GetConnection())
                {
                    cn.Open();
                    var SqlQuery = new SqlCommand("Usp_InsertEmpleados", cn);
                    SqlQuery.CommandType = CommandType.StoredProcedure;

                    SqlQuery.Parameters.AddWithValue("@Nombres",objEmple.Nombres);
                    SqlQuery.Parameters.AddWithValue("@Activo", objEmple.Status);
                    SqlQuery.Parameters.AddWithValue("@IdDepartamento", objEmple.IdDepartament);
                    SqlQuery.Parameters.AddWithValue("@IdTurno", objEmple.IdTurno);
                    SqlQuery.Parameters.AddWithValue("@Salario", objEmple.Salario);
                    SqlQuery.Parameters.AddWithValue("@DiaLibre", objEmple.DiaLibre);

                    SqlQuery.ExecuteNonQuery();
                    flag = true;

                }
            }
            catch (Exception)
            {

                throw;
            }

            return flag;
        }

        public static bool Edit(Empleados objEmple)
        {
            bool flag = false;
            try
            {
                using (var cn = Conexion.GetConnection())
                {
                    cn.Open();
                    Conexion.Guardar("Usp_UpdateEmpleados", objEmple.IdEmpleado, objEmple.Nombres, objEmple.IdDepartament, objEmple.IdTurno
                                                           ,objEmple.Salario, objEmple.DiaLibre);
                    flag = true;

                }
            }
            catch (Exception)
            {

                throw;
            }

            return flag;
        }
    }
}
