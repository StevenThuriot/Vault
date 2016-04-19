using System.ServiceProcess;

namespace Vault
{
    partial class VaultService : ServiceBase
    {
        private readonly VaultApi _vaultApi;

        public VaultService()
        {
            InitializeComponent();
            _vaultApi = new VaultApi();
        }

        protected override void OnStart(string[] args)
        {
            _vaultApi.Start();
        }

        protected override void OnStop()
        {
            _vaultApi.Stop();
        }
    }
}
