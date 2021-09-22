using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examtst2
{
    enum FigurTypes
    {
        line = 0, tritangle = 1, rectangle=2
    }
    class InstanceManaging
    {
        public int figureNumber;
       
        List<Figure> figures;
        public InstanceManaging()
        {

             figures = new List<Figure>();
        }
        public List<Figure> RandomInitFigures(int gameNum)
        {
             figures = new List<Figure>();
            int horizontal;
            int size;
            int sizeX;
            int sizeY;
            int topX;
            int topY;
            FigurTypes figtype;
            Figure nextFigure;
            Random rnd = new Random();
            if (gameNum == 1) { figureNumber = rnd.Next(3, 7); }
            else figureNumber++;
            for (int i = 0; i < figureNumber; i++)
            {
                figtype = (FigurTypes)rnd.Next(0, 3);
                switch (figtype)
                {
                    case FigurTypes.line:
                        horizontal = rnd.Next(0, 2);//  line
                        size = rnd.Next(2, 11);
                        if (horizontal == 1) { sizeX = size; sizeY = 1; }
                        else
                        {
                            sizeX = 1; sizeY = size;
                        }
                        topX = rnd.Next(0, 80 - sizeX);
                        topY = rnd.Next(0, 25 - sizeY);
                        nextFigure = new Line(topX, topY, sizeX, sizeY);
                        this.figures.Add(nextFigure);
                        break;
                    case FigurTypes.tritangle:
                        size = rnd.Next(2, 10);
                        topX = rnd.Next(0, 80 - size);
                        topY = rnd.Next(0, 25 - size);
                        nextFigure = new Tritangle(topX, topY, size);
                        this.figures.Add(nextFigure);
                        break;
                    case FigurTypes.rectangle:
                        sizeX = rnd.Next(2, 11);
                        sizeY = rnd.Next(2, 11);
                        if (sizeX == 2 && sizeY == 2) { sizeY = 3; sizeX = 3; }
                        topX = rnd.Next(0, 80 - sizeX);
                        topY = rnd.Next(0, 25 - sizeY);
                        nextFigure = new Rectangle(topX, topY, sizeX, sizeY);
                        this.figures.Add(nextFigure);
                        break;
                }
                
            }
            return figures;      
        }

    }
}

