using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadaniaMichal
{
    public class Task2
    {
        /* Task2 (character get ascii)
       Pobieraj od użytkownika userString, dopóki nie będzie składał się z samych
       dużych liter. Przeprowadź analizę pobranego napisu:

       a) Zlicz, ile w napisie znajduje się znaków, których kod ASCII
       posiada nieparzystą cyfrę jedności
       b) Oblicz sumę kodów ASCII znaków znajdujących się na parzystych
       indeksach w napisie. 
       c) Następnie znajdź pierwszą liczbę z
       przedziału <65, 90>, która jest dzielnikiem wyznaczonej wcześniej
       sumy. Będzie to kod ASCII jednej z dużych liter alfabetu.

       tylko parzyste
       B = 66 - w przedziale i pierwsza.
       suma z punku b, na przyklad 131.
       B+F=66+70=136
       sprawdzic 136 / 66 = 2,06 dzieli sie bez decimal, like 5,10,56, not like 3,54
       136 / 68 =2
       68 = D
       pierwsza liczba ktora to spelni wyswietlamy na ekran
       2. liczbe zamienic na literke convert to ascii
       i wyswietlic ta literke - znak. D

       */

        public static void Perform_2()
        {
            string retrivedUserString = RetrieveUserString();
            int[] convertedUserStringInASCII = ConvertToASCII(retrivedUserString);

            foreach (var item in convertedUserStringInASCII)
            {
                Console.WriteLine(item);
            }

            int countedOddNumber = CountOddNumber(convertedUserStringInASCII);
            Console.WriteLine("The counted odd numbers is: " + countedOddNumber);

            int summarizedNumbersOnEvenIndex = SumNumbersOnEvenIndex(convertedUserStringInASCII);
            Console.WriteLine("The summarized numbers on even index is: " + summarizedNumbersOnEvenIndex);

            int foundFirstAsciiNumber = FindFirstAsciiNumber(summarizedNumbersOnEvenIndex);
            char convertedAsciiNumber = ConvertFromAsciiNumbertoCharacter(foundFirstAsciiNumber);
            Console.WriteLine("Fond first Ascii number is: " + foundFirstAsciiNumber);
            Console.WriteLine("Converted from Ascii number to character: " + convertedAsciiNumber);
        }

        private static string RetrieveUserString()
        {
            string? userString = null;

            while (!IsUpperString(userString))
            {
                Console.WriteLine("Please enter the userString");
                userString = Console.ReadLine(); //? - zmienna moze byc nullem
            }
            return userString;
        }

        private static bool IsUpperString(string? checkedString) // ? zmienna moze byc nullem 
        {
            if (checkedString == null || checkedString == "")
            {
                return false;
            }
            return checkedString.Equals(checkedString.ToUpper());
        }

        private static int[] ConvertToASCII(string userString)
        {
            int[] ConvertedUserStringInASCII = new int[userString.Length];

            int i = 0;

            foreach (char singleCharacter in userString)
            {
                ConvertedUserStringInASCII[i] = System.Convert.ToInt32(singleCharacter);
                i++;
            }
            return ConvertedUserStringInASCII;
        }

        private static int CountOddNumber(int[] ASCIINumber)
        {
            int counter = 0;
            foreach (var item in ASCIINumber)
            {
                if (item % 2 == 1)
                {
                    counter++;
                }
            }
            return counter;
        }

        private static int SumNumbersOnEvenIndex(int[] ASCIINumber)
        {
            int sum = 0;
            for (int i = 0; i < ASCIINumber.Length; i = i + 2)
            {
                sum = sum + ASCIINumber[i];
            }
            return sum;
        }

        private static int FindFirstAsciiNumber(int summarizedNumbersOnEvenIndex)
        {
            for (int currentAsciiNumber = 65; currentAsciiNumber <= 90; currentAsciiNumber++)
            {
                if (summarizedNumbersOnEvenIndex % currentAsciiNumber == 0)
                {
                    return currentAsciiNumber;
                }
            }
            throw new Exception("The Ascii number in sum not found");
        }

        private static char ConvertFromAsciiNumbertoCharacter(int? foundFirstAsciiNumber)
        {
            return System.Convert.ToChar(foundFirstAsciiNumber);
        }
    }
}
