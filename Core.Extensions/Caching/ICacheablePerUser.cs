using System;

namespace Core.Extensions.Caching
{
	public interface ICacheablePerUser
	{
		string Key { get; }
		TimeSpan Duration { get; }
	}
}