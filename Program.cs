using System.Windows.Forms;

namespace Vault
{
    public static class Program
    {
        internal const string AssemblyTitle = "Vault";
        internal const string AssemblyVersion = "1.0.0";

        public static void Main(string[] args)
        {
            using (var context = new SystemTrayContext())
            {
                var vault = new Vault();
                vault.Start();

                Application.Run(context);

                vault.Stop();
            }
        }
    }   


}
