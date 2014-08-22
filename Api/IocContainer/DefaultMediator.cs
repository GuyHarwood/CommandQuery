using System;
using System.Web.Http;
using Core;

namespace Api.IocContainer
{
	public sealed class DefaultMediator : IMediator
	{
		public TResult Execute<TResult>(Query<TResult> query)
		{
			Type handlerType = typeof (IQueryHandler<,>)
				.MakeGenericType(query.GetType(), typeof (TResult));

			dynamic handler = GlobalConfiguration.Configuration.DependencyResolver.BeginScope().GetService(handlerType);
				//DependencyResolver.Current.GetService(handlerType);

			return handler.Handle((dynamic) query);
		}

		public void Dispatch<TCommand>(TCommand command) where TCommand : Command
		{
			Type handlerType = typeof (ICommandHandler<TCommand>);
			//the MVC dependency resolver points at the underlying IOC container
			dynamic handler = GlobalConfiguration.Configuration.DependencyResolver.BeginScope().GetService(handlerType);
			handler.Handle((dynamic) command);
		}
	}
}