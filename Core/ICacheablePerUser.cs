using System;

namespace Core
{
    public interface ICacheablePerUser
    {
        string Key { get; }
        TimeSpan Duration { get; }
    }
}