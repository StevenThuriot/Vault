using System.ServiceProcess;

namespace Vault
{
    partial class VaultService : ServiceBase
    {
        private readonly Vault _vault;

        public VaultService()
        {
            InitializeComponent();
            _vault = new Vault();
        }

        protected override void OnStart(string[] args)
        {
            _vault.Start();
        }

        protected override void OnStop()
        {
            _vault.Stop();
        }
    }
}
