using System;
using System.Collections.Generic;
using System.Text;

namespace HW05.Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            // input string
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

        /// <summary>
        /// displays all addresses according to the code
        /// </summary>
        /// <param name="listOfAllClients">list of addresses of all clients in a line separated by commas</param>
        /// <param name="zipCode">zip code, according to which the addresses will be displayed</param>
        /// <returns>string in the specified format</returns>
        private static string Travel(string listOfAllClients, string zipCode)
        {
            // create an array from a string of addresses, where each element is a separate address
            string[] addressesArray = listOfAllClients.Split(',');

            //create an empty list for entering addresses containing the desired zip code
            List<string> necessaryAdresses = new List<string>();

            // iteration over each element of the address array
            for (int i = 0; i < addressesArray.Length; i++)
            {
                // check "if the address contains the entered zip code, then"
                if (addressesArray[i].EndsWith(zipCode))
                {
                    // remove the zip code from the address
                    addressesArray[i] = addressesArray[i].Remove(addressesArray[i].Length - 9, 9);

                    // add the corresponding address without the zip code to the list of required addresses
                    necessaryAdresses.Add(addressesArray[i]);
                }
            }
            // convert the list of required addresses into an array(for faster iteration)
            string[] necessaryAdressesArray = necessaryAdresses.ToArray();

            // creating a list of required house numbers
            StringBuilder houseNumbers = new StringBuilder();

            // go through each element of the array of necessary addresses
            for (int i = 0; i < necessaryAdressesArray.Length; i++)
            {
                string houseNumber = null;

                // go through each character of the corresponding address
                for (int j = 0; j < necessaryAdressesArray[i].Length; j++)
                {
                    // check "if the character is a digit, then"
                    if (Char.IsNumber(necessaryAdressesArray[i][j]))
                    {
                        // add a digit to the variable "houseNumber"
                        houseNumber += necessaryAdressesArray[i][j];

                        // remove the corresponding digit from the address
                        necessaryAdressesArray[i] = necessaryAdressesArray[i].Remove(j, 1);

                        // step back one iteration, because the string has become shorter
                        // (so as not to skip checking the next value)
                        j--;
                    }
                    // checking "if the character is a space, then"
                    else if (String.Equals(necessaryAdressesArray[i][j], ' '))
                    {
                        // trim the spaces at the beginning and end of the line
                        necessaryAdressesArray[i] = necessaryAdressesArray[i].Trim();

                        // exit the cycle "for"
                        break;
                    }
                }
                // add the resulting house number to the corresponding list
                houseNumbers.Append(houseNumber + ',');

                // reset the value of the variable "houseNumber"
                houseNumber = null;
            }
            // create a StringBuilder object that will contain the entered zip code, the corresponding addresses and house numbers
            StringBuilder zipCodeAddresses = new StringBuilder();

            // add the entered zip code and a colon to the object "zipCodeAddresses"
            zipCodeAddresses.Append(zipCode + ':');

            // go through each element of the array of necessary addresses and add them to the object "zipCodeAddresses", separated
            // by commas
            for (int i = 0; i < necessaryAdressesArray.Length; i++)
            {
                zipCodeAddresses.Append(necessaryAdressesArray[i] + ',');
            }
            // enter the constant for the length of the zip code (including the colon)
            const int ZipCodeLength = 9;

            // check the length of the "zipCodeAddresses" object with the entered constant
            if (zipCodeAddresses.Length == ZipCodeLength)
            {
                // add a slash if the length matches
                zipCodeAddresses.Append('/');
            }
            else
            {
                // remove the last extra comma in the string
                zipCodeAddresses.Remove(zipCodeAddresses.Length - 1, 1);

                // add a slash
                zipCodeAddresses.Append('/');

                // add all house numbers separated by commas to the address line
                zipCodeAddresses.Append(houseNumbers);
                // remove the last extra comma in the string
                zipCodeAddresses.Remove(zipCodeAddresses.Length - 1, 1);
            }
            return zipCodeAddresses.ToString();
        }
    }
}
