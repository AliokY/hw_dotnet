using System;
using System.IO;

namespace HW._02.Image
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Reading a file located in "D:\Учёба\IT-Academy\Web 2\Home Work" and passing it to a stream
            // 2. Assigning all data from the file to a string variable
            // 3. Closing the stream and freeing up resources
            // 4. Splitting the string by spaces into separate bytes and creating an string array of bytes
            // 5. Creating byte array of the same size with string array
            // 6. Passing of the entire byte array with a cycle and recording each byte from a string array after conversion (from base 2)
            // 7. Saving a byte array to a PNG file at a given path using an argument "imageBytes"

            StreamReader textReader = new StreamReader(@"D:\Учёба\IT-Academy\Web 1\Home Work\HW_2\HW.02.Image\image.txt");

            string textReaderResult = textReader.ReadToEnd();

            textReader.Dispose();
            
            string[] arrayOfTextResult = textReaderResult.Split(' ');
                        
            byte[] imageBytes = new byte[arrayOfTextResult.Length - 1];

            for (int i = 0; i < arrayOfTextResult.Length - 1; i++)
            {
                byte binary = Convert.ToByte(arrayOfTextResult[i], 2);

                imageBytes[i] = binary;
            }

            File.WriteAllBytes(@"D:\Учёба\IT-Academy\Web 1\Home Work\HW_2\HW.02.Image\image.png", imageBytes);
        }
    }
}
