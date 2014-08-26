using System;

namespace Core.Extensions.Hooks
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