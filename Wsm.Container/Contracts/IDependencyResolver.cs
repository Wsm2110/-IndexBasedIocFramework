using System;

namespace WSM.Container.Contracts
{
    /// <summary>
    /// Resolves dependency in a late bind manner
    /// </summary>
    public interface IDependencyResolver
    {
        /// <summary>
        /// Resolves the return type of a containerentry in a late bind manner.
        /// </summary>
        /// <param name="entry">The entry.</param>
        /// <returns></returns>
        Func<object> Resolve(IContainerEntry entry);

        /// <summary>
        /// Adds dependency to resolver.
        /// </summary>
        /// <param name="entry">The entry.</param>
        /// <param name="index">The index.</param>
        void Add(IContainerEntry entry, int index);

        /// <summary>
        /// Gets the dependency.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        IContainerEntry Get(int index);

        /// <summary>
        /// returns all registered components
        /// </summary>
        /// <returns></returns>
        IContainerEntry[] All();

    }
}
