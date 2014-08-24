namespace Core.Query
{
	public interface IQueryChannel
	{
		TResult Execute<TResult>(QueryBase<TResult> queryBase);
	}
}