using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examtst2
{
    enum CursorMoving { Up, Down, Left, Right }

    class WhiteBall : IUsingPositions
    {
        public List<Position> TrackPositions { get; set; }
        char TheChar;
        public Position Cursor { get; set; }
        public List<IUsingPositions> InstancesUsingPositions { get; set; }

        public WhiteBall(Position cursor, List<IUsingPositions> figures)
        {
            Cursor =new  Position( cursor);
            TrackPositions = new List<Position>();
            InstancesUsingPositions = new List<IUsingPositions>();
            
            InstancesUsingPositions.Add(this);
            foreach (var item in figures)
            {
                InstancesUsingPositions.Add(item);
            }
         }

        

        public bool IsPositionUsedByInstance(int x, int y)
        {
            foreach (var item in TrackPositions)
            {
                if ((item.X == x) && (item.Y == y)) return true;
            }

            return false;
        }

        public bool IsPositionUsedByInstance(Position position)
        {
            foreach (var item in TrackPositions)
            {
                if ((item.X == position.X) && (item.Y == position.Y)) return true;
            }
            return false;
        }

        public void RegisterNewPositionUsed(Position position)
        {
            TrackPositions.Add(position);
        }

        public WhiteBall(Position cursor, List<Figure> figures)
        {
            Cursor = cursor;
            TrackPositions = new List<Position>();
            InstancesUsingPositions = new List<IUsingPositions>();
            InstancesUsingPositions.Add(this);
            foreach (var item in figures)
            {
                InstancesUsingPositions.Add(item);
            }
            TheChar = '*';
            TrackPositions = new List<Position>();
            ConsoleColor wbcolor = ConsoleColor.White;
            ConsoleColor wbTrackColor = ConsoleColor.Blue;
        }
        public void Move(ConsoleKey step)

        {
            
            List<Position> usedPositionsOnRight;
            switch (step)
            {
                case ConsoleKey.UpArrow:
                    this.RegisterNewPositionUsed( new Position( Cursor));
                    usedPositionsOnRight = GetUsedPositionsOnRight(Cursor.X, Cursor.Y);
                    Print(usedPositionsOnRight);
                    Cursor.Y--;

                    break;
                case ConsoleKey.DownArrow:
                    this.RegisterNewPositionUsed((new Position(Cursor)));
                    usedPositionsOnRight = GetUsedPositionsOnRight(Cursor.X, Cursor.Y);
                    Print(usedPositionsOnRight);
                    Cursor.Y++;
                    break;
                case ConsoleKey.LeftArrow:
                    this.RegisterNewPositionUsed((new Position(Cursor)));
                    usedPositionsOnRight = GetUsedPositionsOnRight(Cursor.X, Cursor.Y);
                    Print(usedPositionsOnRight);
                    Cursor.X--;
                    break;
                case ConsoleKey.RightArrow:
                    this.RegisterNewPositionUsed((new Position(Cursor)));
                    usedPositionsOnRight = GetUsedPositionsOnRight(Cursor.X, Cursor.Y);
                    Print(usedPositionsOnRight);
                    Cursor.X++;
                    break;
                default:
                    break;
            }
       }
        public void Print(List<Position> positions)
        {
            positions.Sort(new SortByXY());
     
            Console.CursorVisible = false;
   
            foreach (var item in positions)
            {
                Console.ForegroundColor = item.color;
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write(item.TheChar);
            }

        }
        public List<Position> usedOnRight(int x, int y)
        {
            List<Position> positionsOnRight = new List<Position>();
            foreach (var position in TrackPositions)
            {
                if ((position.Y == y) && (position.X > x))
                {
                    positionsOnRight.Add(position);
                }
            }
            return positionsOnRight;
        }
        public List<Position> GetUsedPositionsOnRight(int x, int y)
        {
            List<Position> commonOnRight = new List<Position>();
                    
            foreach (var item in InstancesUsingPositions)
            {

                foreach (var position in item.usedOnRight(x, y))
                {
                    commonOnRight.Add(position);
                }

            }
            commonOnRight.Sort(new SortByXY());
            return commonOnRight;
        }
    }
}
