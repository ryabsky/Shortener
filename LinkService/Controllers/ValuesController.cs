using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LinkService.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly LinkRepository repository = new LinkRepository();

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "hello", "world" };
        }

        public HttpResponseMessage Get(string id)
        {
            var link = repository.GetLink(id);
            if (link == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                repository.AddClick(id);
                var response = Request.CreateResponse(HttpStatusCode.Found);
                response.Headers.Location = new Uri(link.Url);
                return response;
            }
        }
    }
}
