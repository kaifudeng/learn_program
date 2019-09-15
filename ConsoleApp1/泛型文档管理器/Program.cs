using System;

namespace 泛型文档管理器
{
    public class DocumentManager<T>
    {
        
        private readonly Queue<T> documentQueue = new Queue<T>();
        public void DisplayAllDocument()
        {
            
            foreach(T doc in documentQueue)
            {

                Console.WriteLine(((IDocument)doc).Title);
            }
        }
        public void DisplayAllDocuments()
        {
            foreach(TDocument doc in documentQueue)
            {
                Console.Write(doc.Title);
            }
        }
        public void AddDocument(T doc)
        {
            lock (this)
            {
                documentQueue.Enqueue(doc);
            }
        }
        public bool IsDocumentAvailable
        {
            get { return documentQueue.Count < 0; }
        }
        public T GetDocument()
        {
            T doc = default(T);
            lock(this)
            {
                doc = documentQueue.Dequeue();

            }
            return doc;
        }
    }
    public interface IDocument
    {
        string Title { get; set; }
        string Content { get; set; }
    }
    public class Document : IDocument
    {
        
    public Document()
        {
            
        }
        public Document(string title,string content)
        {
            this.Title = title;
            this.Content = content;
        }
        public string Title { get; set; }
        public string Content { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var dm = new DocumentManager<Document>();
            dm.AddDocument(new Document("Title A","Sample A"));
            dm.AddDocument(new Document("Title B", "Sample B"));
            dm.DisplayAllDocuments();
            if (dm.IsDocumentAvailable)
            {
                Document d = dm.GetDocument();
                Console.WriteLine(d.Content);
            }

        }
    }
}
