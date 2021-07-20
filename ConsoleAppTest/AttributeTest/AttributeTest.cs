using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.AttributeTest
{

    [Myself("MyClass", Author = "Me")]
    class AttributeTest
    {
        static void Main(string[] args)
        {
            string str0 = "Michael";
            string str = "Hello World!";
            Console.WriteLine(str);
            Console.WriteLine(str0);

            Attribute[] attributes = Attribute.GetCustomAttributes(typeof(AttributeTest));
            //IEnumerable<Attribute> attributes = typeof(MyClass).GetCustomAttributes();
            foreach (var item in attributes)
            {
                if (item is MyselfAttribute)
                {
                    MyselfAttribute attribute = item as MyselfAttribute;
                    Console.WriteLine(attribute.ClassName + " " + attribute.Author); //MyClass Me
                }
            }

            Console.ReadKey();
        }
    }


    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = true)]
    //其中，枚举组合AttributeTargets指定该特性生效的范围，默认为All即所有范围；
    //布尔值Inherited指定应用该特性的成员在派生类中是否会继承该特性，默认为true；
    //布尔值AllowMultiple指定能否为同一个元素指定多个此特性，默认为false
    public class MyselfAttribute : Attribute
    {
        public string ClassName { get; private set; }
        public string Author;

        public MyselfAttribute(string className)
        {
            this.ClassName = className;
        }
    }
}
