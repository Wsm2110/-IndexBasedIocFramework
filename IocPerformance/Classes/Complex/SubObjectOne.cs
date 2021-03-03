﻿using System;
using System.ComponentModel.Composition;


namespace IocPerformance.Classes.Complex
{
    public interface ISubObjectOne
    {
    }


    public class SubObjectOne : ISubObjectOne
    {
        
        
        
        public SubObjectOne(IFirstService firstService)
        {
            if (firstService == null)
            {
                throw new ArgumentNullException(nameof(firstService));
            }
        }

        protected SubObjectOne()
        {
        }
    }
}
