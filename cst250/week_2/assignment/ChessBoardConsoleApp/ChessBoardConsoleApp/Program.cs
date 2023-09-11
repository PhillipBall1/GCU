using ChessBoardModel;
using System;
using System.Drawing;

namespace ChessBoardConsoleApp
{
    class Program
    {
        static Board myBoard = new Board(8);

        static void Main(string[] args)
        {
            //show the empty chessboard
            PrintBoard(myBoard);
            //get the location of the chess piece
            
            string piece = "";
            int value = GetUserInput("Which piece do you want to place?\n0: Queen\n1: Bishop\n2: Knight\n3: King\n4: Rook", 4);
            switch (value)
            {
                case 0: piece = "Queen"; break;
                case 1: piece = "Bishop"; break;
                case 2: piece = "Knight"; break;
                case 3: piece = "King"; break;
                case 4: piece = "Rook"; break;
            }
            Cell myLocation = SetCurrentCell();
            //calculate and mark the cells where legal moves are possible
            myBoard.MarkLegalMove(myLocation, piece);
            //show the chessboard and use "." for an empty square, "X" for the piece location
            //and "+" for a possible legal move
            PrintBoard(myBoard);
            //wait for another return key and exit the program
            Console.ReadLine();
        }

        static public void PrintBoard(Board myBoard)
        {
            for(int i = 0; i < myBoard.size; i++)
            {
                Console.WriteLine("\n+---+---+---+---+---+---+---+---+");
                for (int j = 0; j < myBoard.size; j++)
                {
                    if (myBoard.grid[i, j].currentlyOccupied)
                    {
                        Console.Write("| X ");
                    }
                    else if (myBoard.grid[i, j].legalNextMove)
                    {
                        Console.Write("| - ");
                    }
                    else
                    {
                        Console.Write("|   ");
                    }
                }
                Console.Write("|");
            }
            Console.WriteLine("\n+---+---+---+---+---+---+---+---+");
        }

        static public Cell SetCurrentCell()
        {

            int currentRow = GetUserInput("Enter your current row number:", 7);

            int currentColumn = GetUserInput("Enter your current column number:", 7);

            myBoard.grid[currentRow, currentColumn].currentlyOccupied = true;

            return myBoard.grid[currentRow, currentColumn];
        }

        static int GetUserInput(string statement, int rcSize)
        {
            int value = rcSize + 2;

            //while loop to allow the user to make the right input
            while (value > rcSize && value >= 0)
            {
                //write statement
                Console.WriteLine(statement);

                //get answer
                string answer = Console.ReadLine();

                //try parse the answer to set an actual value, if it works, return that value
                //	if not, write invalid input
                if (!int.TryParse(answer, out value)) Console.WriteLine("Invalid input");
                if (value + 1 > rcSize) Console.WriteLine("Input too large");
            }
            return value;
        }
    }
}
