using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_2_пятнашки__Reboot
{
    class Game2 : Game
    {
        public Game2(int[] numbers)
            : base(numbers)
        {

        }
        public Game2(int size)
            : base(size)
        {
            RandomArr();
        }
        public override void ChangeKnuckles(int value, Location n, Location zero)
        {
            base.ChangeKnuckles(value, n, zero);
        }
        public virtual void RandomArr()
        {
            Random Gen = new Random();
            int[] numbers = new int[field.Length];
            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                if (i != numbers.Length - 1)
                {
                    numbers[i] = i + 1;
                }
            }
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    int index = Gen.Next(0, field.Length);
                    for (int k = 0; k < numbers.Length; k++)
                    {
                        while (numbers[index] == numbers[k] && numbers[k] == -1)
                        {
                            index = Gen.Next(0, field.Length);
                        }
                    }
                    field[i, j] = numbers[index];
                    numbers[index] = -1;
                }
            }
        }
        public bool CheckWinSequence()
        {
            int[] numbers = new int[field.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == numbers.Length - 1)
                {
                    numbers[i] = 0;
                }
                else
                {
                    numbers[i] = i + 1;
                }
            }
            int count = 0;
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] != numbers[count])
                    {
                        return false;
                    }
                    count++;
                }
            }
            return true;
        }
    }
}
