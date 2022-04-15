using ConsoleAppTest.AccessModifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest1.AccessModifiers1
{
    class TestB
    {
        public void test()
        {
            TestA testA = new TestA();
            testA.name = "";
        }
    }

    class TestC : TestA
    {
        public void test()
        {
            this.name = "";
            this.sex = "";
        }
    }
}
