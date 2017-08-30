using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public class EmpleadosBLL
    {
        public static List<Empleados> Listar()
        {
            return EmpleadosDAT.Listar();
        }
        public static Empleados Listar(int id)
        {
            return EmpleadosDAT.Listar(id);
        }

        public static bool Create(Empleados objemple)
        {
            return EmpleadosDAT.Create(objemple);
        }


        public static bool Edit(Empleados objEmp)
        {
            return EmpleadosDAT.Edit(objEmp);
        }

    }
}
