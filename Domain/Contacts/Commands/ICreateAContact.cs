namespace Domain.Contacts.Commands
{
    //data layer contracts remain bundled with the types that consume them
    public interface ICreateAContact
    {
        void Create(string name);
    }
}