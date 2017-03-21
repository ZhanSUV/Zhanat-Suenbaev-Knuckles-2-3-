using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_2_пятнашки__Reboot
{
    class Print
    {
        public static void PrintField(int[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                Console.Write("\t");
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }
        public static void Win(int count)
        {
            Console.WriteLine("YOU WIN!!!");
            Console.WriteLine("Numbers of turns = {0}", count);
        }
        public static void AskNewGame()
        {
            Console.Write("Do you want to play a new game: YES/NO ");
        }
        public static void AskNumber()
        {
            Console.Write("Type your number to move to zero ");
        }
        public static void AskSize()
        {
            Console.Write("Type a size of your field ");
        }
        public static void End()
        {
            Console.WriteLine("Good bye");
            Console.WriteLine("Add enter to exit from the game");
            Console.ReadLine();
        }
        public static string ReadUserAnswer()
        {
            return Console.ReadLine();
        }
        public static void ClearingConsole()
        {
            Console.Clear();
        }
        public static void AskInputParameters()
        {
            Console.WriteLine("What do you input: size(1) or arr(2)?");
            Console.Write("Choose a number = ");
        }
        public static void PrintHistory(List<int> history)
        {
            Console.WriteLine("Your history of turns: ");
            int count = 1;
            foreach (int i in history)
            {
                Console.Write(count + ") " + i + " => 0 \t");
                count++;
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
