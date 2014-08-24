using System.Security.Principal;
using Core.Query;

namespace Core.Extensions.Caching
{
	public class CacheablePerUserQueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult>
		where TQuery : QueryBase<TResult>, ICacheablePerUser
	{
		private readonly ICache _cache;
		private readonly IPrincipal _principal;
		private readonly IQueryHandler<TQuery, TResult> _queryHandlerToWrap;

		public CacheablePerUserQueryHandler(IQueryHandler<TQuery, TResult> queryHandlerToWrap, IPrincipal principal,
			ICache cache)
		{
			_queryHandlerToWrap = queryHandlerToWrap;
			_principal = principal;
			_cache = cache;
		}

		public TResult Handle(TQuery query)
		{
			string userKey = string.Format("{0}-User:{1}", query.Key, _principal.Identity.Name);
			var cachedResult = _cache.Get<TResult>(userKey);
			if (cachedResult != null)
				return cachedResult;

			TResult resultToCache = _queryHandlerToWrap.Handle(query);
			_cache.Add(userKey, resultToCache, query.Duration);

			return resultToCache;
		}
	}
}