﻿using System;

namespace IocPerformance.Classes.Properties
{
    public interface ISubObjectB
    {
        void Verify(string containerName);
    }

   
    public class SubObjectB : ISubObjectB
    {

        public IServiceB ServiceB { get; set; }

        public void Verify(string containerName)
        {
            if (this.ServiceB == null)
            {
                throw new Exception("ServiceB was null for SubObjectC for container " + containerName);
            }
        }
    }
}
