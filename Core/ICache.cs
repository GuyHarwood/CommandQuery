using System;

namespace Core
{
	public interface ICache
	{
		void Add(string key, object itemToCache, TimeSpan duration);
		TCached Get<TCached>(string key);
		TCached Get<TCached>(string key, CacheRetrievalOption retrievalOption);
	}
}