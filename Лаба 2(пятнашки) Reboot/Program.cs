using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_2_пятнашки__Reboot
{
    class Program
    {
        static void Main(string[] args)
        {
            ChooseInputParameter();
        }
        public static void PlayGame(Game3 player1)
        {
            Print.ClearingConsole();
            while (!player1.CheckWinSequence())
            {
                Print.PrintField(player1.field);
                Print.AskNumber();
                int value = Convert.ToInt32(Console.ReadLine());
                Location n = new Location(value, player1.field);
                Location zero = new Location(0, player1.field);
                if (player1.Shift(value, n, zero))
                {
                    player1.ChangeKnuckles(value, n, zero);
                    player1.History(value);
                }
                Print.ClearingConsole();
                Print.PrintHistory(player1.history);
            }
            Print.Win(player1.history.Count);
            Print.AskNewGame();
            if (Print.ReadUserAnswer().ToLower() == "yes")
            {
                Print.AskSize();
                int size = Convert.ToInt32(Console.ReadLine());
                player1 = new Game3(size);
                PlayGame(player1);
            }
            else
            {
                Print.End();
            }
        }
        public static int[] CreateArr() // здесь должно быть считывание массива
        {
            int[] numbers = new int[9];
            int[] numbers1 = new int[9];
            Random Gen = new Random();
            for (int i = 0; i < numbers1.Length; i++)
            {
                if (i == numbers1.Length - 1)
                {
                    numbers1[i] = 0;
                }
                else
                {
                    numbers1[i] = i + 1;
                }
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                int index = Gen.Next(0, numbers.Length);
                for (int k = 0; k < numbers.Length; k++)
                {
                    while (numbers1[index] == numbers1[k] && numbers1[k] == -1)
                    {
                        index = Gen.Next(0, numbers.Length);
                    }
                }
                numbers[i] = numbers1[index];
                numbers1[index] = -1;
            }
            return numbers;
        }
        public static void ChooseInputParameter()
        {
            Print.AskInputParameters();
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1) // size
            {
                Print.AskSize();
                int size = Convert.ToInt32(Console.ReadLine());
                Game3 player1 = new Game3(size);
                PlayGame(player1);
            }
            else if (choice == 2) // arr
            {
                int[] numbers = CreateArr();
                Game3 player1 = new Game3(numbers);
                if (player1.CheckNumbers(numbers))
                {
                    PlayGame(player1);
                }
                else
                {
                    throw new Exception("Wrong measure");
                }
            }
            else
            {
                ChooseInputParameter();
            }
        }
    }
}
