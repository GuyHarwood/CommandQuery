using System;

namespace Data
{
	public sealed class PostCommitRegistrar : IPostCommitRegistrar
	{
		public event Action UnitOfWorkComplete = () => { };

		public void ExecuteActions()
		{
			UnitOfWorkComplete();
		}

		public void Reset()
		{
			UnitOfWorkComplete = () => { };
		}
	}
}