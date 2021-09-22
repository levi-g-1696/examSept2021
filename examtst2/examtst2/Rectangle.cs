using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examtst2
{
    class Rectangle: Figure
    {
        char rectangleChar = '\u05DD';  // ם
        ConsoleColor color = ConsoleColor.Magenta;
        public Rectangle(int x, int y, int sizeX, int sizeY) : base()

        {
            TheFigurChar = rectangleChar;
            FigureType = FigType.Line;
            if (sizeX == 2 && sizeY == 2) { throw new ApplicationException(" wrong sqware size (2) "); }
            if ((sizeX >= 2) && (sizeX <= 10) && (sizeY >= 2) && (sizeY <= 10))
            {
                for (int i = 0; i < sizeX; i++)
                {
                    for (int j = 0; j < sizeY; j++)
                    {
                        this.RegisterNewPositionUsed(new Position(x + i, y + j, rectangleChar, color));
                    }

                }
            }




            else throw new ApplicationException(" wrong rectangle size ");



        }
    }
}
