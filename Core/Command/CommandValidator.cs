using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Command
{
	public class CommandValidator<TCommand> : ICommandHandler<TCommand> where TCommand : CommandBase
	{
		private readonly IServiceProvider _container;
		private readonly ICommandHandler<TCommand> _handler;

		public CommandValidator(ICommandHandler<TCommand> handler, IServiceProvider container)
		{
			_handler = handler;
			_container = container;
		}

		public void Handle(TCommand command)
		{
			var context = new ValidationContext(command,
				_container, null);

			Validator.ValidateObject(command, context, true);
			if (command.Validate() == false)
			{
				throw new ValidationException("Command is not valid");
			}
			_handler.Handle(command);
		}
	}
}