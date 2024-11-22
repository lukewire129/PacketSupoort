using System;

namespace BitSupport.Attributes
{
    [AttributeUsage (AttributeTargets.Class)]
    public class BitStateAttribute : Attribute
    {
        public Type StateEnumType { get; }

        public BitStateAttribute(Type stateEnumType)
        {
            StateEnumType = stateEnumType;
        }
    }
}
