using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

namespace BLL
{
    public class DepartamentBLL
    {
        public static List<Deparment_Entity>Listar()
        {
            return DepatamentoDAL.Listar();
        }
    }
}
