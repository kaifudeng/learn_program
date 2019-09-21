using System;

namespace 运算符重载
{
    class Program
    {
        struct Vector
        {
            public double x, y, z;
            public Vector(double x,double y,double z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
            public Vector(Vector rhs)
            {
                x = rhs.x;
                y = rhs.y;
                z = rhs.z;
            }
            public override string ToString()
            {
                return "(" + x + "," + y + "," + z + ")";
            }
            public static Vector operator +(Vector lhs,Vector rhs)
            {
                Vector result = new Vector(rhs);
                result.x += lhs.x;
                result.y += lhs.y;
                result.z += lhs.z;
                return result;
            }
        }
        static void Main(string[] args)
        {
            Vector v1, v2, v3;
            v1 = new Vector(3.0, 3.0, 1.0);
            v2 = new Vector(2.0, -4.0, -4.0);
            v3 = v1 + v2;
            Console.WriteLine("v1=" + v1.ToString());
            Console.WriteLine("v2=" + v2.ToString());
            Console.WriteLine("v3=" + v3.ToString());
        }
    }
}
