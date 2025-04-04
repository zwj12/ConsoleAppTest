using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Mapper
{
    public class Position
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public override string ToString()
        {
            return $"X={X}, Y={Y}, Z={Z}"; 
        }
    }
}
