using System;

namespace Data
{
	/// <summary>
	///     Post commit hook for unit of work.  Useful if you need to retrieve the Id of a newly inserted record
	/// </summary>
	public interface IPostCommitRegistrar
	{
		/// <summary>
		///     Implement your post commit operations within this method
		/// </summary>
		event Action UnitOfWorkComplete;
	}
}