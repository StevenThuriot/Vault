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
        {   try
            {
                var content = _container.ResolveKeys(pw);
                return Json(content);
            }
            catch
            {
                return BadRequest();
            }
        }
        
        // GET api/vault/google.com
        public IHttpActionResult Get(string key)
        {
            try
            {
                var value = _container.Decrypt(key, pw);
                return Json(value.ToUnsecureString());
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST api/vault/google.com
        public IHttpActionResult Post(string key, [FromBody]string password)
        {
            try
            {
                _container.Insert(key, password.Secure(), pw);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/vault/google.com
        public IHttpActionResult Put(string key, [FromBody]string password)
        {
            try
            {
                _container.Update(key, password.Secure(), pw);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/vault/google.com
        public IHttpActionResult Delete(string key)
        {
            try
            {
                _container.Delete(key, pw);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
