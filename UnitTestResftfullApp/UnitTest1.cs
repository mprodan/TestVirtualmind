using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Nancy.Testing;
using ResftfullApp.Monedas;

namespace UnitTestResftfullApp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void testDolar()
        {
            // Given
            var browser = new Browser(with => with.Module<MonedasController>());

            // When
            var result = browser.Get(@"/MyResftfullApp/Cotizacion/Dolar"
            , with => with.HttpRequest());

            // Then
            Assert.IsTrue(HttpStatusCode.OK==result.StatusCode);
        }

        [TestMethod]
        public void testPeso()
        {
            // Given
            var browser = new Browser(with => with.Module<MonedasController>());

            // When
            var result = browser.Get(@"/MyResftfullApp/Cotizacion/Peso"
            , with => with.HttpRequest());

            // Then
            Assert.IsTrue(HttpStatusCode.Unauthorized==result.StatusCode);
        }
    }
}
