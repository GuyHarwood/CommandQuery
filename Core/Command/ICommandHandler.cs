namespace Core.Command
{
	public interface ICommandHandler<in TCommand> where TCommand : CommandBase
	{
		void Handle(TCommand command);
	}
}