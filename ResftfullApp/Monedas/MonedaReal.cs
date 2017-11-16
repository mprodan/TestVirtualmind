using Nancy;

namespace ResftfullApp.Monedas
{
    class MonedaReal : IMoneda
    {
        public dynamic GetCotizacion(IResponseFormatter res)
        {
            return HttpStatusCode.Unauthorized;
        }
    }
}
