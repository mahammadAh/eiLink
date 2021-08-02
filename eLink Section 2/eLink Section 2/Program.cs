using System;

namespace eLink_Section_2
{
    class Program
    {

        static void Main(string[] args)
        {
            Menu menu = new Menu();
            bool end = false;
            while (!end)
            {
                int choose;
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine(" 1. Первое задание \n" +
                                      " 2. Второе задание \n" +
                                      " 3. Третье задание \n" +
                                      " 4. Выход");

                    choose = int.Parse(Console.ReadLine());

                    if (choose >= 1 && choose <= 4)
                    {
                        break;
                    }
                }
                switch (choose)
                {
                    case 1:
                        menu.First();
                        break;
                    case 2:
                        menu.Second();
                        break;
                    case 3:
                        menu.Third();
                        break;
                    case 4:
                        end = true;
                        break;

                }
            }
        }
    }
}
