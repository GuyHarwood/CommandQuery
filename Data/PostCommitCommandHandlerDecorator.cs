
using Core;

namespace Data
{
    public sealed class PostCommitCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : Command
    {
        private readonly ICommandHandler<TCommand> _decorated;
        private readonly PostCommitRegistrar _registrar;

        public PostCommitCommandHandlerDecorator(ICommandHandler<TCommand> decorated, PostCommitRegistrar registrar)
        {
            this._decorated = decorated;
            this._registrar = registrar;
        }

        public void Handle(TCommand command)
        {
            try
            {
                this._decorated.Handle(command);
                this._registrar.ExecuteActions();
            }
            finally
            {
                this._registrar.Reset();
            }
        }
    }
}