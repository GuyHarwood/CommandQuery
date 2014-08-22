using log4net;

namespace Core
{
    public class CommandAuditor<TCommand> : ICommandHandler<TCommand> where TCommand : Command
    {
        private readonly ICommandHandler<TCommand> _decoratedHandler;
        private readonly ILog _logger;

        public CommandAuditor(ICommandHandler<TCommand> decoratedHandler, ILog logger)
        {
            this._decoratedHandler = decoratedHandler;
            this._logger = logger;
        }

        public void Handle(TCommand command)
        {
            this._logger.Info(command);

            this._decoratedHandler.Handle(command);
        }
    }
}