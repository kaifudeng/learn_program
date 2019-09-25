using System;
using System.Text;
namespace 字符串
{
   public struct Vector:IFormattable
    {
        public double x, y, z;
        public Vector(double x,double y,double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public double Norm()
        {
            return x * x + y * y + z * z;
        }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
            {
                return ToString();
            }
            string formatUpper = format.ToUpper();
            switch (formatUpper)
            {
                case "N":
                    return "| | " + Norm().ToString() + "| |";
                case "VE":
                    return string.Format("({0:E},{1:E},{2:E}", x, y, z);
                case "IJK":
                    StringBuilder sb = new StringBuilder(x.ToString(), 30);
                    sb.AppendFormat(" i + ");
                    sb.AppendFormat(y.ToString());
                    sb.AppendFormat(" j + ");
                    sb.AppendFormat(z.ToString());
                    sb.AppendFormat(" k");
                    return sb.ToString();
                default:
                    return ToString();
            }
        }
        public override string ToString()
        {
            return "(" + x + "," + y + "," + z + ")";
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "taday is a";
            str1 += "beautiful day";

            for(int i='z'; i>='a';i--)
            {
                char old1 = (char)i;
                char new1 = (char)(i + 1);
                str1 = str1.Replace(old1, new1);
            }
            for(int i='Z';i<='A';i--)
            {
                char old1 = (char)i;
                char new1 = (char)(i + 1);
                str1 = str1.Replace(old1, new1);
            }
            Console.WriteLine("Encoded:\n "+str1);
            Console.WriteLine();

            //P218 stringbuilder类
            StringBuilder stringA =
                new StringBuilder("Hello from all the guys at Wrox Press.", 150);//150是初始容量
            stringA.AppendFormat("we do hope you enjoy this book as much as we "+"enjoyed write it");
            Console.WriteLine("Not Encoded:\n" + stringA);
            for(int i = 'z'; i >= 'a'; i--)
            {
                char old1 = (char)i;
                char new1 = (char)(i + 1);
                stringA = stringA.Replace(old1, new1);
            }
            for (int i = 'Z'; i >= 'A'; i--)
            {
                char old1 = (char)i;
                char new1 = (char)(i + 1);
                stringA = stringA.Replace(old1, new1);
            }
            Console.WriteLine("Encoded：\n" + stringA);
            Console.WriteLine();

            //P226页
            Vector v1 = new Vector(1, 32, 5);
            Vector v2 = new Vector(845, 54.3, -7.8);
            Console.WriteLine("\nIn IJK format,\nl is {0,30:IJK}\nv2 is {1,30:IJK}", v1, v2);
            Console.WriteLine("\nIn default format,\nv1 is {0,30}\nv2 is {1,30}", v1, v2);
            Console.WriteLine("\nIn VE format,\nv1 is {0,30:VE}\nv2 is {1,30:VE}", v1, v2);
            Console.WriteLine("\nNorm are:\nv1 is {0,20:N}\nv2 is {1,20:N}", v1, v2);

        }
    }
}
