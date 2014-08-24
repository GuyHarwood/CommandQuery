using Core;
using Core.Command;

namespace Data
{
	public class EfUnitOfWorkTransactionCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
		where TCommand : CommandBase
	{
		private readonly ICommandHandler<TCommand> _decorated;
		private readonly EfUnitOfWork _unitOfWork;

		public EfUnitOfWorkTransactionCommandHandlerDecorator(ICommandHandler<TCommand> decorated, EfUnitOfWork unitOfWork)
		{
			_decorated = decorated;
			_unitOfWork = unitOfWork;
		}

		public void Handle(TCommand command)
		{
			_decorated.Handle(command);
			_unitOfWork.Commit();
		}
	}
}