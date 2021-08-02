using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace eLink_Section_2
{
    public class PrimeNumbers
    {
        public void SearchPrimesUpToN(int n)
        {
            int check;
            for (int i = 2; i <= n; i++)
            {
                check = 0;
                for (int j = 1; j <= i; j++)
                {
                    if (i % j == 0)
                    {
                        check++;
                    }

                    if (i > 2 && i % 2 == 0)
                    {
                        check += 2;
                        break;
                    }

                    if (check > 2)
                    {
                        break;
                    }
                }

                if (check <= 2)
                {
                    Console.Write(i + " ");
                }
            }
        }

        public void SumPrimes()
        {
            int counter = 1;
            int sum = 0;
            int check;
            for (int i = 2; counter <= 10001; i++)
            {
                check = 0;
                for (int j = 1; j <= i; j++)
                {
                    if (i % j == 0)
                    {
                        check++;
                    }

                    if (i > 2 && i % 2 == 0)
                    {
                        check += 2;
                        break;
                    }

                    if (check > 2)
                    {
                        break;
                    }
                }

                if (check <= 2)
                {
                    if (counter == 1 || counter == 2 || counter == 101 || counter == 1001 || counter == 10001)
                    {
                        sum += i;
                        Console.WriteLine(counter + " : " + i + '\n' + "Sum : " + sum + "\n\n");
                    }

                    counter++;
                }
            }
        }

        public void WritePrimesToAFile()
        {
            var csv = new StringBuilder();
            int counter = 1;
            int check;
            for (int i = 2; counter <= 10001; i++)
            {
                check = 0;
                for (int j = 1; j <= i; j++)
                {
                    if (i % j == 0)
                    {
                        check++;
                    }

                    if(i>2 && i % 2 == 0)
                    {
                        check += 2;
                        break;
                    }

                    if (check > 2)
                    {
                        break;
                    }
                }

                if (check <= 2)
                {
                    counter++;
                    Console.Write(i + " ");
                    csv.AppendLine(i.ToString());
                }

            }

            File.WriteAllText("data.csv", csv.ToString());
        }
    }
}
