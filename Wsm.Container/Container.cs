using System;
using System.Linq;
using WSM.Container.Contracts;
using WSM.Container.Resolvers;

namespace WSM.Container
{
    public class Container
    {
        #region Fields

        private readonly DependencyResolver _dependencyResolver;

        #endregion

        #region Constructor 

        /// <summary>
        /// Initializes a new instance of the <see cref="Container" /> class.
        /// </summary>
        public Container()
        {
            var index = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).FirstOrDefault(p => p.Name.Equals("Index", StringComparison.CurrentCultureIgnoreCase));
            if (index == null)
            {
                throw new InvalidOperationException("Unable to find static type Index");
            }
            var fields = index.GetFields();
            _dependencyResolver = new DependencyResolver(fields);
        }

        #endregion

        #region Registration Methods


        public void Register(Type @interface, Type implementation, int index)
        {
            var entry = new ContainerEntry(@interface, implementation, Lifetime.Transient, index);
            _dependencyResolver.Add(entry, index);
        }

        public void Register(Type @interface, Type implementation, Lifetime lifetime, int index)
        {
            var entry = new ContainerEntry(@interface, implementation, lifetime, index);
            _dependencyResolver.Add(entry, index);
        }

        public void Register<TRegistrationType>(int index) where TRegistrationType : class
        {
            Register<TRegistrationType>(Lifetime.Transient, index);
        }

        /// <summary>
        /// Registers a concrete type with Lifetime scope and key
        /// </summary>
        /// <typeparam name="TRegistrationType">The type of the registration type.</typeparam>
        /// <param name="lifetime">The lifetime.</param>
        /// <param name="index">The index.</param>
        public void Register<TRegistrationType>(Lifetime lifetime, int index) where TRegistrationType : class
        {
            var entry = new ContainerEntry(typeof(TRegistrationType), typeof(TRegistrationType), lifetime, index);
            _dependencyResolver.Add(entry, index);
        }

        public void Register<TInterface, TImplementation>(int index) where TImplementation : TInterface
        {
            Register<TInterface, TImplementation>(Lifetime.Transient, index);
        }

        /// <summary>
        /// Registers an implementation type for the specified interface
        /// </summary>
        /// <typeparam name="TInterface">RegisteredType to register</typeparam>
        /// <typeparam name="TImplementation">Implementing type</typeparam>
        /// <returns>IRegisteredType object</returns>
        public void Register<TInterface, TImplementation>(Lifetime lifetime, int index) where TImplementation : TInterface
        {
            var entry = new ContainerEntry(typeof(TInterface), typeof(TImplementation), lifetime, index);
            _dependencyResolver.Add(entry, index);
        }

        #endregion

        #region Methods

        public T Resolve<T>(int index)
        {
            return (T)_dependencyResolver.Get(index);
        }

        /// <summary>
        /// Returns an implementation of the specified interface
        /// </summary>
        /// <returns>Object implementing the interface</returns>
        public object Resolve(int index)
        {
            return _dependencyResolver.Get(index);
        }

        /// <summary>
        /// Wires all components together
        /// </summary>
        public void Build()
        {
            var entries = _dependencyResolver.All();
            foreach (var entry in entries)
            {
                if (entry != null)
                {
                    entry.Value = _dependencyResolver.Resolve(entry);
                }
            }

            foreach (var entry in entries)
            {
                if (entry != null)
                {
                    if (entry.Lifetime == Lifetime.Singleton)
                    {
                        _dependencyResolver.AddSingleton(entry.Value(), entry.Index);
                    }
                }
            }
        }

        #endregion

        #region IDisposable Support


        #endregion

    }
}
