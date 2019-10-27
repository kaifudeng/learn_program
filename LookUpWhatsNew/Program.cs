using System;
using System.Text;
using System.Reflection;
using WhatsNewAttributes;
using System.Windows.Forms;
using VectorClass;
namespace LookUpWhatsNew
{
    internal class WhatsNewChecker
    {
        private static readonly StringBuilder outputText = new StringBuilder(1000);
        private static DateTime backDateTo = new DateTime(2010, 2, 1);
        public static void DisplayTypeInfo(Type type)
        {
            if (!(type.IsClass))
            {
                return;
            }
            AddToMessage("\nclass " + type.Name);
            Attribute[] attributes = Attribute.GetCustomAttributes(type);
            if (attributes.Length == 0)
            {
                AddToMessage("no changes to this class\n");
            }
            else
            {
                foreach(Attribute attrib in attributes)
                {
                    
                }
            }

            MethodInfo[] methods = type.GetMethods();
            AddToMessage("CHANGES TO METHODS OF THIS CLASS:");

            foreach(MethodInfo info in methods)
            {
                object[] attribs2 = info.GetCustomAttributes(
                    typeof(LastModifiedAttribute), false);

                if (attribs2 != null)
                {
                    AddToMessage(
                        info.ReturnType + " " + info.Name + "()");
                    foreach(Attribute attribute in attribs2)
                    {
                        WriteAttributeInfo(attribute);
                    }
                }
            }
        }
        public static void WriteAttributeInfo(Attribute attribute)
        {
            LastModifiedAttribute lastModifiedAttribute =
                attribute as LastModifiedAttribute;
            if (lastModifiedAttribute == null)
            {
                return;
            }
            DateTime modifiedDate = lastModifiedAttribute.DateModified;

            if (modifiedDate < backDateTo)
            {
                return;
            }
            AddToMessage(" MODIFIFD: " +
                modifiedDate.ToLongDateString() + ":");
            AddToMessage(" " + lastModifiedAttribute.Changes);

            if (lastModifiedAttribute.Issues != null)
            {
                AddToMessage(" Outstanding issues:" + lastModifiedAttribute.Issues);
            }
        }
        public static void AddToMessage(string Message)
        {
            outputText.Append("\n" + Message);
        }
        static void Main()
        {
            Assembly assembly = Assembly.Load("VectorClass");
            Attribute supportsAttribute =
                Attribute.GetCustomAttribute(
                    assembly, typeof(SupportsWhatsNewAttribute));
            string name = assembly.FullName;

            AddToMessage("Assembly: " + name);

            if (supportsAttribute == null)
            {
                AddToMessage(
                    "This assembly does not support WhatsNew attributes");
                return;
            }
            else
            {
                AddToMessage("Defined Types:");
            }

            Type[] types = assembly.GetTypes();

            foreach (Type t in types)
                DisplayTypeInfo(t);

            MessageBox.Show(outputText.ToString(), "what\'s New since "
                + backDateTo.ToLongDateString());
            Console.Read();

        }
    }
}