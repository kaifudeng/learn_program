using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace 集
{
    class Program
    {
        static void Main(string[] args)
        {
            var com = new HashSet<string>()
            { "Ferrari","Mclaren","Mercedes"};
            var tra = new HashSet<string>() { "Ferrari", "Mclaren" };
            var pri = new HashSet<string>() { "red", "toro", "force", "saub" };
            if (pri.Add("williams"))
            {
                Console.WriteLine("williams added");
            }
            if (com.Add("Mcalaren"))
            {
                Console.WriteLine("Mcalaren was already in this set");
            }
            if (tra.IsSubsetOf(com))
            {
                Console.WriteLine("tra is sub of com");
            }
            if (com.IsSupersetOf(tra))
            {
                Console.WriteLine("com is a superset of tra");
            }
            var allteams = new SortedSet<string>(com);
            allteams.UnionWith(pri);
            allteams.UnionWith(tra);
            Console.WriteLine();
            Console.WriteLine("all teams");
            foreach (var team in allteams)
            {
                Console.WriteLine(team);
            }

            allteams.ExceptWith(pri);
            Console.WriteLine();
            Console.WriteLine("no private team left");
            foreach (var team in allteams)
            {
                Console.WriteLine(team);
            }
            //P268 可观察的集合
            var data = new ObservableCollection<string>();
            data.CollectionChanged += Data_CollectionChanged;
            data.Add("One");
            data.Add("Two");
            data.Insert(1, "Three");
            data.Remove("One");

        }
        static void Data_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("action:{0}", e.Action.ToString());
            if (e.OldItems != null)
            {
                Console.WriteLine("starting index for old item(s): {0}", e.OldStartingIndex);
                Console.WriteLine("old item(s):");
                foreach (var item in e.OldItems)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
            }
            if (e.NewItems != null)
            {
                Console.WriteLine("starting index for old item(s):{0}", e.NewStartingIndex);
                Console.WriteLine("new item(s):");
                foreach(var item in e.NewItems)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine();
        }
    }
}