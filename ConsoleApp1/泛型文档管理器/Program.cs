using System;
using System.Collections.Generic;
namespace 泛型文档管理器
{
    public class DocumentManager<TDocument>
        where TDocument:IDocument
    {
        
        private readonly Queue<TDocument> documentQueue = new Queue<TDocument>();
        public void DisplayAllDocument()
        {
            
            foreach(TDocument doc in documentQueue)
            {

                Console.WriteLine(((IDocument)doc).Title);
            }
        }
        public void DisplayAllDocuments()
        {
            foreach(TDocument doc in documentQueue)
            {
                Console.WriteLine(doc.Title);
            }
        }
        public void AddDocument(TDocument doc)
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
        public TDocument GetDocument()
        {
            TDocument doc = default(TDocument);
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
