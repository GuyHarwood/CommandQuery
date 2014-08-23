using log4net;

namespace Core.Command
{
	public class CommandAuditor<TCommand> : ICommandHandler<TCommand> where TCommand : Command
	{
		private readonly ICommandHandler<TCommand> _decoratedHandler;
		private readonly ILog _logger;

		public CommandAuditor(ICommandHandler<TCommand> decoratedHandler, ILog logger)
		{
			_decoratedHandler = decoratedHandler;
			_logger = logger;
		}

		public void Handle(TCommand command)
		{
			_logger.Info(command);

			_decoratedHandler.Handle(command);
		}
	}
}