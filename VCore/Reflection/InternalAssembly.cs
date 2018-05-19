using System.Reflection;

namespace VCore.Reflection
{
    internal class InternalAssembly
    {
        internal static Assembly GetExecutingAssembly()
        {
            return typeof(EntryClass).GetTypeInfo().Assembly;
        }

        private class EntryClass
        {
        }
    }
}
