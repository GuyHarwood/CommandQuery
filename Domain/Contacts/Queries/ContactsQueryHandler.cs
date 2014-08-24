using System.Collections.Generic;
using System.Linq;
using Core.Query;
using Domain.Data.Model;

namespace Domain.Contacts.Queries
{
	public class ContactsQueryHandler : IQueryHandler<ContactsQuery, IEnumerable<ContactProxy>>
	{
		private readonly IReadOnlyRepository _repository;

		public ContactsQueryHandler(IReadOnlyRepository repository)
		{
			_repository = repository;
		}

		public IEnumerable<ContactProxy> Handle(ContactsQuery query)
		{
			IQueryable<ContactProxy> qry = from c in _repository.Query<Contact>()
				select new ContactProxy
				{
					Id = c.Id,
					Name = c.Name
				};

			if (!string.IsNullOrWhiteSpace(query.NameFilter))
			{
				qry = qry.Where(c => c.Name.StartsWith(query.NameFilter));
			}

			return qry.ToArray();
		}
	}
}