
using Core;

namespace Data
{
    public class EfUnitOfWorkTransactionCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : Command
    {
        private readonly ICommandHandler<TCommand> _decorated;
        private readonly EfUnitOfWork _unitOfWork;

        public EfUnitOfWorkTransactionCommandHandlerDecorator(ICommandHandler<TCommand> decorated, EfUnitOfWork unitOfWork)
        {
            this._decorated = decorated;
            this._unitOfWork = unitOfWork;
        }

        public void Handle(TCommand command)
        {
            this._decorated.Handle(command);
            this._unitOfWork.Commit();
        }
    }
}