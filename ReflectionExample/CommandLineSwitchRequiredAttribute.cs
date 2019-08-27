using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionExample
{
    class CommandLineSwitchRequiredAttribute:Attribute
    {
        public static string[] GetMissingRequiredOptions(object commandLine)
        {
            StringCollection missingOptions = new StringCollection();
            PropertyInfo[] properties = commandLine.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                Attribute[] attributes = (Attribute[])property.GetCustomAttributes(typeof(CommandLineSwitchRequiredAttribute), false);
                if ((attributes.Length > 0) && (property.GetValue(commandLine, null) == null))
                {
                    missingOptions.Add(property.Name);
                }
            }
            string[] array = new string[missingOptions.Count];
            missingOptions.CopyTo(array, 0);
            return array;
        }
    }
}
