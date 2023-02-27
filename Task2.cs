using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static ZadaniaMichal.Task1;

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
        public class Task2Result
        {
            public int[] convertToASCII;
            public int countedOddNumber;
            public int summarizedNumbersOnEvenIndex;
            public int foundFirstAsciiNumber;
            public char convertedAsciiNumber;

            public Task2Result(int[] convertToASCII, 
                               int countedOddNumber, 
                               int summarizedNumbersOnEvenIndex,
                               int foundFirstAsciiNumber,
                               char convertedAsciiNumber)
            {
                this.convertToASCII = convertToASCII;
                this.countedOddNumber = countedOddNumber;
                this.summarizedNumbersOnEvenIndex = summarizedNumbersOnEvenIndex;
                this.foundFirstAsciiNumber = foundFirstAsciiNumber;
                this.convertedAsciiNumber = convertedAsciiNumber;
            }
        }

        public static Task2Result Perform_2(string retrivedUserString)
        {
            int[] convertedUserStringInASCII = ConvertToASCII(retrivedUserString);

            int countedOddNumber = CountOddNumber(convertedUserStringInASCII);

            int summarizedNumbersOnEvenIndex = SumNumbersOnEvenIndex(convertedUserStringInASCII);

            int foundFirstAsciiNumber = FindFirstAsciiNumber(summarizedNumbersOnEvenIndex);

            char convertedAsciiNumber = ConvertFromAsciiNumbertoCharacter(foundFirstAsciiNumber);

            return new Task2Result(convertedUserStringInASCII, countedOddNumber, summarizedNumbersOnEvenIndex, foundFirstAsciiNumber, convertedAsciiNumber);
        }

        public static void Perform_2()
        {
            string retrivedUserString = RetrieveUserString();

            Task2Result task2Result =  Perform_2(retrivedUserString);
         
            foreach (var item in task2Result.convertToASCII)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("The counted odd numbers is: " + task2Result.countedOddNumber);

            Console.WriteLine("The summarized numbers on even index is: " + task2Result.summarizedNumbersOnEvenIndex);

            Console.WriteLine("Fond first Ascii number is: " + task2Result.foundFirstAsciiNumber);
            Console.WriteLine("Converted from Ascii number to character: " + task2Result.convertedAsciiNumber);
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
