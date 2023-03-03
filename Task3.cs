using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ZadaniaMichal.Task2;
using System.Runtime.CompilerServices;

namespace ZadaniaMichal
{
    internal class Task3
    {
        /*
 * Lotto
 * a) Program losuje 6 unikalnych liczb z zakresu 1 do 49 wlacznie.
 * b) Program pobiera od uzytkownika 6 unikalnych liczb.
 * c) Nalezy zliczyc trafienia pomiedzy a i b
 * 
 * Wyswietlic liczby z punktu a, b i c
 * 
 *computer:  5 6 7 11 1 0
 *user:      2 6 9 3  1 11
 *hits:      3 - kolejnosc nie ma znaczenia

bonus: liczba 49 ma byc paramatryzowana. Uzytkownik moze podac liczbe recznie.
 * 
*/

        //kolekcja typu zbior zapewnia unikalnosc

        public class Task3Result
        {           
            public ISet<int> computerNumbers;
            public ISet<int> userNumbers;
            public int countedHits;

            public Task3Result(ISet<int> computerNumbers,
                               ISet<int> userNumbers,
                               int countedHits)
            {
                this.computerNumbers = computerNumbers;
                this.userNumbers = userNumbers;
                this.countedHits = countedHits;
            }
        }

        public static Task3Result Perform_3(int upperBound)
        {
            ISet<int> computerNumbers = RandomUniqueNumber(upperBound).ToImmutableSortedSet();

            ISet<int> userNumbers = RetriveUserNumbers(upperBound).ToImmutableSortedSet();

            int countedHits = CountHits(userNumbers, computerNumbers);

            return new Task3Result(computerNumbers, userNumbers, countedHits);
        }

        public static void Perform_3()
        {
            int upperBound = 10;

            Task3Result task3Result = Perform_3(upperBound);

            Console.WriteLine("\n");

            Console.Write("User numbers are: ");
            PrintCollection(task3Result.userNumbers);

            Console.Write("Computer numbers are: ");
            PrintCollection(task3Result.computerNumbers);

            Console.WriteLine("Hits: " + task3Result.countedHits);
        }

        private static ISet<int> RandomUniqueNumber(int upperBound)
        {
            Random rnd = new Random();
            ISet<int> randomNumbers = new HashSet<int>();

            while (randomNumbers.Count < 6)
            {
                randomNumbers.Add(rnd.Next(upperBound) + 1);                
            }

            //PrintCollection(randomNumbers);
            return randomNumbers;
        }

        private static void PrintCollection(ISet<int> randomNumbers)
        {
            foreach (var item in randomNumbers)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");
        }

        private static ISet<int> RetriveUserNumbers(int upperBound)
        {
            ISet<int> userNumbers = new HashSet<int>();

            int currentUserNumber;

            while (userNumbers.Count < 6)
            {
                Console.WriteLine("Please enter your value number: " + (userNumbers.Count+1));

                bool isSuccess = Int32.TryParse(Console.ReadLine(),out currentUserNumber);
                if (isSuccess && currentUserNumber > 0 && currentUserNumber <= upperBound)
                {
                    userNumbers.Add(currentUserNumber);
                }               
            }
            return userNumbers;
        }

        private static int CountHits(ISet<int> userNumbers, ISet<int> computerNumbers)
        {
            int counter = 0;

            foreach(int userNumber in userNumbers)
            {
                foreach (int computerNumber in computerNumbers)
                {
                    if (userNumber == computerNumber)
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }
    }
}
