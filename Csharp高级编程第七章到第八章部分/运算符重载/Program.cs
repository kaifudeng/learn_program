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
            public static double operator *(Vector lhs,Vector rhs)
            {
                return lhs.x * rhs.x+ lhs.y * rhs.y+ lhs.z * rhs.z;
            }
            public static Vector operator *(double lhs, Vector rhs)
            {
                return new Vector(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);
            }
            public static Vector operator *(Vector rhs,double lhs)
            {
                return lhs * rhs;  //重用了上面的代码，因为a*2=2*a
            }
            public static bool operator==(Vector rhs,Vector lhs)
            {
                if(rhs.x==lhs.x&&rhs.y==lhs.y&&rhs.z==lhs.z)
                {
                    return true;
                }return false;
            }
            public static bool operator !=(Vector rhs,Vector lhs)
            {
                return !(rhs == lhs);
            }

        }
        static void Main(string[] args)
        {
            Vector v1, v2, v3;
            v1 = new Vector(3.0, 3.0, 1.0);
            v2 = new Vector(2.0, -4.0, -4.0);
            v3 = v1 + v2;
            Console.WriteLine("v1=" + v1);
            Console.WriteLine("v2=" + v2);
            Console.WriteLine("v3=" + v3);
            Console.WriteLine("2*v3=" + 2 * v3);
            v3 += v2;
            Console.WriteLine("v3+=v2 gives " + v3);
            v3 = v1 * 2;
            Console.WriteLine("Setting v3=v1*2 gives " + v3);
            double dot = v1 * v3;
            Console.WriteLine("v1*v3= " + dot);
            Vector a, b;
            a = new Vector(3.0, 1.0, 2.0);
            b = 2 * a;

            //比较运算符的测试
            Vector v4, v5, v6;
            v4 = new Vector(3.0, 3.0, -10.0);
            v5 = new Vector(3.0, 3.0, -10.0);
            v6 = new Vector(2.0, 3.0, 6.0);

            Console.WriteLine("v4==v5 returns " + (v4 == v5));
            Console.WriteLine("v4==v6 returns " + (v4 == v6));
            Console.WriteLine("v5==v6 returns " + (v5 == v6));
            Console.WriteLine();
            Console.WriteLine("v4!=v5 returns " + (v4 != v5));
            Console.WriteLine("v4!=v6 returns " + (v4 != v6));
            Console.WriteLine("v5!=v6 returns " + (v5 != v6));
        }
    }
}
