using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examtst2
{
    public enum FigType
    {
        Line,
        Tritangle,
        Square,
        Rectangle,
        NullFigure

    }

   class SortByXY : IComparer<Position>
    {
        public int Compare(Position p1, Position p2)
        {
            if (p1.Y.CompareTo(p2.Y) == 0)
            {
                return p1.X.CompareTo(p2.X);
            }
            else return p1.Y.CompareTo(p2.Y);
        }

    } 
    
    class Figure : IUsingPositions
    {
        public char TheFigurChar { get; set; }
        public FigType FigureType { get; set; }
        public List<Position> FigurePositions { get; set; }

        public Figure()
        {
            this.TheFigurChar = '@';
            this.FigureType = FigType.NullFigure;
            FigurePositions = new List<Position>();
        }
        public Figure(int x, int y, int sizeX, int sizeY)
        {
            this.TheFigurChar = '@';
            this.FigureType = FigType.NullFigure;
            FigurePositions = new List<Position>();
        }

        public Figure(int x, int y, int size)
        {
            this.TheFigurChar = '@';
            this.FigureType = FigType.NullFigure;
            FigurePositions = new List<Position>();
        }

        public bool IsPositionUsedByInstance(int x, int y)
        {

            foreach (var item in FigurePositions)
            {
                if ((item.X == x) && (item.Y == y)) return true;
            }

            return false;
        }
        public bool IsPositionUsedByInstance(Position position)
        {

            foreach (var item in FigurePositions)
            {
                if ((item.X == position.X) && (item.Y == position.Y)) return true;
            }
            return false;
        }
        public void RegisterNewPositionUsed(Position position)
        {
            FigurePositions.Add(position);
        }
        // public virtual List<Position> GetUsedPositions() { throw new NotImplementedException(); }


        public void Print(List<Position> positions, ConsoleColor clr)
        {
            positions.Sort(new SortByXY());
            Console.ForegroundColor = clr;
            Console.CursorVisible = false;
            Console.SetWindowSize(80, 25);
            foreach (var item in positions)
            {

                Console.SetCursorPosition(item.X, item.Y);
                Console.Write(item.TheChar);
            }

        }

        public List<Position> usedOnRight(int x, int y)
        {
            List<Position> positionsOnRight = new List<Position>();
            foreach (var position in FigurePositions)
            {
                if ((position.Y== y)&& (position.X> x))
                {
                    positionsOnRight.Add(position);
                }
            }
            return positionsOnRight;
        }
    }
}
