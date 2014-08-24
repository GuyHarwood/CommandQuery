using System;
using System.Configuration;
using System.Data.Entity;
using Api.IocContainer;
using Core;
using Core.Command;
using Core.Extensions.Auditing;
using Core.Extensions.Caching;
using Core.Query;
using Data;
using Domain.Contacts.Commands;
using Domain.Contacts.Queries;
using Domain.Data.Contracts;
using Domain.Data.Model;
using SimpleInjector;
using SimpleInjector.Extensions;

namespace Api
{
	public class BindingConfig
	{
		public static void Bind(Container container)
		{
			//inject IPrincipal
//            container.Register(() =>
//            {
//                if (HttpContext.Current == null || HttpContext.Current.User == null)
//                    return (null as IPrincipal);
//
//                return HttpContext.Current.User;
//            });

			//refer to assemblies containing handlers
			container.RegisterManyForOpenGeneric(typeof (IQueryHandler<,>), new[]
			{
				typeof (CreateContactCommand).Assembly
			});

			container.RegisterManyForOpenGeneric(typeof (ICommandHandler<>), new[]
			{
				typeof (CreateContactCommand).Assembly
			});

			//register repository implementations (you would do this by convention normally)
			container.RegisterWebApiRequest<ICreateAContact, ContactCreator>();

			container.RegisterWebApiRequest<IReadOnlyRepository>(() =>
			{
				//you may wish to get this from the container, but it could be in scope with a consumer that writes
				var context = new ContactAppEntities();
				context.Configuration.AutoDetectChangesEnabled = false;
				return new ReadOnlyRepository(context);
			});

			container.RegisterWebApiRequest<ContactAppEntities>();
			container.RegisterWebApiRequest<EfUnitOfWork>();
			container.Register<DbContext>(container.GetInstance<ContactAppEntities>);
			container.Register<IUnitOfWork>(container.GetInstance<EfUnitOfWork>);
			container.RegisterDecorator(typeof (ICommandHandler<>),
				typeof (EfUnitOfWorkTransactionCommandHandlerDecorator<>));
			container.RegisterDecorator(typeof (ICommandHandler<>), typeof (PostCommitCommandHandlerDecorator<>));

			container.RegisterWebApiRequest<PostCommitRegistrar>();
			container.Register<IPostCommitRegistrar>(container.GetInstance<PostCommitRegistrar>);

			//TODO auditing should log via a bus or separate asynchronous repository, not to a logger
			bool traceEnabled;
			bool.TryParse(ConfigurationManager.AppSettings["Audit:Enabled"], out traceEnabled);
			if (traceEnabled)
			{
				container.RegisterDecorator(typeof (ICommandHandler<>), typeof (CommandAuditor<>));
				container.RegisterDecorator(typeof (IQueryHandler<,>), typeof (QueryAuditor<,>));
			}
			//TODO no need, this is config based
			//            else
			//            {
			//                container.RegisterSingle<ILog, NullLogger>();
			//            }

			container.RegisterDecorator(typeof (IQueryHandler<,>), typeof (CacheablePerUserQueryHandler<,>));
			container.RegisterDecorator(typeof (ICommandHandler<>), typeof (CommandValidator<>));
			container.RegisterDecorator(typeof (IQueryHandler<,>), typeof (QueryValidator<,>));

			container.RegisterWebApiRequest<IMediator, WebApiMediator>();

			/* we are using data annotations for validation, so we must inform simple injector
             * to use this container when IServiceProvider is requested for validation */
			container.RegisterWebApiRequest<IServiceProvider>(() => container);
		}
	}
}