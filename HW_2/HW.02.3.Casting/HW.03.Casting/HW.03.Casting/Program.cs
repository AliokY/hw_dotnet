using System;

namespace HW._03.Casting
{
    class Program
    {
        static void Main(string[] args)
        {
            // 5 implicit conversions
            // 1.
            byte a = 12;
            short b = a;
            // 2.
            int c = b;
            // 3. 
            long d = c;
            // 4.
            double e = d;
            // 5. 
            decimal f = d;

            // 5 explicit conversions
            // 1.
            int g = 12;
            int h = 28;
            byte i = (byte)(a + b);
            // 2.
            double j = 594;
            int k = (int)j;
            // 3.
            decimal l = 9998;
            ushort m = (ushort)l;
            // 4. 
            ulong n = 120;
            char o = (char)n;
            // 5.
            float p = 5689;
            int q = 789;
            long r = (long)(p * q);

            // 5 examples of boxing
            //1.
            byte number = 128;
            Object oNum = number;
            // 2.
            double numOne = 1;
            Object one = numOne;
            // 3. 
            int num = 2021;
            Object numOnum = num;
            // 4. 
            char w = 'r';
            Object wo = w;
            // 5.
            bool sms = true;
            Object smOne = sms;

            // 5 examples of unboxing
            // 1.
            int num1 = (int)numOne;
            // 2.
            bool sbd = (bool)smOne;
            // 3. 
            double dOne = (double)one;
            // 4. 
            char chOne = (char)wo;
            // 5.
            byte bOne = (byte)oNum;
        }
    }
}
