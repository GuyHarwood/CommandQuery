using System.Threading.Tasks;

namespace Core.Command
{
	public interface ICommandHandlerAsync<in TCommand> where TCommand : CommandBase
	{
		Task HandleAsync(TCommand command);
	}
}