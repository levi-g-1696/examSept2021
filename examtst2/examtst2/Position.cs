using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examtst2
{
    class Position
    {
        public int X { get; set; }// board column num
        public int Y { get; set; }// board line num
        public char TheChar { get; set; }
        public ConsoleColor color { get; set; }

        public Position(int x, int y, char theChar, ConsoleColor color)
        {
            X = x;
            Y = y;
            TheChar = theChar;
            this.color = color;
        }

        public Position( Position position)
        {
            X = position.X;
            Y = position.Y;
            TheChar = position.TheChar;
            this.color = position.color;
        }
    }
}
