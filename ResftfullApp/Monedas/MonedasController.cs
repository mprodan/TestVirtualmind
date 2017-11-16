using System;
using Nancy;

namespace ResftfullApp.Monedas
{
    public class MonedasController : NancyModule
    {
        public MonedasController()
        {
            Get["MyResftfullApp/Cotizacion/{MONEDA}"] = Cotizacion;
        }

        private dynamic Cotizacion(dynamic parameters)
        {
            IMoneda mon = null;
            string moneda = parameters.MONEDA;
            moneda = moneda.ToUpperInvariant();
            if (moneda == "DOLAR")
                mon = new MonedaDolar();
            else if (moneda == "PESO")
                mon = new MonedaPeso();
            else if (moneda == "REAL")
                mon = new MonedaReal();
            else
                return HttpStatusCode.InternalServerError;

            return mon.GetCotizacion(Response);
        }
    }
}
