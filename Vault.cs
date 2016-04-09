using System;
using Microsoft.Owin.Hosting;

namespace Vault
{
    public class Vault
    {
        private IDisposable _webApp;
        public void Start()
        {
            _webApp = WebApp.Start<Startup>("http://+:1234");
        }

        public void Stop()
        {
            if (_webApp != null)
            {
                _webApp.Dispose();
                _webApp = null;
            }
        }
    }
}
