using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

namespace BLL
{
    public class TasaCambioBLL
    {

        public static IEnumerable<TasaCambioEntity> ObtenerTasaCambio()
            {
                return TasaCambioDAL.ObtenerTasaCambio();
            }
        }

}
