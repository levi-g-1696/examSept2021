using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace examtst2
{
    static class Program
    {
        static bool sessionStop = false;

        //  public static List<Figure> figures = new List<Figure>();
        static void Main(string[] args)
        {
            int score = 0;
            int gameNum = 1;

            InstanceManaging m = new InstanceManaging();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.SetWindowSize(90, 25);
            //  ======= Drow right border  ============
            for (int i = 0; i < 24; i++)
            {
                Print(new Position(80, i, '|', ConsoleColor.DarkYellow), ConsoleColor.DarkYellow);

            }
            Console.SetCursorPosition(82, 7);
            Console.Write("SCORE:");
            Console.SetCursorPosition(84, 8);
            Console.Write(score);
            //=============================================

            //        Console.OutputEncoding = Encoding.GetEncoding(1255);
            List<Figure> figures = new List<Figure>();

            #region new Figures

            InstanceManaging instanceManaging = new InstanceManaging();
            figures = instanceManaging.RandomInitFigures(gameNum);
            foreach (var item in figures)
            {
                Print(item.FigurePositions);
            }
            #endregion


            Position cursor = RandomInitCursor(figures);
            WhiteBall wb = new WhiteBall(cursor, figures);

            Print(wb.TrackPositions, ConsoleColor.Blue);
            Print(wb.Cursor, ConsoleColor.White);

            while (!sessionStop)
            {


                while (!IsPositionUsed(cursor, figures, wb))

                {


                    if (Console.KeyAvailable)
                    {
                        var command = Console.ReadKey().Key;
                        wb.Move(command);
                        if (wb.Cursor.X < 0 || wb.Cursor.X > 79 || wb.Cursor.Y < 0 || wb.Cursor.Y > 24)
                        {
                            Console.Beep();
                            break;
                        }
                        Print(wb.TrackPositions, ConsoleColor.Blue);
                        Print(wb.Cursor, ConsoleColor.White);
                        score++;
                        Console.SetCursorPosition(82, 7);
                        Console.Write("SCORE:");
                        Console.SetCursorPosition(84, 8);
                        Console.Write(score);

                    }

                    else
                    {
                        Thread.Sleep(150);
                    }


                }
                Console.Clear();
                Console.Beep();
                gameNum++;
                //  ======= Drow right border  ============
                //              Console.SetWindowSize(90, 25);
                for (int i = 0; i < 24; i++)
                {
                    Print(new Position(80, i, '|', ConsoleColor.DarkYellow), ConsoleColor.DarkYellow);
                }
                Console.SetCursorPosition(82, 7);
                Console.Write("SCORE:");
                Console.SetCursorPosition(84, 8);
                Console.Write(score);
                //=============================================
                figures = instanceManaging.RandomInitFigures(gameNum);

                foreach (var item in figures)
                {
                    Print(item.FigurePositions);
                }
                cursor = RandomInitCursor(figures);
                wb = new WhiteBall(cursor, figures);

                Print(wb.TrackPositions, ConsoleColor.Blue);
                Print(wb.Cursor, ConsoleColor.White);

            }
            Console.Beep();
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n");
            Console.WriteLine("                             GAME IS OVER");
            Console.WriteLine("                             YOUR SCORE IS " + score);

        }
        public static void Print(List<Position> positions, ConsoleColor clr)
        {
            positions.Sort(new SortByXY());
            Console.ForegroundColor = clr;
            Console.CursorVisible = false;
            //    Console.SetWindowSize(80, 25);
            foreach (var item in positions)
            {

                Console.SetCursorPosition(item.X, item.Y);
                Console.Write(item.TheChar);
            }

        }
        public static void Print(List<Position> positions)
        {
            positions.Sort(new SortByXY());
            Console.ForegroundColor = positions[0].color;
            Console.CursorVisible = false;
            //    Console.SetWindowSize(80, 25);
            foreach (var item in positions)
            {

                Console.SetCursorPosition(item.X, item.Y);
                Console.Write(item.TheChar);
            }

        }
        public static void Print(Position position, ConsoleColor clr)
        {



            Console.ForegroundColor = clr;
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(position.TheChar);
        }
        public static bool IsPositionUsed(Position position, List<Figure> figures, WhiteBall whiteBall)
        {
            int x = position.X;
            int y = position.Y;
            foreach (var item in figures)
            {
                if (item.IsPositionUsedByInstance(x, y)) { Console.WriteLine(item.TheFigurChar); return true; };
            }
            if (whiteBall.IsPositionUsedByInstance(x, y)) { Console.WriteLine("whiteball"); return true; }
            else return false;
        }

        public static bool IsPositionUsed(Position position, List<Figure> figures)
        {
            int x = position.X;
            int y = position.Y;
            foreach (var item in figures)
            {
                if (item.IsPositionUsedByInstance(x, y))
                {
                    Console.WriteLine(item.TheFigurChar);
                    return true;
                }
            }

            return false;
        }

        public static Position RandomInitCursor(List<Figure> figures) //also can change sessionStop value 
        {

            Random rnd = new Random();
            int x = rnd.Next(2, 77);
            int y = rnd.Next(1, 24);
            Position newCursor = new Position(x, y, '*', ConsoleColor.White);
            int counter = 1;
            while (IsPositionUsed(newCursor, figures))
            {
                rnd = new Random();
                x = rnd.Next(2, 77);
                y = rnd.Next(1, 24);
                newCursor = new Position(x, y, '*', ConsoleColor.White);
                counter++;
                if ((counter > 30))
                {
                    break;
                }
                
            }
            if ((counter > 30) || (figures.Count >= 15))
            { sessionStop = true; }
            
            return newCursor;
        }

    }



}


