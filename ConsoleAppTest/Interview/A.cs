using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Interview
{

    public abstract class A
    {
        public A()
        {
            Console.WriteLine('A');
        }

        public virtual void Fun()
        {
            Console.WriteLine("A.Fun()");
        }
    }

    public class B : A
    {
        public B()
        {
            Console.WriteLine('B');
        }

        public new void Fun()
        {
            Console.WriteLine("B.Fun");
        }

        public static void Main1()
        {
            A a = new B();
            a.Fun();
        }
    }



}
