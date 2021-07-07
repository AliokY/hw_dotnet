using System;

namespace HW07.Task1
{
    class StudentAndTeatherTest
    {
        static void Main(string[] args)
        {
            Person personMike = new();
            personMike.SayHello();

            Student studentNick = new();
            int nickAge = 21;
            studentNick.SayHello();
            studentNick.SetAge(nickAge);

            Teacher ourTeacher = new();
            int teacherAge = 30;
            ourTeacher.SayHello();
            ourTeacher.SetAge(teacherAge);
            Console.ReadKey();
            ourTeacher.Explanation();
        }
    }
}
