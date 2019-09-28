using System;
using System.Collections.Generic;

namespace 链表
{
    public class Document
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public byte Priority { get; set; }
        public Document(string title,string content,byte priority)
        {
            this.Content = content;
            this.Title = title;
            this.Priority = priority;
        }
    }
    public class PriorityDocumentManager
    {
        private readonly LinkedList<Document> documentList;
        private readonly List<LinkedListNode<Document>> priorityNodes;
        public PriorityDocumentManager()
        {
            documentList = new LinkedList<Document>();
            priorityNodes = new List<LinkedListNode<Document>>(10);
            for(int i = 0; i < 10; i++)
            {
                priorityNodes.Add(new LinkedListNode<Document>(null));
            }
        }
        public void AddDocument(Document d)
        {
            if (d == null) throw new ArgumentNullException("d");
            AddDocumentToPriorityNode(d, d.Priority);
        }
        public void AddDocumentToPriorityNode(Document doc,int priority)
        {
            if (priority > 9 || priority < 0)
            {
                throw new ArgumentException("Priority must be between 0 and 9");
            }
            if (priorityNodes[priority].Value == null)
            {
                --priority;
                if (priority >= 0)
                {
                    AddDocumentToPriorityNode(doc, priority);
                }
                else
                {
                    documentList.AddLast(doc);
                    priorityNodes[doc.Priority] = documentList.Last;
                }
                return;
            }
            else
            {
                LinkedListNode<Document> prioNode = priorityNodes[priority];
                if (priority == doc.Priority)
                {
                    documentList.AddAfter(prioNode, doc);
                    priorityNodes[doc.Priority] = prioNode.Next;
                }
                else
                {
                    LinkedListNode<Document> firstprioNode = prioNode;
                    while(firstprioNode.Previous!=null&&
                        firstprioNode.Previous.Value.Priority==prioNode.Value.Priority)
                    {
                        firstprioNode = prioNode.Previous;
                        prioNode = firstprioNode;
                    }
                    documentList.AddBefore(firstprioNode, doc);
                    priorityNodes[doc.Priority] = firstprioNode.Previous;
                }
            }
        }

        public void DisplayAllNodes()
        {
            foreach(Document doc in documentList)
            {
                Console.WriteLine("priority:{0},title {1}", doc.Priority, doc.Title);
            }
        }
        public Document GetDocument()
        {
            Document doc = documentList.First.Value;
            documentList.RemoveFirst();
            return doc;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var pdm = new PriorityDocumentManager();
            pdm.AddDocument(new Document("one", "Sample", 8));
            pdm.AddDocument(new Document("two", "Sample", 3));
            pdm.AddDocument(new Document("three", "Sample", 4));
            pdm.AddDocument(new Document("four", "Sample", 8));
            pdm.AddDocument(new Document("five", "Sample", 1));
            pdm.AddDocument(new Document("six", "Sample", 9));
            pdm.AddDocument(new Document("seven", "Sample", 1));
            pdm.AddDocument(new Document("eight", "Sample", 1));

            pdm.DisplayAllNodes();
        }
    }
}
