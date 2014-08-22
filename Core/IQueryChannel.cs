namespace Core
{
	public interface IQueryChannel
	{
		TResult Execute<TResult>(Query<TResult> query);
	}
}