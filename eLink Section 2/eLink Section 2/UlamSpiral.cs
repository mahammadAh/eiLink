using System;
using System.Collections.Generic;
using System.Text;

namespace eLink_Section_2
{
   public class UlamSpiral
    {
       private int n;
       private int[,] arr ;
        public void CreateSpiral(int n)
        {
            this.n = n;
            arr = new int[n,n];
            int n2 = n * n;
            int i = n-1;
            int j = n-1;
            int counter = 0;
            int iCounterDown = n-1;
            int iCounterTop = 0;
            int jCounterRight = n-1;
            int jCounterLeft = 0;
            bool iFor = false;
            bool iToDown = false;
            bool jToRight = false;
            while (true)
            {
                if (iFor)
                {
                    if (iToDown)
                    {
                        for (; i <= iCounterDown; i++, n2--)
                        {
                            arr[i, j] = n2;
                            counter++;
                        }
                        i--;
                        j--;
                        jCounterRight--;
                        iToDown = false;
                        iFor = false;
                    }
                    else
                    {
                        for ( ; i >= iCounterTop; i--, n2--)
                        {
                            arr[i, j] = n2;
                            counter++;
                        }
                        i++;
                        j++;
                        jCounterLeft++;
                        iToDown = true;
                        iFor = false;
                    }
                }
                else
                {
                    if (jToRight)
                    {
                        for ( ; j <= jCounterRight; j++ , n2--)
                        {
                            arr[i, j] = n2;
                            counter++;
                        }
                        j--;
                        i++;
                        iCounterTop++;
                        jToRight = false;
                        iFor = true;
                    }
                    else
                    {
                        for ( ; j>=jCounterLeft; j-- , n2--)
                        {
                            arr[i, j] = n2;
                            counter++;

                        }
                        j++;
                        i--;
                        iCounterDown--;
                        jToRight = true;
                        iFor = true;
                    }
                }

                if (counter >= (n * n))
                {
                    break;
                }

 
            }

        }

       public void PaintSpiral()
        {
            int sum = 0;
            int product = 1;
            Console.Write("\n\n");
            for (int i = 0; i < n; i++)
            {
                Console.Write("\t\t");
                for (int j = 0; j < n; j++)
                {
                    if (i == j || (i+j)==(n-1))
                    {
                        sum += arr[i, j];
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(arr[i, j] + "\t", Console.ForegroundColor);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    Console.Write(arr[i, j] + "\t");
                }
                Console.Write("\n\n\n");
            }
            product = arr[0, 0]*arr[0,n-1]*arr[n-1,0]*arr[n-1,n-1];
            Console.WriteLine("Sum : " + sum);
            Console.WriteLine("Product : " + product);
            Console.ReadLine();
        }

    }
}
