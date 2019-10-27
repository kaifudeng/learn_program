using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自定义异常
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please type in the game of the file " +
                "containing the names of the people to be cold called >");
            string fileName = Console.ReadLine();
            var peopleToRing = new ColdCallFileReader();

            try
            {
                peopleToRing.Open(fileName);
                for (int i = 0; i < peopleToRing.NPeopleToRing; i++)
                {
                    peopleToRing.ProcessNextPerson();
                }
                Console.WriteLine("All callers processed correctly");
            }
            catch(FileNotFoundException ) 
            {
                Console.WriteLine("The file {0} does not exist", fileName);

            }
            catch(ColdCallFileFormatException ex)
            {
                Console.WriteLine("The file {0} appear to have been corrupted",
                    fileName);
                Console.WriteLine("Details of problem are :{0}", ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine(
                        "Inner exception was:{0}", ex.InnerException.Message);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception occurred:\n" + ex.Message);
            }
            finally
            {
                peopleToRing.Dispose(); 
            }
            Console.ReadLine();
        }
    }
    public class ColdCallFileReader:IDisposable
    {
        private FileStream fs;
        private StreamReader sr;
        private uint nPeopleToRing;
        private bool isDisposed = false;
        private bool isOpen = false;

        public void Open(string filename)
        {
            if (isDisposed)
                throw new ObjectDisposedException("peopleToRing");

                fs = new FileStream(filename, FileMode.Open);
                sr = new StreamReader(fs);

                try
                {
                    string firstline = sr.ReadLine();
                    nPeopleToRing = uint.Parse(firstline);
                    isOpen = true;
                }
                catch(FormatException ex)
                {
                    throw new ColdCallFileFormatException(
                        "First line isn\'t an integer", ex);
                }
            
        }

        public void ProcessNextPerson()
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("peopleToRing");

            }
            if (!isOpen)
            {
                throw new UnexpectedException(
                    "Attempted to access coldcall file that is not open");

            }
            try
            {
                string name;
                name = sr.ReadLine();
                if (name == null)
                {
                    throw new ColdCallFileFormatException("Not enough names");
                }
                if (name[0] == 'B')
                {
                    throw new SalesSpyFoundException(name);
                }
                Console.WriteLine(name);
            }
            catch(SalesSpyFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { }
        }
        public uint NPeopleToRing
        {
            get 
            {
                if (isDisposed)
                {
                    throw new ObjectDisposedException("peopleToRing");

                }
                if (!isOpen)
                {
                    throw new UnexpectedException(
                        "Attempted to access cold-call file that is not open");

                }
                return nPeopleToRing;
            }
        }
        public void Dispose()
        {
            if (isDisposed)
            {
                return; 
            }
            isDisposed = true;
            isOpen = false;

            if (fs != null)
            {
                fs.Close();
                fs = null;
            }
        }
    }

    public class SalesSpyFoundException : Exception
    {
        public SalesSpyFoundException(string spyName)
            : base("Sales spy found,with name " + spyName)
        {

        }
        public SalesSpyFoundException(string spyName,Exception innerException)
            :base("Sales spy found with name "+spyName,innerException)
        {

        }
    }

    public class ColdCallFileFormatException : Exception
    {
        public ColdCallFileFormatException(string message)
            : base(message) { }
        public ColdCallFileFormatException(string message ,Exception innerException) 
        :base(message,innerException)
        { }
    }

    public class UnexpectedException : Exception
    {
        public UnexpectedException(string message)
            : base(message)
        {
        }
        public UnexpectedException(string message ,Exception innerException)
        :base(message,innerException)
        {
        }
    }
}
