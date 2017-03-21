using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_2_пятнашки__Reboot
{
    // Пока сложно
    class Location
    {
        public int x;
        public int y;
        public Location(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Location(int value, int[,] field)
        {
            GetLocation(value, field);
        }
        public void GetLocation(int value, int[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == value)
                    {
                        this.x = j;
                        this.y = i;
                    }
                }
            }
        }
        public static Location operator -(Location value, Location zero)
        {
            return new Location(value.x - zero.x, value.y - zero.y);
        }
    }
}
