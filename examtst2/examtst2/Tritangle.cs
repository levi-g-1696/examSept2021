using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examtst2
{
    class Tritangle : Figure
    {
        char tritangleChar = '#';
        ConsoleColor color = ConsoleColor.Green;
        public Tritangle(int x, int y, int size) : base()

        {
            this.TheFigurChar = tritangleChar;
            if (size >= 2)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size-i; j++)
                    {
                        this.RegisterNewPositionUsed(new Position(x+i , y + j+i, tritangleChar, color));
                    }
                }

            }
            else throw new ApplicationException("wrong tritangle size");

        }

    }
}
    