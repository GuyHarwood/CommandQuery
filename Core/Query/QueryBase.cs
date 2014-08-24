namespace Core.Query
{
	public abstract class QueryBase<TResult>
	{
		/// <summary>
		///     Custom validation extensibility point.
		///     Declarative validation (DataAnnotations) should be the first choice, and this method should only be used when the
		///     validation is sufficiently complex that DataAnnotations will not suffice.
		/// </summary>
		/// <returns></returns>
		public virtual bool Validate()
		{
			return true;
		}
	}
}