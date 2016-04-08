using System.Web.Http;

namespace Vault.Controllers
{
    //TODO: Remove test data
    public class VaultController : ApiController
    {
        // GET api/vault 
        public IHttpActionResult Get()
        {
            var content = new[]
            {
                new { Id = 1, Url = "http://www.google.com", Paswd = "value1"},
                new { Id = 2, Url = "http://www.google.be", Paswd = "value2"}
            };

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
