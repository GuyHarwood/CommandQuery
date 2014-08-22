using System;

namespace Data
{
    public sealed class PostCommitRegistrar : IPostCommitRegistrar
    {
        public event Action UnitOfWorkComplete = () => { };

        public void ExecuteActions()
        {
            this.UnitOfWorkComplete();
        }

        public void Reset()
        {
            this.UnitOfWorkComplete = () => { };
        }
    }
}