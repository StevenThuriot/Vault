using System;
using System.ServiceProcess;
using Microsoft.Owin.Hosting;

namespace Vault
{
    partial class VaultService : ServiceBase
    {
        private IDisposable _webApp;

        public VaultService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _webApp = WebApp.Start<Startup>("http://+:1234");
        }

        protected override void OnStop()
        {
            if (_webApp != null)
            {
                _webApp.Dispose();
                _webApp = null;
            }
        }
    }
}
