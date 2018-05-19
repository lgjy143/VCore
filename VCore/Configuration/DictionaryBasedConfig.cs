using System;
using System.Collections.Generic;
using VCore.Extensions;

namespace VCore.Configuration
{
    public class DictionaryBasedConfig : IDictionaryBasedConfig
    {
        protected DictionaryBasedConfig()
        {
            CustomSettings = new Dictionary<string, object>();
        }

        protected Dictionary<string, object> CustomSettings { get; }

        public object this[string name]
        {
            get { return CustomSettings.GetOrDefault(name); }
            set { CustomSettings[name] = value; }
        }

        public T Get<T>(string name)
        {
            var value = this[name];
            return value == null
                ? default(T)
                : (T)Convert.ChangeType(value, typeof(T));
        }

        public void Set<T>(string name, T value)
        {
            this[name] = value;
        }

        public object Get(string name)
        {
            return Get(name, null);
        }

        public object Get(string name, object defaultValue)
        {
            var value = this[name];
            if (value == null)
            {
                return defaultValue;
            }

            return this[name];
        }

        public T Get<T>(string name, T defaultValue)
        {
            return (T)Get(name, (object)defaultValue);
        }

        public T GetOrCreate<T>(string name, Func<T> creator)
        {
            var value = Get(name);
            if (value == null)
            {
                value = creator();
                Set(name, value);
            }
            return (T)value;
        }
    }
}
