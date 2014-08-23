using System;
using System.Web.Http;
using Core;
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
			var handlerType =
			typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

			dynamic handler = _container.GetInstance(handlerType);

			return handler.Handle((dynamic)query);
		}

		public void Dispatch<TCommand>(TCommand command) where TCommand : Command
		{
			var handler = _container.GetInstance<ICommandHandler<TCommand>>();
			handler.Handle(command);
		}
	}
}