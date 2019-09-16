using System;

namespace 泛型结构
{
    public struct Nullable<T>
    
        where T:struct
   {
        public Nullable(T value)
        {
            this.hasvalue = true;
            this.value = value;
        }
        private bool hasvalue;
        public bool Hasvalue
        {
            get
            {
                return hasvalue;
            }

        }
        private T value;
        public T Value
        {
            get
            {
                if (!hasvalue)
                {
                    throw new InvalidOperationException("no Value");
                }
                return value;
            }
        }
        public static explicit operator T(Nullable<T> value)
        {
            return value.Value;
        }
        public static implicit operator Nullable<T>(T value)
        {
            return new Nullable<T>(value);
        }
        public override string ToString()
        {
            if (!hasvalue)
            
                return String.Empty;
                return this.value.ToString();
            
        }
   }
    
    class Program
    {
        static void Main(string[] args)
        {
            Nullable<int> x;
            x = 4;
            x  =x+3;
            if (x.Hasvalue)
            {
                int y = x.Value;
            }
            x = null;
            int? x1;
            x1 = null;
        }
    }
}
