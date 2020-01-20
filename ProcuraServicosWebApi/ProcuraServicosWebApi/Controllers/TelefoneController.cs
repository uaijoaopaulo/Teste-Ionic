using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProcuraServicosWebApi.Controllers
{
    public class TelefoneController : ApiController
    {
        // GET: api/Telefone
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Telefone/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Telefone
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Telefone/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Telefone/5
        public void Delete(int id)
        {
        }
    }
}
