using System;
using Introduction = Wrox.ProCSharp.Basics;
class Test
{
    public static int Main()
    {
        Introduction::NamespaceExample nsex =
            new Introduction::NamespaceExample();
        Console.WriteLine(nsex.GetNamespace());
        return 0;
    }
}
namespace Wrox.ProCSharp.Basics
{
    class NamespaceExample
    {
        public string GetNamespace()
        {
            return this.GetType().Namespace;
        }
    }
}