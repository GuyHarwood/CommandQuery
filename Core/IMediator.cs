using System.Threading.Tasks;
using Core.Query;

namespace Core
{
	public interface IMediator
	{
		TResult Execute<TResult>(Query<TResult> query);
		void Dispatch<TCommand>(TCommand command) where TCommand : Command.Command;
		Task DispatchAsync<TCommand>(TCommand command) where TCommand : Command.Command;
	}
}