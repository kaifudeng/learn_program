using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14._3._3实现IDisposable接口和析构函数
{
    public class ResourceHolder : IDisposable
    {
        private bool isDisposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected  virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {

                }
            }
            isDisposed = true;
        }
        ~ResourceHolder()
        {
            Dispose(false);
        }
        public void SomeMethod()
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("ResourceHolder");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
