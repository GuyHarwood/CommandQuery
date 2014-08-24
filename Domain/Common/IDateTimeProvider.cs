using System;

namespace Domain.Common
{
	public interface IDateTimeProvider
	{
		DateTime Now { get; set; }
	}
}