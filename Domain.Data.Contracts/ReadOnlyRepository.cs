using System.Linq;
using Domain.Contacts.Queries;
using Domain.Data.Model;

namespace Domain.Data.Contracts
{
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
}