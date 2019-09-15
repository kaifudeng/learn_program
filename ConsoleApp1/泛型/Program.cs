using System;

namespace 泛型
{
   /* public class LinkedListNode //非泛型的链表
    {
        public LinkedListNode(object value)
        {
            this.Value = value;
        }
        public object Value { get; private set; }
        public LinkedListNode Next { get; internal set; }
        public LinkedListNode Prev { get; internal set; }
    }*/
    public class LinkedListNode<T>
    {
        public LinkedListNode(T value)
            {
              this.Value=value;
            }
    public T Value { get; private set; }
    public LinkedListNode<T> Next { get; internal set; }
    public LinkedListNode<T> Prev { get; internal set; }
    }
    public class LinkedList<T> : IEnumerable<T>
    {
        public LinkedListNode<T>First { get; private set; }
        public LinkedListNode<T> Last { get; private set; }

        public LinkedListNode<T> AddLast(T node)
        {
            var newNode = new LinkedListNode<T>(node);
            if (First == null)
            {
                First = newNode;
                Last = First;
            }
            else
            {
                LinkedListNode<T> previous = Last;
                Last.Next = newNode;
                Last = newNode;
                Last.Prev = previous;
            }
            return newNode;
        }
        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = First;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var list2 = new LinkedList<int>();
            list2.AddLast(1);
            list2.AddLast(2);
            list2.AddLast(5);

            foreach (int i in list2)
            {
                Console.WriteLine(i);
            }

            var list3 = new LinkedList<string>();
            list3.AddLast(2);
            list3.AddLast("four");
            list3.AddLast("foo");

            foreach (string s in list3)
            {
                Console.WriteLine(s);
            }
        }
    }
}
