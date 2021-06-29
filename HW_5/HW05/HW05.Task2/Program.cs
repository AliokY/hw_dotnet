using System;
using System.Text;

namespace HW05.Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder("1a!2.3!!.. 4.!.?6 7! ..?");

            int index;

            for (int i = 0; i < sb.Length; i++)
            {
                index = sb.ToString().IndexOf('?');

                if (i < index)
                {
                    if (sb[i] == '!' || sb[i] == '.')
                    {
                        sb.Remove(i, 1);
                        i--;
                    }
                }
                else if (i > index)
                {
                    if (sb[i] == ' ')
                    {
                        sb.Replace(' ', '_', i, sb.Length - i);
                    }
                }
            }
            Console.WriteLine(sb);
            Console.ReadKey();
        }
    }
}
