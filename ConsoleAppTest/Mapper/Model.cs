using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Mapper
{
    public class Model
    {
        public int SomeValue { get; set; }
        public string AnotherValue { get; set; }
        public WeekDay Day { get; set; }

        public Position Position { get; set; }

        public Model()
        {
            Position = new Position();
        }

        public override string ToString()
        {
            return $"SomeValue={SomeValue}, AnotherValue={AnotherValue}, Day={Day}, Position={Position}";
        }
    }
}
