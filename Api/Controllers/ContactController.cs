using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Core;
using Domain.Contacts.Queries;

namespace Api.Controllers
{
    [Authorize]
    public class ContactController : ApiController
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            IEnumerable<ContactProxy> result = this._mediator.Execute(new ContactsQuery());
            return result.Select(c => c.Name).ToArray();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}