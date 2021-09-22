using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examtst2
{
    class Line : Figure
    {
        /*  public override List<Position> GetUsedPositions()
          {
              throw new NotImplementedException();
          } */

        char lineChar = '=';
        ConsoleColor color = ConsoleColor.DarkRed;

        public Line() : base()
        {
            TheFigurChar = lineChar;
            FigureType = FigType.Line;
        }

        public Line(int x, int y, int sizeX, int sizeY) : base()

        {
            TheFigurChar = lineChar;
            FigureType = FigType.Line;
            if ((sizeX == 1) || (sizeY == 1))
            {
                if (sizeX == 1)
                {
                    for (int i = 0; i < sizeY; i++)
                    {
                        this.RegisterNewPositionUsed(new Position(x, y + i, lineChar, color));

                    }
                }
                else
                {
                    for (int i = 0; i < sizeX; i++)
                    {
                        this.RegisterNewPositionUsed(new Position(x+i, y , lineChar, color));

                    }

                }
            }

            else throw new ApplicationException(" wrong line size ");
            
            

        }


    }
}

