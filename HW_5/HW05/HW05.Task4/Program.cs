using System;
using System.Collections.Generic;
using System.Text;

namespace HW05.Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string listOfAllClients = "123 Main Street St. Louisville OH 43071,432 Main Long Road St. Louisville OH 43071,786 High Street Pollocksville NY 56432,"
    + "54 Holy Grail Street Niagara Town ZP 32908,3200 Main Rd. Bern AE 56210,1 Gordon St. Atlanta RE 13000,"
    + "10 Pussy Cat Rd. Chicago EX 34342,10 Gordon St. Atlanta RE 13000,58 Gordon Road Atlanta RE 13000,"
    + "22 Tokyo Av. Tedmondville SW 43098,674 Paris bd. Abbeville AA 45521,10 Surta Alley Goodtown GG 30654,"
    + "45 Holy Grail Al. Niagara Town ZP 32908,320 Main Al. Bern AE 56210,14 Gordon Park Atlanta RE 13000,"
    + "100 Pussy Cat Rd. Chicago EX 34342,2 Gordon St. Atlanta RE 13000,5 Gordon Road Atlanta RE 13000,"
    + "2200 Tokyo Av. Tedmondville SW 43098,67 Paris St. Abbeville AA 45521,11 Surta Avenue Goodtown GG 30654,"
    + "45 Holy Grail Al. Niagara Town ZP 32918,320 Main Al. Bern AE 56215,14 Gordon Park Atlanta RE 13200,"
    + "100 Pussy Cat Rd. Chicago EX 34345,2 Gordon St. Atlanta RE 13222,5 Gordon Road Atlanta RE 13001,"
    + "2200 Tokyo Av. Tedmondville SW 43198,67 Paris St. Abbeville AA 45522,11 Surta Avenue Goodville GG 30655,"
    + "2222 Tokyo Av. Tedmondville SW 43198,670 Paris St. Abbeville AA 45522,114 Surta Avenue Goodville GG 30655,"
    + "2 Holy Grail Street Niagara Town ZP 32908,3 Main Rd. Bern AE 56210,77 Gordon St. Atlanta RE 13000";

            string zipCode = Console.ReadLine();

            string answer = Travel(listOfAllClients, zipCode);

            Console.WriteLine(answer);

            Console.ReadLine();
        }

        private static string Travel(string listOfAllClients, string zipCode)
        {
            string[] addressesArray = listOfAllClients.Split(',');

            List<string> houseNumbers = new List<string>();

            for (int i = 0; i < addressesArray.Length; i++)
            {
                string houseNumber = null;

                for (int j = 0; j < addressesArray[i].Length; j++)
                {
                    if (Char.IsNumber(addressesArray[i][j]))
                    {
                        houseNumber += addressesArray[i][j];

                        addressesArray[i] = addressesArray[i].Remove(j, 1);

                        j--;
                    }
                    else if (String.Equals(addressesArray[i][j], ' '))
                    {
                        addressesArray[i] = addressesArray[i].Trim();

                        break;
                    }
                }
                houseNumbers.Add(houseNumber);

                houseNumber = null;
            }

            List<string> houseNumbersToZipCode = new List<string>();

            StringBuilder zipCodeAddresses = new StringBuilder();

            zipCodeAddresses.Append(zipCode + ':');

            for (int i = 0; i < addressesArray.Length; i++)
            {
                if (addressesArray[i].EndsWith(zipCode))
                {
                    addressesArray[i] = addressesArray[i].Remove(addressesArray[i].Length - 9, 9);

                    zipCodeAddresses.Append(addressesArray[i] + ',');

                    houseNumbersToZipCode.Add(houseNumbers[i]);
                }
            }

            string[] houseNumbersToZipCodeArray = houseNumbersToZipCode.ToArray();

            const int ZipCodeLength = 9;

            if (zipCodeAddresses.Length == ZipCodeLength)
            {
                zipCodeAddresses.Append('/');
            }
            else
            {
                zipCodeAddresses.Remove(zipCodeAddresses.Length - 1, 1);

                zipCodeAddresses.Append('/');

                for (int i = 0; i < houseNumbersToZipCodeArray.Length; i++)
                {
                    zipCodeAddresses.Append(houseNumbersToZipCodeArray[i] + ',');
                }
                zipCodeAddresses.Remove(zipCodeAddresses.Length - 1, 1);
            }
            return zipCodeAddresses.ToString();
        }
    }
}
