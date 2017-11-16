using Nancy;

namespace ResftfullApp.Monedas
{
    public class MonedaPeso: IMoneda
    {
        public dynamic GetCotizacion(IResponseFormatter res)
        {
            return HttpStatusCode.Unauthorized;
        }
    }
}
