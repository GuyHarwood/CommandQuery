using System;

namespace Core.Query
{
	public interface ICacheablePerUser
	{
		string Key { get; }
		TimeSpan Duration { get; }
	}
}