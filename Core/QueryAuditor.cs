using log4net;

namespace Core
{
	public class QueryAuditor<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : Query<TResult>
	{
		private readonly IQueryHandler<TQuery, TResult> _decoratedHandler;
		private readonly ILog _logger;

		public QueryAuditor(IQueryHandler<TQuery, TResult> decoratedHandler, ILog logger)
		{
			_decoratedHandler = decoratedHandler;
			_logger = logger;
		}

		public TResult Handle(TQuery query)
		{
			_logger.Info(query);

			return _decoratedHandler.Handle(query);
		}
	}
}