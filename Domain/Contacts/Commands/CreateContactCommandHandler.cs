using Core;

namespace Domain.Contacts.Commands
{
    public class CreateContactCommandHandler : ICommandHandler<CreateContactCommand>
    {
        private readonly ICreateAContact _contactCreator;

        public CreateContactCommandHandler(ICreateAContact contactCreator)
        {
            this._contactCreator = contactCreator;
        }

        public void Handle(CreateContactCommand command)
        {
            this._contactCreator.Create(command.Name);
        }
    }
}