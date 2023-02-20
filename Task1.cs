using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadaniaMichal
{
    /*Zadanie 1
 Na wejsciu dane: [6,5,3,3,8,1]
Wynik: liczba n. Ile jest liczby wiekszych od liczby n.
Ile jest dziur od 1 do n.
 */

    public class Task1
    {
        public static void Perform_1()
        {
            int[] data = new int[] { 6, 5, 3, 3, 8, 1 };

            int n = data[0];

            int numbersGreaterThan = CountGreaterThan(data, n);
            int numbersOfGaps = CountGaps(data, n);

            Console.WriteLine("Numbers greater than: " + numbersGreaterThan);
            Console.WriteLine("Numbers of gaps: " + numbersOfGaps);

            Console.ReadLine();
        }

        private static int CountGreaterThan(int[] data, int n)
        {
            int counter = 0;

            for (int dataIndex = 1; dataIndex < data.Length; dataIndex++)
            {
                int currentItem = data[dataIndex];

                if (currentItem > n)
                {
                    counter = counter + 1;
                }
            }
            return counter;
        }

        private static int CountGaps(int[] data, int n)
        {
            int counter = 0;

            for (int currentNaturalNumber = 1; currentNaturalNumber <= n; currentNaturalNumber++)
            {
                int occurCounter = 0;

                for (int dataIndex = 1; dataIndex < data.Length; dataIndex++)
                {
                    int currentItem = data[dataIndex];

                    if (currentNaturalNumber == currentItem)
                    {
                        occurCounter = occurCounter + 1;
                    }
                }
                if (occurCounter == 0)
                {
                    counter = counter + 1;
                }
            }
            return counter;
        }
    }
}
