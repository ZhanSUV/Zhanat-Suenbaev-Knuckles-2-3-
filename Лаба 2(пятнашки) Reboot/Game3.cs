using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_2_пятнашки__Reboot
{
    class Game3 : Game2
    {
        public List<int> history = new List<int>();
        public Game3(int[] numbers)
            : base(numbers)
        {

        }
        public Game3(int size)
            : base(size)
        {
           
        }
        public void History(int value)
        {
            history.Add(value);
        }
    }
}
