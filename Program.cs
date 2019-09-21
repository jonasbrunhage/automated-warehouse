using System;
using System.Threading;

namespace Automated_Warehouse
{
    class Program
    {
        
        static string[,] shelf2 = new string[0, 0];
        static Shelf shelf = new Shelf();

        static int column = 0;
        static int row = 0;
        static int offset = 1;
        static int countArray(string[,] multiArray)
        {
            int availibleSlots = 0;

            for (int i = 0; i < multiArray.GetLength(0); i++)
            {
                for (int j = 0; j < multiArray.GetLength(1); j++)
                {
                    if (multiArray[i, j] != null)
                    {
                        //mark selected slot

                    }
                    else
                    {
                        //mark unselected slot
                        availibleSlots++;

                    }
                }

            }
            return availibleSlots;
        }
        static void Main(string[] args)
        {
           
            bool runProgram = true;
            //countArray(shelf);
            while (runProgram)
            {
                Menu();
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                Console.Clear();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.D1:
                        CreateShelf();
                        break;

                    case ConsoleKey.D2:
                        PrintShelf();
                        break;

                    case ConsoleKey.D3:
                        PlacePackage();
                        break;

                    case ConsoleKey.D4:
                        FetchPackage();
                        break;
                    case ConsoleKey.D5:
                        runProgram = false;
                        break;

                }

            }

        }
        static void Menu()
        {
            Console.Clear();
            Console.SetCursorPosition(2, 2);
            Console.WriteLine("1. Create shelf");
            Console.SetCursorPosition(2, 3);
            Console.WriteLine("2. Print shelf");
            Console.SetCursorPosition(2, 4);
            Console.WriteLine("3. Place package");
            Console.SetCursorPosition(2, 5);
            Console.WriteLine("4. Fetch package");
            Console.SetCursorPosition(2, 6);
            Console.WriteLine("5. Exit");
        }
        static void CreateShelf()
        {
            Console.SetCursorPosition(2, 2);
            Console.WriteLine("Name:");
            Console.SetCursorPosition(2, 4);
            Console.WriteLine("Row:");
            Console.SetCursorPosition(2, 6);
            Console.WriteLine("Column:");

            Console.SetCursorPosition("Name:".Length + 2, 2);
            shelf.Name = Console.ReadLine();
            Console.SetCursorPosition("Row:".Length + 2, 4);
            row = int.Parse(Console.ReadLine());
            Console.SetCursorPosition("Column:".Length + 2, 6);
            column = int.Parse(Console.ReadLine());

            shelf.Containers = new Package[row, column];
            Console.Clear();
            Console.SetCursorPosition(2, 2);
            Console.WriteLine("Shelf succesfully created");
            Console.ReadKey();
        }
        static void PrintShelf()
        {

            int availibleSlots = 0;
            for (int i = 0; i < shelf.Containers.GetLength(0); i++)
            {
                for (int j = 0; j < shelf.Containers.GetLength(1); j++)
                {
                    if (shelf.Containers[i, j] != null)
                    {
                        //mark selected slot
                        Console.Write("| X |");
                    }
                    else
                    {
                        //mark unselected slot
                        availibleSlots++;
                        Console.Write("|   |");
                    }
                }
                Console.WriteLine("");
            }
            //shelf[row, column]=true;
            //int slots = int.Parse(shelf[row, column]);

            Console.SetCursorPosition(2, shelf.Containers.GetLength(1) + 2);
            Console.WriteLine($"Name: {shelf.Name}");
            Console.SetCursorPosition(2, shelf.Containers.GetLength(1) + 4);
            Console.WriteLine($"Availible slots: {availibleSlots}");

            //Console.WriteLine($"Availible slots: {countArray(shelf)}");
            Console.SetCursorPosition(2, shelf.Containers.GetLength(1) + 6);
            Console.WriteLine("Press any key to continue");

            Console.ReadKey();
        }
        static void PlacePackage()
        {
            Package package = new Package();
            Console.SetCursorPosition(2, 2);
            Console.WriteLine("Content:");
            Console.SetCursorPosition(2, 4);
            Console.WriteLine("Row:");
            Console.SetCursorPosition(2, 6);
            Console.WriteLine("Column:");
            
            Console.SetCursorPosition("Content:".Length + 2, 2);
            package.Content = Console.ReadLine();
            Console.SetCursorPosition("Row:".Length + 2, 4);
            row = int.Parse(Console.ReadLine()) - offset;
            Console.SetCursorPosition("Column:".Length + 2, 6);
            column = int.Parse(Console.ReadLine()) - offset;
            Console.Clear();

            if (shelf.Containers[row, column] == null)
            {
                shelf.Containers[row, column] = package;
                Console.SetCursorPosition(2, 2);
                Console.WriteLine("Success");
                Thread.Sleep(2000);
            }
            else
            {
                Console.SetCursorPosition(2, 2);
                Console.WriteLine("Slot occupied");
                Thread.Sleep(2000);
            }
        }
        static void FetchPackage()
        {
            Console.SetCursorPosition(2, 2);
            Console.WriteLine("Row: ");
            Console.SetCursorPosition(2, 4);
            Console.WriteLine("Column: ");

            Console.SetCursorPosition("Row:".Length + 2, 2);
            row = int.Parse(Console.ReadLine()) - offset;
            Console.SetCursorPosition("Column:".Length + 2, 4);
            column = int.Parse(Console.ReadLine()) - offset;
            Console.Clear();

            if (shelf.Containers[row, column] != null)
            {
                Console.SetCursorPosition(2, 2);
                Console.WriteLine("Package successfully retrived");
                Package package = shelf.Containers[row, column];
                shelf.Containers[row, column] = null;
                Console.SetCursorPosition(2, 4);
                Console.WriteLine($"Content: {package.Content}");
                Console.SetCursorPosition(2, 6);
                Console.WriteLine("Press any key to continue");
            }
            else
            {
                Console.SetCursorPosition(2, 2);
                Console.WriteLine("Slot empty");
            }

            Console.ReadKey();
            
        }
    }
}

