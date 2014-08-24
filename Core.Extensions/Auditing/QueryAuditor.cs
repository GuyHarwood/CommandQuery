
using Core.Query;
using log4net;

namespace Core.Extensions.Auditing
{
	/// <summary>
	/// Crude example of message auditing to log source
	/// </summary>
	/// <typeparam name="TQuery"></typeparam>
	/// <typeparam name="TResult"></typeparam>
	public class QueryAuditor<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : QueryBase<TResult>
	{
		private readonly IQueryHandler<TQuery, TResult> _decoratedHandler;
		private readonly ILog _auditor;

		public QueryAuditor(IQueryHandler<TQuery, TResult> decoratedHandler, ILog auditor)
		{
			_decoratedHandler = decoratedHandler;
			_auditor = auditor;
		}

		public TResult Handle(TQuery query)
		{
			_auditor.Info(query);
			return _decoratedHandler.Handle(query);
		}
	}

}