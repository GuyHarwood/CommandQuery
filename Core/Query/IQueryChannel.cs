namespace Core.Query
{
	public interface IQueryChannel
	{
		TResult Execute<TResult>(Query<TResult> query);
	}
}