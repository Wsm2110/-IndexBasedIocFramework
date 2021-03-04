using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using WSM.Container.Contracts;

namespace WSM.Container
{
    [System.Diagnostics.DebuggerDisplay("RegisteredType:{RegisteredType.Name}, ReturnType: {ReturnType.Name} ")]
    public class ContainerEntry : IContainerEntry
    {
        #region Properties

        /// <summary>
        /// Type which will be constructed
        /// </summary>
        /// <value>
        /// The registeredType.
        /// </value>
        public Type ReturnType { get; set; }

        /// <summary>
        /// Gets the lifetime(transient, or singelton)
        /// </summary>
        /// <value>
        /// The lifetime.
        /// </value>
        public Lifetime Lifetime { get; set; }

        /// <summary>
        /// Type used while registering a Type
        /// </summary>
        /// <value>
        /// The registeredType.
        /// </value>
        public Type RegisteredType { get; set; }

        /// <summary>
        /// returns a delegate which can be invoked whenever needed, will return a newly created registration type
        /// </summary>
        public Func<object> Value
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the constructor information.
        /// </summary>
        /// <value>
        /// The constructor information.
        /// </value>
        public ConstructorInfo ConstructorInfo { get; set; }

        public int Index { get; set; }

        public object ValueObject { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerEntry" /> class.
        /// </summary>
        /// <param name="registeredType">Type of the registered.</param>
        /// <param name="returnType">Type of the return.</param>
        /// <param name="lifetime">The lifetime.</param>
        /// <exception cref="ArgumentNullException">options</exception>
        public ContainerEntry(Type registeredType, Type returnType, Lifetime lifetime, int index)
        {
            Index = index;
            RegisteredType = registeredType;
            ReturnType = returnType;
            Lifetime = lifetime;

            if (returnType != null)
            {
                //preffered constructor
                ConstructorInfo = returnType.GetConstructors().OrderByDescending(i => i.GetParameters().Length).FirstOrDefault() ??
                                  //default constructor
                                  returnType.GetConstructors().FirstOrDefault() ??
                                  // private constructor
                                  returnType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault();
            }
        }

        #endregion
    }
}
