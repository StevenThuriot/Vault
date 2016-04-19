using System.Security;
using System.Text;
using System.Web.Http;
using Vault.Core;

namespace Vault.Controllers
{
    //TODO: Remove test data
    public class VaultController : ApiController
    {
        //TODO: just for testing things out, replace with injected container and real auth
        readonly byte[] pw = Encoding.Unicode.GetBytes("This is a password!");
        readonly IContainer<SecureString> _container = ContainerFactory.FromFile("vault.enc");

        // GET api/vault 
        public IHttpActionResult Get()
        {
            var content = _container.ResolveKeys(pw);
            return Json(content);
        }

        // GET api/vault/5 
        public IHttpActionResult Get(int id)
        {
            return Json(new { Id = id, Url = "http://www.google.com", Paswd = "value1" });
        }


        // GET api/vault/google.com
        public IHttpActionResult Get(string domain)
        {
            return Json(new { Id = -1, Url = domain, Paswd = "value1" });
        }

        // POST api/vault 
        public void Post([FromBody]string value)
        {
        }

        // PUT api/vault/5 
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/vault/5 
        public void Delete(int id)
        {
        }
    }
}
