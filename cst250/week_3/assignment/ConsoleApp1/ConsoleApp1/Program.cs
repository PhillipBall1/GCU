using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp
{
    class Program
    {
        static int boardSize = 8;
        static int attemptedMoves = 0;
        static int[] xMove = { 2, 1, -1, -2, -2, -1, 1, 2 };
        static int[] yMove = { 1, 2, 2, 1, -1, -2, -2, -1 };
        static int[,] boardGrid = new int[boardSize, boardSize];

        public static void Main(string[] args)
        {
            SolveKT();
            Console.ReadLine();
        }

        static void SolveKT()
        {
            for(int x = 0; x < boardSize; x++)
                for(int y = 0; y < boardSize; y++)
                    boardGrid[x, y] = -1;
            int startX = 4;
            int startY = 4;
            boardGrid[startX, startY] = 0;
            Console.WriteLine("Starting from X: " + startX + " Y: " + startY);
            attemptedMoves = 0;

            if(!SolveKTUTil(startX, startY, 1))
            {
                Console.WriteLine("Solution does not exist for {0} {1}", startX, startY);
            }
            else
            {
                PrintSolution(boardGrid);
                Console.Out.WriteLine("Total attempted moves {0}", attemptedMoves);
            }
        }

        static bool SolveKTUTil(int x, int y, int moveCount)
        {
            //displays the attempted moves
            attemptedMoves++;
            if (attemptedMoves % 1000 == 0) Console.Out.WriteLine("Attempts: {0}", attemptedMoves);
            if (moveCount == (boardSize * boardSize)) return true;


            //added these choice x and y to store the location that has the most neighbors
            int choiceX = -1;
            int choiceY = -1;

            //set neighbors variable to store the count
            int neighbors = 9;

            //initial for loop to itterate through moves
            for (int i = 0; i < 8; i++)
            {
                //set the next moves
                int nextX = x + xMove[i];
                int nextY = y + yMove[i];

                //store count variable for the neighbors
                int count = 0;

                //check if square is empty to make sure it is a valid move
                if (isSquareEmpty(nextX, nextY))
                {

                    //for loop for the neighbors
                    for (int j = 0; j < 8; j++)
                    {
                        //set variables to store the neighboring moves
                        int neighborX = nextX + xMove[j];
                        int neighborY = nextY + yMove[j];

                        //check if neighboring move is safe and empty, if so increase the count 
                        if (isSquareSafe(neighborX, neighborY) && isSquareEmpty(neighborX, neighborY)) count++;
                    }

                    //if count is less than neighbors, we set the main choices to the
                    //next inputs and set neighbors to the count, if the next move checked
                    //has an increased number of neighbors, it will override the choice values
                    if (count < neighbors)
                    {
                        choiceX = nextX;
                        choiceY = nextY;
                        neighbors = count;
                    }
                }
            }

            //if choice values have not changed, there is no move available
            if (choiceX == -1 && choiceY == -1) return false;

            //set the grid value to movecount
            boardGrid[choiceX, choiceY] = moveCount;

            //recursive call
            if (SolveKTUTil(choiceX, choiceY, moveCount + 1))
            {
                return true;
            }
            else
            {
                //backtracking
                boardGrid[choiceX, choiceY] = -1;
                return false;
            }
        }


        //checks to see if square is inbounds
        static bool isSquareSafe(int x, int y)
        {
            return (x >= 0 && x < boardSize && y >= 0 && y < boardSize);
        }

        //checks to see if square is empty
        static bool isSquareEmpty(int x, int y)
        {
            return (isSquareSafe(x, y) && boardGrid[x, y] < 0);
        }


        //print
        static void PrintSolution(int[,] solution)
        {
            Console.WriteLine("+---+---+---+---+---+---+---+---+");
            for (int x = 0; x < boardSize; x++)
            {
                for(int y = 0; y < boardSize; y++)
                {
                    if (solution[x,y] >= 10 || solution[x, y] < 0) Console.Write("| " + solution[x,y] + "");
                    else Console.Write("| " + solution[x, y] + " ");
                }
                Console.Write("|\n");
                Console.WriteLine("+---+---+---+---+---+---+---+---+");
            }
        }
    }
}