using System;
using System.Collections.Generic;
using System.Text;

namespace 抄书的一些代码
{
    class MainEntryPoint
    {
      public  static void fff()
        {
            for (int i=0;i<100; i+=10 )
            {
                for (int j=i;j<i+10 ;j++ )
                {
                    Console.Write(" " +j);
                }
                Console.WriteLine();
            }
        }
    }
}
