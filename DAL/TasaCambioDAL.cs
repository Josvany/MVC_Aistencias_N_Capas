using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;
using DAL.WSTasaDeCambio;
using System.Xml;
using System.Web;
using System.Xml.Linq;

namespace DAL
{
    public class TasaCambioDAL
    {
 
        public static IEnumerable<TasaCambioEntity> ObtenerTasaCambio()
        {
            using (WSTasaDeCambio.Tipo_Cambio_BCNSoapClient TipoCambio = new Tipo_Cambio_BCNSoapClient())
            {
                var TasaCambio = TipoCambio.RecuperaTC_Mes(DateTime.Today.Year, DateTime.Today.Month);

                var TablaTasaCambio = TasaCambio.Elements().Select(x => new TasaCambioEntity {
                    Fecha = DateTime.Parse(x.Element("Fecha").Value),
                    Valor = (x.Element("Valor").ToString())
                }).ToArray();

                return TablaTasaCambio;
            }
        }
    }
}
