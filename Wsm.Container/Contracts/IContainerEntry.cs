using System;
using System.Collections.Generic;
using System.Reflection;

namespace WSM.Container.Contracts
{
    /// <summary>
    /// ContainerEntry is used as a storage class, which stores constructor and field delegates
    /// </summary>
    public interface IContainerEntry
    {
        /// <summary>
        /// Gets or sets the Implementation. will acts as a key
        /// </summary>
        /// <value>
        /// The interface.
        /// </value>
        Type RegisteredType { get; set; }

        /// <summary>
        /// Gets or sets the lifetime.
        /// </summary>
        /// <value>
        /// The lifetime.
        /// </value>
        Lifetime Lifetime { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        Type ReturnType { get; set; }

        /// <summary>
        /// returns a delegate which can be invoked whenever needed, will return a newly created type
        /// </summary>
        /// <returns></returns>
        Func<object> Value { get; set; }

        /// <summary>
        /// Gets or sets the constructor information.
        /// </summary>
        /// <value>
        /// The constructor information.
        /// </value>
        ConstructorInfo ConstructorInfo { get; set; }


        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        int Index { get; set; }

        object ValueObject { get; set; }
    }
}
