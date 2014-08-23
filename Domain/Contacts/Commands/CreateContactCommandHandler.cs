using Core;
using Core.Command;

namespace Domain.Contacts.Commands
{
	public class CreateContactCommandHandler : ICommandHandler<CreateContactCommand>
	{
		private readonly ICreateAContact _contactCreator;

		public CreateContactCommandHandler(ICreateAContact contactCreator)
		{
			_contactCreator = contactCreator;
		}

		public void Handle(CreateContactCommand command)
		{
			_contactCreator.Create(command.Name);
		}
	}
}