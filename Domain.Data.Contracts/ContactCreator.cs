using System;
using Domain.Common;
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
			_context = context;
		}

		public void Create(string name)
		{
			_context.Set<Contact>().Add(new Contact
			{
//				CreatedAt = _dateTimeProvider.Now,
//				CreatedBy = //TODO resolve to user id
				Name = name,
				Id = Guid.NewGuid() //just for the purposes of this POC, can be whatever
			});
		}
	}
}