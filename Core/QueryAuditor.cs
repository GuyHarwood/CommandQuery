using System.Runtime.Caching;
using log4net;

namespace Core
{
    public class QueryAuditor<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : Query<TResult>
    {
        private readonly IQueryHandler<TQuery, TResult> _decoratedHandler;
        private readonly ILog _logger;

        public QueryAuditor(IQueryHandler<TQuery, TResult> decoratedHandler, ILog logger)
        {
            this._decoratedHandler = decoratedHandler;
            this._logger = logger;
        }

        public TResult Handle(TQuery query)
        {
            this._logger.Info(query);

            return this._decoratedHandler.Handle(query);
        }
    }
}