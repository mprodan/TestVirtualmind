using Nancy;

namespace ResftfullApp.Monedas
{
    interface IMoneda
    {
        dynamic GetCotizacion(IResponseFormatter res);
    }
}
