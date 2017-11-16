using Nancy;
using System.IO;
using System.Net;

namespace ResftfullApp.Monedas
{
    public class MonedaDolar : NancyModule, IMoneda
    {
        private const string URL= @"https://www.bancoprovincia.com.ar/Principal/Dolar";

        public dynamic GetCotizacion(IResponseFormatter res)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URL);
            req.Method = "GET";
            req.ContentType = "json";
            HttpWebResponse response = (HttpWebResponse)req.GetResponse();
            string browseResponse;
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                browseResponse = streamReader.ReadToEnd();
            }

            return res.AsJson(browseResponse,(Nancy.HttpStatusCode)response.StatusCode);
        }
    }
}
