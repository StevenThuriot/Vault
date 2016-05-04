using System.Web.Http;
using Owin;
using Newtonsoft.Json;

namespace Vault
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var httpConfiguration = new HttpConfiguration();
            httpConfiguration.MapHttpAttributeRoutes();

            app.UseWebApi(httpConfiguration);

            //Serialize once, then capture in our delegate
            var info = JsonConvert.SerializeObject(new { Name = Program.AssemblyTitle, Version = Program.AssemblyVersion });
            
            app.Run(context =>
            {
                if (context.Request.Path.HasValue && context.Request.Path.Value == "/")
                {
                    context.Response.Headers.Set("Content-Type", "text/plain");
                    context.Response.ContentType = "text/plain";
                    return context.Response.WriteAsync($"Hello, world! I am {Program.AssemblyTitle}.");
                }

                context.Response.Headers.Set("Content-Type", "application/json");
                context.Response.ContentType = "application/json";
                return context.Response.WriteAsync(info);
            });
        }
    }
}
