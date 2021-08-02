using System;
using System.Collections.Generic;
using System.Text;

namespace eLink_Section_2
{
    public class Menu
    {
        public void First()
        {
            bool end = false;
            while (!end)
            {
                int choose;
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine(" 1. Вывод простых чисел до N-го числа \n" +
                                     " 2. Вывод суммы 1-го, 2-го, 101-го, 1001-го и 10001-го простого числа \n" +
                                     " 3. Запись в csv файл 10001 простых чисел \n" +
                                     " 4. Назад "
                                     );

                    choose = int.Parse(Console.ReadLine());

                    if (choose >= 1 && choose <= 4)
                    {
                        break;
                    }
                }

                PrimeNumbers primeNumbers = new PrimeNumbers();

                switch (choose)
                {
                    case 1:
                        Console.WriteLine("\nВведите N-ое число\n");
                        int n;
                        n = int.Parse(Console.ReadLine());
                        primeNumbers.SearchPrimesUpToN(n);
                        break;
                    case 2:
                        primeNumbers.SumPrimes();
                        break;
                    case 3:
                        primeNumbers.WritePrimesToAFile();
                        break;
                    case 4:
                        end = true;
                        break;
                }
            }

        }

        public void Second()
        {
        }


        public void Third()
        {
            UlamSpiral ulamSpiral = new UlamSpiral();
            Console.WriteLine("\nВведите N-ое число\n");
            int n;
            n = int.Parse(Console.ReadLine());
            ulamSpiral.CreateSpiral(n);
            ulamSpiral.PaintSpiral();
        }
    }
}
