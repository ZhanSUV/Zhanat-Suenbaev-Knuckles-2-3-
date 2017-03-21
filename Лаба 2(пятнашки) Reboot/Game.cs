using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_2_пятнашки__Reboot
{
    class Game
    {
        public readonly int[,] field;
        public Game(int[] numbers)
        {
            this.field = new int[(int)Math.Sqrt(numbers.Length), (int)Math.Sqrt(numbers.Length)];
            FillingFromArr(numbers);
        }
        public Game(int size)
        {
            this.field = new int[size, size];
        }
        private void FillingFromArr(int[] numbers)
        {
            int count = 0;
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (count == numbers.Length)
                    {
                        field[i, j] = 0;
                    }
                    else
                    {
                        field[i, j] = numbers[count];
                        count++;
                    }
                }
            }          
        }
        public bool CheckNumbers(int[] numbers)
        {
            int size = (int)Math.Sqrt(field.Length);
            return CheckSquareField(numbers, size) && CheckCorrectSequence(numbers) && CheckPositiveNumbers(numbers) && CheckUniqueNumbers(numbers);
        }
        public bool CheckPositiveNumbers(int[] numbers)
        {
            bool check = true;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    check = false;
                    break;
                }
            }
            return check;
        }
        public bool CheckUniqueNumbers(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (i != j)
                    {
                        if (numbers[i] == numbers[j])
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        public bool CheckCorrectSequence(int[] numbers)
        {
            int count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (count == numbers[j])
                    {
                        count++;
                        break;
                    }
                }
            }
            if (count == numbers.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckSquareField(int[] numbers, int size)
        {
            if (Math.Pow(size, 2) == numbers.Length)
            {
                return true;
            }
            return false;
        }
        public bool Shift(int value, Location n, Location zero)
        {
            Location difference = n - zero;
            if (((difference.x == 1 || difference.x == -1) && difference.y == 0) || (difference.x == 0 && (difference.y == 1 || difference.y == -1)))
            {
                return true;
            }
            return false;
        }
        public void ChangeKnuckles(int value, Location n, Location zero)
        {
            field[zero.y,zero.x] = field[n.y,n.x];
            field[n.y,n.x] = 0;
        }
    }
}
