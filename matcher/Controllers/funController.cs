using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using matcher.Models;

namespace matcher.Controllers
{
    public class funController : ApiController
    {
        // GET: api/fun
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/fun/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/fun
        public returnObj Post([FromBody]fun.RootObject json)
        {
            returnObj ret = new returnObj();
            foreach (var v in json.tweets)
            {
                ret.UserIdOne = json.user_id;
            }
            return ret;
        }

        // PUT: api/fun/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/fun/5
        public void Delete(int id)
        {
        }
    }
}
