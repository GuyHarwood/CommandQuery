using System;
using System.Threading.Tasks;
using Core;
using Core.Command;
using Core.Query;
using SimpleInjector;

namespace Api.IocContainer
{
	public sealed class DefaultMediator : IMediator
	{
		private readonly Container _container;

		public DefaultMediator(Container container)
		{
			_container = container;
		}

		public TResult Execute<TResult>(Query<TResult> query)
		{
			Type handlerType = typeof (IQueryHandler<,>).MakeGenericType(query.GetType(), typeof (TResult));
			dynamic handler = _container.GetInstance(handlerType);
			return handler.Handle((dynamic) query);
		}

		public void Dispatch<TCommand>(TCommand command) where TCommand : Command
		{
			var handler = _container.GetInstance<ICommandHandler<TCommand>>();
			handler.Handle(command);
		}

		public async Task DispatchAsync<TCommand>(TCommand command) where TCommand : Command
		{
			var handler = _container.GetInstance<IAsyncCommandHandler<TCommand>>();
			await handler.Handle(command);
		}
	}
}