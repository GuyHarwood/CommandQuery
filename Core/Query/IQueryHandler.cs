namespace Core.Query
{
	public interface IQueryHandler<in TQuery, out TResult> where TQuery : Query<TResult>
	{
		TResult Handle(TQuery query);
	}
}