using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04
{
    public class FibEnum : IEnumerator
    {
        public int max;
        public int a;
        public int b;
        int licznik = 1;

        public FibEnum(int _max)
        {
            max = _max;
            a = 0;
            b = 1;
        }
        public bool MoveNext()
        {
            licznik++;
            int tmp = a;
            a = b;
            b = tmp + b;
            return (licznik < max);
        }
        public void Reset()
        {
            licznik = -1;
            a = 0;
            b = 1;
        }
        object IEnumerator.Current
        {
            get
            {
                return b;
            }
        }
        public int Current
        {
            get
            {
                return b;
            }
        }
    }
}
