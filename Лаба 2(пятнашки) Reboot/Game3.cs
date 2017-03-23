using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_2_пятнашки__Reboot
{
    class Game3 : Game2
    {
        public readonly List<int> history;
        public Game3(int[] numbers)
            : base(numbers)
        {
            this.history = new List<int>();
        }
        public Game3(int size)
            : base(size)
        {
            this.history = new List<int>();
        }
        public void History(int value)
        {
            history.Add(value);
        }
        public void Rollback()
        {
            if (!(history.Count - 1 == -1))
            {
                int lastValue = history[history.Count - 1];
                history.Remove(lastValue);
                Location n = new Location(lastValue, field);
                Location zero = new Location(0, field);
                ChangeKnuckles(lastValue, n, zero);
            }
        }
    }
}
