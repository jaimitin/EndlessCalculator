using EndlessCalculator.Util;
using System;

namespace EndlessCalculator.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class DependsOnAttribute : Attribute
    {
        public string Dependency { get; }

        public DependsOnAttribute(string dependency)
        {
            Guard.IsNotNullOrEmpty(dependency);

            Dependency = dependency;
        }
    }
}
