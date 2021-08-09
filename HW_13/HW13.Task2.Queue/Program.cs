using System;

namespace HW13.Task2.Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDTQueue();

            TestObjectQueue();

            TestGenericQueue();

            Console.ReadKey();
        }

        private static void TestDTQueue()
        {
            DTQueue dtQueue = new DTQueue();

            dtQueue.Enqueue(DateTime.Now);
            dtQueue.Enqueue(DateTime.Parse("2016-05-01 17:34:42"));
            dtQueue.Enqueue(DateTime.Parse("2008-05-01 7:34:42"));
            dtQueue.Enqueue(DateTime.Parse("Thu, 01 May 2008 07:34:42 GMT"));
            dtQueue.Enqueue(DateTime.Now.AddMonths(3));

            Console.WriteLine(dtQueue.Peek());

            dtQueue.Dequeue();

            Console.WriteLine(dtQueue.Peek());
        }

        private static void TestObjectQueue()
        {
            ObjectQueue objQueue = new ObjectQueue();

            objQueue.Enqueue(542);
            objQueue.Enqueue(56.45);
            objQueue.Enqueue("Hello!");
            objQueue.Enqueue('g');
            objQueue.Enqueue(0);

            Console.WriteLine(objQueue.Peek());

            objQueue.Dequeue();

            Console.WriteLine(objQueue.Peek());
        }

        private static void TestGenericQueue()
        {
            GenericQueue<string> genQueue = new();

            genQueue.Enqueue("C#");
            genQueue.Enqueue("is");
            genQueue.Enqueue("the");
            genQueue.Enqueue("best");
            genQueue.Enqueue("programming");
            genQueue.Enqueue("language");

            Console.WriteLine(genQueue.Peek());

            genQueue.Dequeue();

            Console.WriteLine(genQueue.Peek());
        }
    }
}