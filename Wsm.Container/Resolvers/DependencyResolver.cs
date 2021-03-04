using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using FastExpressionCompiler;
using WSM.Container.Contracts;

namespace WSM.Container.Resolvers
{

    public class DependencyResolver
    {
        private readonly FieldInfo[] _fields;
        private readonly object[] _singletonIndex;

        #region Fields

        protected readonly IContainerEntry[] _entries;

        #endregion

        #region constructor

        public DependencyResolver(FieldInfo[] fields)
        {
            _fields = fields;
            _entries = new IContainerEntry[fields.Length];
            _singletonIndex = new object[fields.Length];
          
        }

        #endregion

        #region Methods

        public void Add(IContainerEntry entry, int index)
        {
            _entries[index] = entry;
        }

        /// <summary>
        /// Gets the dependency by index
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public object Get(int index)
        {
            var result = _singletonIndex[index];
            if (result != null)
            {
                return result;
            }

            var entry = _entries[index];
            return entry.Value();
        }

        public IContainerEntry GetEntry(int index)
        {
            return _entries[index];
        }

        /// <summary>
        /// Returns all registered entries
        /// </summary>
        /// <returns></returns>
        public IContainerEntry[] All()
        {
            return _entries;
        }
        
        /// <summary>
        /// Resolves the constructor
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Are you mad!!!</exception>
        /// <exception cref="System.InvalidOperationException">Are you mad!!! Unable to find constructor {itemType}</exception>
        public Func<object> Resolve(IContainerEntry entry)
        {
            List<Expression> paramExpressions = null;
            var parameters = entry.ConstructorInfo.GetParameters();
            if (parameters.Length > 0)
            {
                paramExpressions = entry.ConstructorInfo.GetParameters().Select(param =>
               {
                   var indexFi = _fields.FirstOrDefault(i => i.Name.Equals($"Get{param.Name}", StringComparison.CurrentCultureIgnoreCase));
                   if (indexFi == null)
                   {
                       throw new InvalidOperationException($"Found {param.Name}, expected 'Get{param.Name}'");
                   }

                   var index = (int)indexFi.GetValue(null);
                   var result = GetEntry(index);

                   if (result.Lifetime == Lifetime.Singleton)
                   {
                       return Expression.Convert(Expression.ArrayIndex(Expression.Constant(_singletonIndex), Expression.Constant(index)), param.ParameterType);
                   }

                   if (result != null)
                   {
                       return (Expression)Expression.Invoke(Expression.Constant(result.Value));
                   }

                   return null;

               }).ToList();
            }

            var creator = paramExpressions == null
                ? Expression.New(entry.ConstructorInfo)
                : Expression.New(entry.ConstructorInfo, paramExpressions);

            return (Func<object>)Expression.Lambda(creator).CompileFast();
        }

        #endregion

        public void AddSingleton(object entryValue, int index)
        {
            _singletonIndex[index] = entryValue;
        }
    }
}
