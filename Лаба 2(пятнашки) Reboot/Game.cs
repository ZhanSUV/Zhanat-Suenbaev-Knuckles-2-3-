using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_2_пятнашки__Reboot
{
    class Game
    {
        public int[,] field;
        public Game(int[] numbers)
        {
            this.field = new int[(int)Math.Sqrt(numbers.Length), (int)Math.Sqrt(numbers.Length)];
            FillingFromArr(numbers);
        }
        protected Game(int size)
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
            CheckNumbers();      
        }
        private bool CheckNumbers()
        {
            int size = (int)Math.Sqrt(field.Length);
            return CheckSquareField() && CheckCorrectSequence() && CheckPositiveNumbers() && CheckUniqueNumbers();
        }
        private bool CheckPositiveNumbers()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i,j] < 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool CheckUniqueNumbers()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int i1 = 0; i1 < field.GetLength(0); i1++)
                {
                    if (i1 == i)
                    {
                        for (int j = 0; j < field.GetLength(1); j++)
                        {
                            for (int j1 = 0; j1 < field.GetLength(1); j1++)
                            {
                                if (j1 == j)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                } 
            }
            return true;
        }
        private bool CheckCorrectSequence()
        {
            int[] correctSequence = new int[field.Length];
            int count = 0;
            for (int i = 0; i < correctSequence.Length; i++)
            {
                for (int j = 0; j < correctSequence.Length; j++)
                {
                    if (count == correctSequence[j])
                    {
                        count++;
                        break;
                    }
                }
            }
            if (count == field.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckSquareField()
        {
            double size = Math.Sqrt(field.Length);
            if (size == ((double)((int)size)))
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
