using IocPerformance.Classes.Generics;
using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Generics
{
 
    public class GenericExport<T> : IGenericInterface<T>
    {
        public T Value { get; set; }
    }
}
