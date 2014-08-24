using Core.Command;
using log4net;

namespace Core.Extensions.Auditing
{
	public class CommandAuditor<TCommand> : ICommandHandler<TCommand> where TCommand : CommandBase
	{
		private readonly ICommandHandler<TCommand> _decoratedHandler;
		private readonly ILog _auditor;

		public CommandAuditor(ICommandHandler<TCommand> decoratedHandler, ILog auditor)
		{
			_decoratedHandler = decoratedHandler;
			_auditor = auditor;
		}

		public void Handle(TCommand command)
		{
			_auditor.Info(command);
			_decoratedHandler.Handle(command);
		}
	}
}