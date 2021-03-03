using System;
using System.ComponentModel.Composition;


namespace IocPerformance.Classes.Complex
{
    public interface ISubObjectTwo
    {
    }


    public class SubObjectTwo : ISubObjectTwo
    {
        
        
        
        public SubObjectTwo(ISecondService secondService)
        {
            if (secondService == null)
            {
                throw new ArgumentNullException(nameof(secondService));
            }
        }

        protected SubObjectTwo()
        {
        }
    }
}
