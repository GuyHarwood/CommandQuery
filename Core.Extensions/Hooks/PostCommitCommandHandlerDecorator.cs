﻿using Core.Command;

namespace Core.Extensions.Hooks
{
	public sealed class PostCommitCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : CommandBase
	{
		private readonly ICommandHandler<TCommand> _decorated;
		private readonly PostCommitRegistrar _registrar;

		public PostCommitCommandHandlerDecorator(ICommandHandler<TCommand> decorated, PostCommitRegistrar registrar)
		{
			_decorated = decorated;
			_registrar = registrar;
		}

		public void Handle(TCommand command)
		{
			try
			{
				_decorated.Handle(command);
				_registrar.ExecuteActions();
			}
			finally
			{
				_registrar.Reset();
			}
		}
	}
}