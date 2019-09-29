using System;
using System.Collections;
using System.Collections.Specialized;
using System.Text;

namespace 位数组
{
    
    class Program
    {
        public static void DisplayBits(BitArray bits)
        {
            foreach (bool bit in bits)
            {
                Console.Write(bit ? 1 : 0);
            }
        }
        static void Main(string[] args)
        {
            //BitArray类
            var bitsl = new BitArray(8);
            bitsl.SetAll(true);
            bitsl.Set(1, false);
            bitsl[5] = false;
            bitsl[7] = false;
            Console.Write("initialized: ");
            DisplayBits(bitsl);
            Console.WriteLine();

            Console.Write(" not ");
            DisplayBits(bitsl);
            bitsl.Not();
            Console.Write(" = ");
            DisplayBits(bitsl);
            Console.WriteLine();

            var bits2 = new BitArray(bitsl);
            bits2[0] = true;
            bits2[1] = false;
            bits2[4] = true;
            DisplayBits(bitsl);
            Console.Write(" or ");
            DisplayBits(bits2);
            Console.Write(" = ");
            bitsl.Or(bits2);
            DisplayBits(bitsl);
            Console.WriteLine();

            DisplayBits(bitsl);
            Console.Write(" Xor ");
            DisplayBits(bits2);
            bitsl.Xor(bits2);
            Console.Write(" = ");
            DisplayBits(bitsl);
            Console.WriteLine();

            Console.WriteLine();
            //BitVector32结构
            var bits3 = new BitVector32();
            int bit1 = BitVector32.CreateMask();
            int bit2 = BitVector32.CreateMask(bit1);
            int bit3 = BitVector32.CreateMask(bit2);
            int bit4 = BitVector32.CreateMask(bit3);
            int bit5 = BitVector32.CreateMask(bit4);
            bits3[bit1] = true;
            bits3[bit2] = false;
            bits3[bit3] = true;
            bits3[bit4] = true;
            bits3[bit5] = true;
            Console.WriteLine(bits3);
            bits3[0xabcdef] = true;
            Console.WriteLine(bits3);

            BitVector32.Section secA = BitVector32.CreateSection(0xfff);
            BitVector32.Section secB = BitVector32.CreateSection(0xff,secA);
            BitVector32.Section secC = BitVector32.CreateSection(0xf,secB);
            BitVector32.Section secD = BitVector32.CreateSection(0x7,secC);
            BitVector32.Section secE = BitVector32.CreateSection(0x7,secD);
            BitVector32.Section secF = BitVector32.CreateSection(0x3,secE);
            Console.WriteLine("SectionA: {0}", IntToBinaryString(bits3[secA], true));
            Console.WriteLine("SectionB: {0}", IntToBinaryString(bits3[secB], true));
            Console.WriteLine("SectionC: {0}", IntToBinaryString(bits3[secC], true));
            Console.WriteLine("SectionD: {0}", IntToBinaryString(bits3[secD], true));
            Console.WriteLine("SectionE: {0}", IntToBinaryString(bits3[secE], true));
            Console.WriteLine("SectionF: {0}", IntToBinaryString(bits3[secF], true));
        }

        static string IntToBinaryString(int bits,bool removeTrailingZero)
        {
            var sb = new StringBuilder(32);
            for (int i = 0; i < 32; i++)
            {
                if ((bits & 0x80000000) != 0)
                {
                    sb.Append("1");
                }
                else
                {
                    sb.Append("0");
                }
                bits = bits << 1;
            }
            string s = sb.ToString();
            if (removeTrailingZero)
            {
                return s.TrimStart('0');
            }
            else
            {
                return s;
            }
        }
    }
}
