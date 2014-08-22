using System;
using System.Web.Mvc;
using Core;

namespace Api.IocContainer
{
    public sealed class DefaultMediator : IMediator
    {
        public TResult Execute<TResult>(Query<TResult> query)
        {
            Type handlerType = typeof (IQueryHandler<,>)
                .MakeGenericType(query.GetType(), typeof (TResult));

            dynamic handler = DependencyResolver.Current.GetService(handlerType);

            return handler.Handle((dynamic) query);
        }

        public void Dispatch<TCommand>(TCommand command) where TCommand : Command
        {
            //the MVC dependency resolver points at the underlying IOC container
            var handler = DependencyResolver.Current.GetService<ICommandHandler<TCommand>>();
            handler.Handle(command);
        }
    }
}