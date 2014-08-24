using System.Collections.Generic;
using Core.Query;

namespace Domain.Contacts.Queries
{
	public class ContactsQuery : QueryBase<IEnumerable<ContactProxy>>
	{
		public string NameFilter { get; set; }
	}
}