using System.Security.Principal;

namespace Core
{
    public class CacheablePerUserQueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery : Query<TResult>, ICacheablePerUser
    {
        private readonly IQueryHandler<TQuery, TResult> _queryHandlerToWrap;
        private readonly IPrincipal _principal;
        private readonly ICache _cache;

        public CacheablePerUserQueryHandler(IQueryHandler<TQuery, TResult> queryHandlerToWrap, IPrincipal principal, ICache cache)
        {
            this._queryHandlerToWrap = queryHandlerToWrap;
            this._principal = principal;
            this._cache = cache;
        }

        public TResult Handle(TQuery query)
        {
            var userKey = string.Format("{0}-User:{1}", query.Key, this._principal.Identity.Name);
            var cachedResult = this._cache.Get<TResult>(userKey);
            if (cachedResult != null)
                return cachedResult;

            var resultToCache = this._queryHandlerToWrap.Handle(query);
            this._cache.Add(userKey, resultToCache, query.Duration);

            return resultToCache;
        }
    }
}