using System;

namespace Data
{
    /// <summary>
    /// Post unit of work commit hook
    /// </summary>
    public interface IPostCommitRegistrar
    {
        /// <summary>
        /// Implement your post commit operations within this method
        /// </summary>
        event Action UnitOfWorkComplete;
    }
}