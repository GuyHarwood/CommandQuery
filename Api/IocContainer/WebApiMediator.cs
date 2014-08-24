using System;
using System.Threading.Tasks;
using Core;
using Core.Command;
using Core.Query;
using SimpleInjector;

namespace Api.IocContainer
{
	public sealed class WebApiMediator : IMediator
	{
		private readonly Container _container;

		public WebApiMediator(Container container)
		{
			_container = container;
		}

		public TResult Execute<TResult>(QueryBase<TResult> queryBase)
		{
			Type handlerType = typeof (IQueryHandler<,>).MakeGenericType(queryBase.GetType(), typeof (TResult));
			dynamic handler = _container.GetInstance(handlerType);
			return handler.Handle((dynamic) queryBase);
		}

		public void Dispatch<TCommand>(TCommand command) where TCommand : CommandBase
		{
			var handler = _container.GetInstance<ICommandHandler<TCommand>>();
			handler.Handle(command);
		}

		public async Task DispatchAsync<TCommand>(TCommand command) where TCommand : CommandBase
		{
			var handler = _container.GetInstance<ICommandHandlerAsync<TCommand>>();
			await handler.HandleAsync(command);
		}
	}
}