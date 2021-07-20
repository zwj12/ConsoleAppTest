using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Interview
{

    public class X
    {
        public virtual void Fun1(int i)
        {
            Console.WriteLine(i);
        }

        public void Fun2(X x)
        {
            x.Fun1(1);
            Fun1(5);
        }
    }

    public class Y:X
    {
        public override void Fun1(int i)
        {
            base.Fun1(i+1);
        }

        public static void Main2()
        {
            Y y = new Y();
            X x = new X();
            x.Fun2(y);
            y.Fun2(x);

        }
    }


}
