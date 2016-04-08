using System.Windows.Forms;
using Microsoft.Owin.Hosting;

namespace Vault
{
    public static class Program
    {
        internal const string AssemblyTitle = "Vault";
        internal const string AssemblyVersion = "1.0.0";

        public static void Main(string[] args)
        {
            using (var context = new SystemTrayContext())
            using (WebApp.Start<Startup>("http://+:1234"))
            {
                Application.Run(context);
            }
        }
    }   
}
