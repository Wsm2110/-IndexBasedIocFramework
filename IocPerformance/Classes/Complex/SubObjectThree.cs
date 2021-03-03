using System;
using System.ComponentModel.Composition;


namespace IocPerformance.Classes.Complex
{
    public interface ISubObjectThree
    {
    }

    public class SubObjectThree : ISubObjectThree
    {
        
        
        
        public SubObjectThree(IThirdService thirdService)
        {
            if (thirdService == null)
            {
                throw new ArgumentNullException(nameof(thirdService));
            }
        }

        protected SubObjectThree()
        {
        }
    }
}
