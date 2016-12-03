using System;
using System.ComponentModel;
using System.Reflection;

namespace MakeEvent.Web.Attributes
{
    public class LocalizedDisplayAttribute : DisplayNameAttribute
    {
        private readonly PropertyInfo _nameProperty;

        public LocalizedDisplayAttribute(string displayNameKey, Type resourceType = null)
            : base(displayNameKey)
        {
            if (resourceType != null)
            {
                _nameProperty = resourceType.GetProperty(base.DisplayName,
                                               BindingFlags.Static | BindingFlags.Public);
            }
        }

        public override string DisplayName
        {
            get
            {
                if (_nameProperty == null)
                {
                    return base.DisplayName;
                }
                return (string)_nameProperty.GetValue(_nameProperty.DeclaringType, null);
            }
        }
    }
}