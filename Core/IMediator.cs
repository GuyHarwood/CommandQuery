using System.Threading.Tasks;
using Core.Command;
using Core.Query;

namespace Core
{
	public interface IMediator
	{
		TResult Execute<TResult>(QueryBase<TResult> queryBase);
		void Dispatch<TCommand>(TCommand command) where TCommand : CommandBase;
		Task DispatchAsync<TCommand>(TCommand command) where TCommand : CommandBase;
	}
}