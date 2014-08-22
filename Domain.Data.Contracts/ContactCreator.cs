using System;
using System.Security.Principal;
using Domain.Contacts.Commands;
using Domain.Data.Model;

namespace Domain.Data.Contracts
{
    public class ContactCreator : ICreateAContact
    {
        private readonly ContactAppEntities _context;
        private readonly IDateTimeProvider _dateTimeProvider;

        public ContactCreator(ContactAppEntities context)
        {
            this._context = context;
        }

        public void Create(string name)
        {
            this._context.Set<Contact>().Add(new Contact
            {
                CreatedAt = DateTime.Now,
                CreatedBy = "TODO", //You would resolve this down to the userId normally
                Name = name,
                Id = Guid.NewGuid() //just for the purposes of this POC, can be whatever
            });
        }
    }

    public interface IDateTimeProvider
    {
        DateTime Now { get; set; }
    }
}