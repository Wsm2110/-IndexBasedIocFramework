using System;
using System.Linq.Expressions;

namespace WSM.Container.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IContainer : IDisposable
    {
        /// <summary>
        /// Registers the specified interface.
        /// </summary>
        /// <param name="interface">The interface.</param>
        /// <param name="implementation">The implementation.</param>
        /// <returns></returns>
        void Register(Type @interface, Type implementation);

        /// <summary>
        /// Registers the specified interface.
        /// </summary>
        /// <param name="interface">The interface.</param>
        /// <param name="implementation">The implementation.</param>
        /// <param name="lifetime">The lifetime.</param>
        void Register(Type @interface, Type implementation, Lifetime lifetime);

        /// <summary>
        /// Registers the specified interface.
        /// </summary>
        /// <param name="interface">The interface.</param>
        /// <param name="implementation">The implementation.</param>
        /// <param name="key">The key.</param>
        void Register(Type @interface, Type implementation, string key);

        /// <summary>
        /// Registers the specified interface.
        /// </summary>
        /// <param name="interface">The interface.</param>
        /// <param name="implementation">The implementation.</param>
        /// <param name="key">The key.</param>
        /// <param name="lifetime">The lifetime.</param>
        void Register(Type @interface, Type implementation, Lifetime lifetime, string key);

        /// <summary>
        /// Registers the specified key.
        /// </summary>
        /// <typeparam name="TRegistrationType">The type of the registration type.</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="lifetime">The lifetime.</param>
        void Register<TRegistrationType>(Lifetime lifetime, string key) where TRegistrationType : class;

        /// <summary>
        /// Registers the specified key.
        /// </summary>
        /// <typeparam name="TRegistrationType">The type of the registration type.</typeparam>
        /// <param name="key">The key.</param>
        void Register<TRegistrationType>(string key) where TRegistrationType : class;

        /// <summary>
        /// Registers the specified key.
        /// </summary>
        /// <typeparam name="TRegistrationType">The type of the registration type.</typeparam>
        /// <param name="lifetime">The lifetime.</param>
        void Register<TRegistrationType>(Lifetime lifetime) where TRegistrationType : class;

        /// <summary>
        /// Registers the specified key.
        /// </summary>
        /// <typeparam name="TRegistrationType">The type of the registration type.</typeparam>
        void Register<TRegistrationType>() where TRegistrationType : class;

        /// <summary>
        /// Registers this instance.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <returns></returns>
        void Register<TInterface, TImplementation>() where TImplementation : TInterface;

        void Register(Type @interface, Type implementation, Lifetime lifetime, string key, uint index);

        /// <summary>
        /// Registers this instance.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <returns></returns>
        void Register<TInterface, TImplementation>(string key) where TImplementation : TInterface;

        /// <summary>
        /// Registers this instance.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <returns></returns>
        void Register<TInterface, TImplementation>(Lifetime lifetime) where TImplementation : TInterface;

        /// <summary>
        /// Registers this instance.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <returns></returns>
        void Register<TInterface, TImplementation>(Lifetime lifetime, string key) where TImplementation : TInterface;

        /// <summary>
        /// Registers the specified object which has already been constructed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        void Register<T>(Expression<Func<T>> obj) where T : class;

        /// <summary>
        /// Registers the specified object which has already been constructed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <param name="lifetime">The lifetime.</param>
        void Register<T>(Expression<Func<T>> obj, Lifetime lifetime) where T : class;

        /// <summary>
        /// Registers the specified object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <param name="key">The key.</param>
        void Register<T>(Expression<Func<T>> obj, string key) where T : class;

        /// <summary>
        /// Registers the specified object which has already been constructed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <param name="key">The key.</param>
        /// <param name="lifetime">The lifetime.</param>
        void Register<T>(Expression<Func<T>> obj, Lifetime lifetime, string key) where T : class;

        /// <summary>
        /// Registers the specified container. Resolve params by container
        /// </summary>
        /// <returns></returns>
        void Register<T>(Expression<Func<IContainer, object>> obj);

        /// <summary>
        /// Registers the specified container. Resolve params by container
        /// </summary>
        /// <returns></returns>
        void Register<T>(Expression<Func<IContainer, object>> obj, Lifetime lifetime, string key);

        /// <summary>
        /// Registers the specified container. Resolve params by container
        /// </summary>
        /// <returns></returns>
        void Register<T>(Expression<Func<IContainer, object>> obj, Lifetime lifetime);

        /// <summary>
        /// Registers the specified container. Resolve params by container
        /// </summary>
        /// <returns></returns>
        void Register<T>(Expression<Func<IContainer, object>> obj, string key);

        /// <summary>
        /// Resolves the specified type.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        object Resolve(uint index);

        T Resolve<T>(uint index);

    }
}