namespace Core
{
	public interface IMediator
	{
		TResult Execute<TResult>(Query<TResult> query);
		void Dispatch<TCommand>(TCommand command) where TCommand : Command;
	}
}