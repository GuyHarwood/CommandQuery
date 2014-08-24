namespace Core.Query
{
	public interface IQueryHandler<in TQuery, out TResult> where TQuery : QueryBase<TResult>
	{
		TResult Handle(TQuery query);
	}
}