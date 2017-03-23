﻿using System;
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
            ChooseTypeGame();
        }
        public static void PlayGame3(Game3 player1)
        {
            Printer.ClearingConsole();
            Printer.InfoAboutRandom();
            Printer.InfoAboutRollback();
            while (!player1.CheckWinSequence())
            {
                int value;
                Printer.Field(player1.field);
                Printer.AskNumber();
                string answer = Console.ReadLine();
                bool number = Int32.TryParse(answer, out value);
                if (!number)
                {
                    if (answer == "r")
                    {
                        player1.Rollback();
                    }
                    else if (answer == "random")
                    {
                        player1.RandomArr();
                    }
                    Printer.ClearingConsole();
                    Printer.History(player1.history);
                }
                else
                {
                    Location n = new Location(value, player1.field);
                    Location zero = new Location(0, player1.field);
                    if (player1.Shift(value, n, zero))
                    {
                        player1.ChangeKnuckles(value, n, zero);
                        player1.History(value);
                    }
                    Printer.ClearingConsole();
                    Printer.History(player1.history);
                }
            }
            Printer.Win();
            Printer.InfoAboutTurns(player1.history);
            Printer.AskNewGame();
            if (Printer.ReadUserAnswer().ToLower() == "yes")
            {
                ChooseTypeGame();
            }
            else
            {
                Printer.End();
            }
        }
        public static void PlayGame2(Game2 player1)
        {
            Printer.ClearingConsole();
            Printer.InfoAboutRandom();
            while (!player1.CheckWinSequence())
            {
                int value;
                Printer.Field(player1.field);
                Printer.AskNumber();
                string answer = Console.ReadLine();
                bool number = Int32.TryParse(answer, out value);
                if (!number)
                {
                    if (answer == "random")
                    {
                        player1.RandomArr();
                    }
                    Printer.ClearingConsole();
                }
                else
                {
                    Location n = new Location(value, player1.field);
                    Location zero = new Location(0, player1.field);
                    if (player1.Shift(value, n, zero))
                    {
                        player1.ChangeKnuckles(value, n, zero);
                    }
                    Printer.ClearingConsole();
                }
            }
            Printer.AskNewGame();
            if (Printer.ReadUserAnswer().ToLower() == "yes")
            {
                ChooseTypeGame();
            }
            else
            {
                Printer.End();
            }
        }
        public static void PlayGame1(Game player1)
        {
            int value;
            Printer.ClearingConsole();
            Printer.Field(player1.field);
            Printer.AskNumber();
            string answer = Console.ReadLine();
            bool number = Int32.TryParse(answer, out value);
            if (!number)
            {
                Printer.ClearingConsole();
            }
            else
            {
                Location n = new Location(value, player1.field);
                Location zero = new Location(0, player1.field);
                if (player1.Shift(value, n, zero))
                {
                    player1.ChangeKnuckles(value, n, zero);
                }
                PlayGame1(player1);
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
        public static void ChooseInputParameterForGame3()
        {
            Printer.ClearingConsole();
            Printer.AskInputParameters();
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1) // size
            {
                Printer.AskSize();
                int size = Convert.ToInt32(Console.ReadLine());
                Game3 player1 = new Game3(size);
                PlayGame3(player1);
            }
            else if (choice == 2) // arr
            {
                int[] numbers = CreateArr();
                Game3 player1 = new Game3(numbers);
                PlayGame3(player1);
            }
            else
            {
                ChooseInputParameterForGame3();
            }
        }
        public static void ChooseInputParameterForGame2()
        {
            Printer.ClearingConsole();
            Printer.AskInputParameters();
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1) // size
            {
                Printer.AskSize();
                int size = Convert.ToInt32(Console.ReadLine());
                Game2 player1 = new Game2(size);
                PlayGame2(player1);
            }
            else if (choice == 2) // arr
            {
                int[] numbers = CreateArr();
                Game2 player1 = new Game2(numbers);
                PlayGame2(player1);
            }
            else
            {
                ChooseInputParameterForGame3();
            }
        }
        public static void ChooseTypeGame()
        {
            Printer.AskTypeGame();
            int number = Convert.ToInt32(Console.ReadLine());
            if (number == 1)
            {
                int[] numbers = CreateArr();
                Game player1 = new Game(numbers);
                PlayGame1(player1);
            }
            else if (number == 2)
            {
                ChooseInputParameterForGame2();
            }
            else
            {
                ChooseInputParameterForGame3();
            }
        }
    }
}
