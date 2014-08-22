using System;
using System.ComponentModel.DataAnnotations;

namespace Core
{
	public class QueryValidator<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : Query<TResult>
	{
		private readonly IServiceProvider _container;
		private readonly IQueryHandler<TQuery, TResult> _decoratedQuery;

		public QueryValidator(IQueryHandler<TQuery, TResult> decoratedQuery, IServiceProvider container)
		{
			_decoratedQuery = decoratedQuery;
			_container = container;
		}

		public TResult Handle(TQuery query)
		{
			var context = new ValidationContext(query, _container, null);

			Validator.ValidateObject(query, context, true);
			if (query.Validate() == false)
			{
				throw new InvalidOperationException("Query is not valid");
			}
			return _decoratedQuery.Handle(query);
		}
	}
}