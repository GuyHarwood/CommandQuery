using System.Threading.Tasks;

namespace Core.Command
{
	public interface ICommandHandler<in TCommand> where TCommand : Command
	{
		void Handle(TCommand command);
	}

	public interface IAsyncCommandHandler<in TCommand> where TCommand : Command
	{
		Task Handle(TCommand command);
	}
}