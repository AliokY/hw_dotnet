using System;

namespace HW03.Task8
{
    class Program
    {
        static void Main(string[] args)
        {

            string strNum2 = "56";
            int num2;
            int num3 = int.Parse(strNum2);

            bool res2 = int.TryParse(strNum2, out num2);

            int r = num2 + num3;




            string operationInput = "p";
            char operation;

            char operation2 = char.Parse(operationInput);
            bool result = char.TryParse(operationInput, out operation);


            string bolean = "true";
            bool res1 = bool.Parse(bolean);
            bool RES; 

            bool res4 = bool.TryParse(bolean, out RES);





        }
    }
}
