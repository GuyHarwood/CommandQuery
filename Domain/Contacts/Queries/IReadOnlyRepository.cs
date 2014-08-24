using System.Linq;

namespace Domain.Contacts.Queries
{
	public interface IReadOnlyRepository
	{
		IQueryable<T> Query<T>() where T : class;
	}
}