using System.Threading.Tasks;
using Core.Command;
using log4net;

namespace Core.Extensions.Auditing
{
	/// <summary>
	/// Crude example of auditing by interception with log4net source
	/// </summary>
	/// <typeparam name="TCommand"></typeparam>
	public class CommandAuditorAsync<TCommand> : ICommandHandlerAsync<TCommand> where TCommand : CommandBase
	{
		private readonly ICommandHandlerAsync<TCommand> _decoratedHandler;
		private readonly ILog _auditor;

		public CommandAuditorAsync(ICommandHandlerAsync<TCommand> decoratedHandler, ILog auditor)
		{
			_decoratedHandler = decoratedHandler;
			_auditor = auditor;
		}

		public async Task HandleAsync(TCommand command)
		{
			_auditor.Info(command);
			await _decoratedHandler.HandleAsync(command);
		}
	}
}