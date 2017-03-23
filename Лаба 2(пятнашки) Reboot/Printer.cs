using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_2_пятнашки__Reboot
{
    class Printer
    {
        public static void Field(Game knuckles)
        {
            for (int i = 0; i < knuckles.Field.GetLength(0); i++)
            {
                Console.Write("\t");
                for (int j = 0; j < knuckles.Field.GetLength(1) ; j++)
                {
                    Console.Write(knuckles[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }
        //public static void Win()
        //{
        //    Console.WriteLine("YOU WIN!!!");
        //}
        public static void InfoAboutTurns(List<int> history)
        {
            Console.WriteLine("Count of your turns = {0}", history.Count);
        }
        //public static void AskNewGame()
        //{
        //    Console.Write("Do you want to play a new game: YES/NO ");
        //}
        //public static void AskNumber()
        //{
        //    Console.Write("Type your number to move to zero ");
        //}
        //public static void InfoAboutRollback()
        //{
        //    Console.WriteLine("You can rollback your turn. Just add 'r' to rollback");
        //}
        //public static void InfoAboutRandom()
        //{
        //    Console.WriteLine("You can random your arr. If you want to random arr, add 'random'");
        //}
        //public static void AskSize()
        //{
        //    Console.Write("Type a size of your field ");
        //}
        //public static void End()
        //{
        //    Console.WriteLine("Good bye");
        //    Console.WriteLine("Add enter to exit from the game");
        //    Console.ReadLine();
        //}
        //public static void ClearingConsole()
        //{
        //    Console.Clear();
        //}
        //public static void AskInputParameters()
        //{
        //    Console.WriteLine("What do you input: size(1) or arr(2)?");
        //    Console.Write("Choose a number = ");
        //}
        //public static void AskTypeGame()
        //{
        //    Console.WriteLine("What Game do you choose: \n1)Game1 without winning? \n2)Game2 - normal with winning? \n3)Game3 with history of your turns and rollbacks?");
        //    Console.Write("Choose a number of Game = ");
        //}
        public static void History(List<int> history)
        {
            Console.WriteLine("Your history of turns: ");
            int count = 1;
            foreach (int i in history)
            {
                Console.Write(count + ") " + i + "\t");
                count++;
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
