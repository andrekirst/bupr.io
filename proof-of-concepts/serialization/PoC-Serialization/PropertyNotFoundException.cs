using System;

namespace PoC_Serialization
{
    public class PropertyNotFoundException : Exception
    {
        public string PropertyName { get; }

        public PropertyNotFoundException(string propertyName)
            : base($"Property \"{propertyName}\" not found")
        {
            PropertyName = propertyName;
        }
    }
}