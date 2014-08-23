using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Query;
using Domain.Data.Model;

namespace Domain.Contacts.Queries
{
	public class ContactsQuery : Query<IEnumerable<ContactProxy>>
	{
		public string NameFilter { get; set; }
	}

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

	public interface IReadOnlyRepository
	{
		IQueryable<T> Query<T>() where T : class;
	}

	public class ReadOnlyRepository : IReadOnlyRepository
	{
		private readonly ContactAppEntities _context;

		//at IOC container registration time we explicitly construct the context with change tracking to Off.
		public ReadOnlyRepository(ContactAppEntities context)
		{
			_context = context;
		}

		public IQueryable<T> Query<T>() where T : class
		{
			return _context.Set<T>();
		}
	}

	public class ContactProxy
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
	}
}