using System;

namespace 泛型结构
{
    public struct Nullable<T>
    
        where T:struct
   {
        public Nullable(T value)
        {
            this.hasValue = true;
            this.value = value;
        }
        private bool hasValue;
        public bool HasValue
        {
            get
            {
                return hasValue;
            }

        }
        private T value;
        public T Value
        {
            get
            {
                if (!hasValue)
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
            if (!hasValue)
            
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
            x +=3;
            if (x.HasValue)
            {
                int y = x.Value;
            }
            x = null;
            
            
        }
    }
}
