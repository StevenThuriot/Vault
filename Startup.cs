using System.Web.Http;
using Owin;
using Newtonsoft.Json;
using System.Web.Http.Routing;
using System.Net.Http;

namespace Vault
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var routes = new HttpRouteCollection();

            routes.MapHttpRoute("DefaultApiWithId", "api/{controller}/{id}", new { id = RouteParameter.Optional }, new { id = @"\d+" });
            routes.MapHttpRoute("DefaultApiWithAction", "api/{controller}/{domain}");
            routes.MapHttpRoute("DefaultApiGet", "api/{controller}", new { action = "Get" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) });

            app.UseWebApi(new HttpConfiguration(routes));

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
