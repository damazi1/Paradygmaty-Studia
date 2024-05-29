using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04
{
    public class Fib :IEnumerable
    {
        private int max;
            public Fib(int _max)
        {
            max = _max;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        public FibEnum GetEnumerator()
        {
            return new FibEnum(max);
        }
    }
}
