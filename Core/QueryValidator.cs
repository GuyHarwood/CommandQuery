using System;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class QueryValidator<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : Query<TResult>
    {
        private readonly IQueryHandler<TQuery, TResult> _decoratedQuery;
        private readonly IServiceProvider _container;

        public QueryValidator(IQueryHandler<TQuery, TResult> decoratedQuery, IServiceProvider container)
        {
            this._decoratedQuery = decoratedQuery;
            this._container = container;
        }

        public TResult Handle(TQuery query)
        {
            var context = new ValidationContext(query, this._container, null);

            Validator.ValidateObject(query, context, true);
            if (query.Validate() == false)
            {
                throw new InvalidOperationException("Query is not valid");
            }
            return this._decoratedQuery.Handle(query);
        }
    }
}