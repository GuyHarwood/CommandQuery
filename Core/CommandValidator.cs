using System;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class CommandValidator<TCommand> : ICommandHandler<TCommand> where TCommand : Command
    {
        private readonly ICommandHandler<TCommand> _handler;
        private readonly IServiceProvider _container;

        public CommandValidator(ICommandHandler<TCommand> handler, IServiceProvider container)
        {
            this._handler = handler;
            this._container = container;
        }

        public void Handle(TCommand command)
        {
            var context = new ValidationContext(command,
                this._container, null);

            Validator.ValidateObject(command, context, true);
            if (command.Validate() == false)
            {
                throw new ValidationException("Command is not valid");
            }
            this._handler.Handle(command);
        }
    }
}