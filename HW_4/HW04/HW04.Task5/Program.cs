using System;
using System.Text.RegularExpressions;

namespace HW04.Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, input several words:");
            string wordsLine = Console.ReadLine();

            LinqUsing linqUsing = new LinqUsing();

            //string str = SwapWords(wordsLine);

            //int symbolQuantity = CountAllSymbols(wordsLine);
            //Console.WriteLine(symbolQuantity);

            //string[] newArray = SortString(wordsLine);

            string result = linqUsing.DelLongestWordLinq(wordsLine);

            Console.WriteLine(result);

            Console.ReadKey();
        }

        private static string DeleteLongestWord(string str)
        {
            int index = 0;

            int length = 0;

            int currentIndex = -1;

            int currentLength = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ' || i == str.Length - 1)
                {
                    if (currentLength > length)
                    {
                        if (i == str.Length - 1 && Char.IsLetter(str[i]))
                        {
                            currentLength += 1;
                        }

                        length = currentLength;

                        index = currentIndex;
                    }
                    currentLength = 0;

                    currentIndex = -1;
                }
                else
                {
                    if (currentIndex == -1)
                    {
                        currentIndex = i;
                    }
                    currentLength += 1;
                }
            }
            str = str.Remove(index, length);

            return str;
        }

        private static string SwapWords(string str)
        {
            string str2 = null;

            string[] strArray = str.Split(new char[] { ' ' });

            string longestWord = strArray[0];

            string shortestWord = strArray[0];

            for (int i = 1; i < strArray.Length; i++)
            {
                if (strArray[i].Length > longestWord.Length)
                {
                    longestWord = strArray[i];
                }
                if (strArray[i].Length < shortestWord.Length)
                {
                    shortestWord = strArray[i];
                }
            }
            int indexLong = Array.IndexOf(strArray, longestWord);
            int indexShort = Array.IndexOf(strArray, shortestWord);

            strArray[indexLong] = shortestWord;
            strArray[indexShort] = longestWord;

            str2 = string.Join(" ", strArray);

            return str2;
        }

        private static int CountAllSymbols(string str)
        {
            str = str.Replace(" ", "");

            int symbolQuantity = 0;

            for (int i = 0; i < str.Length; i++)
            {
                // checking for Russian letters and all punctuation marks
                if (!Regex.IsMatch(str[i].ToString(), @"^[а-яёА-Я]+\p{P}+$"))
                {
                    symbolQuantity += 1;
                }
            }

            return symbolQuantity;
        }

        private static int FindLongest(string[] strArray)
        {
            string longest = strArray[0];
            int longestIndex = 0;
            for (int i = 1; i < strArray.Length; i++)
            {
                if (strArray[i].Length > longest.Length)
                {
                    longest = strArray[i];
                    longestIndex = i;
                }
            }
            return longestIndex;
        }

        private static string[] SelectionSort(string[] strArray)
        {
            string[] newArray = strArray;

            string[] newArr = new string[] { };
            for (int i = 0; i < strArray.Length; i++)
            {
                int longestIndex = FindLongest(strArray);
                newArray[i] = strArray[longestIndex];

                Array.Clear(strArray, longestIndex, 1);
            }
            return newArray;
        }

        private static string[] SortString(string str)
        {
            string[] strArray = str.Split(new char[] { ' ' });

            string[] newArray = SelectionSort(strArray);

            return newArray;
        }
    }
}
