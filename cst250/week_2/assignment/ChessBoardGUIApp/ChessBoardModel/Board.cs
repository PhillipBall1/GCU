using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardModel
{
    public class Board
    {
        public int size { get; set; }

        public Cell[,] grid;

        public Board(int s)
        {
            size = s;

            grid = new Cell[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid[i, j] = new Cell(i, j);
                }
            }
        }

        public void MarkLegalMove(Cell cell, string piece)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid[i, j].legalNextMove = false;
                }
            }
            int r = cell.rowNumber;
            int c = cell.columnNumber;
            switch (piece)
            {
                case "Knight":

                    isMoveLegal(r - 1, c + 2);
                    isMoveLegal(r - 1, c - 2);
                    isMoveLegal(r - 2, c + 1);
                    isMoveLegal(r - 2, c - 1);
                    isMoveLegal(r + 1, c + 2);
                    isMoveLegal(r + 1, c - 2);
                    isMoveLegal(r + 2, c + 1);
                    isMoveLegal(r + 2, c - 1);
                    grid[r, c] .legalNextMove = false;

                    break;
                case "King":

                    isMoveLegal(r - 1, c + 1);
                    isMoveLegal(r - 1, c - 1);
                    isMoveLegal(r - 1, c);
                    isMoveLegal(r, c - 1);
                    isMoveLegal(r, c + 1);
                    isMoveLegal(r + 1, c + 1);
                    isMoveLegal(r + 1, c);
                    isMoveLegal(r + 1, c - 1);
                    grid[r, c].legalNextMove = false;

                    break;
                case "Rook":

                    for (int i = 0; i < 8; i++)
                    {
                        isMoveLegal(r + i, c);
                        isMoveLegal(r, c + i);
                    }

                    for (int i = 0; i < 8; i++)
                    {
                        isMoveLegal(r - i, c);
                        isMoveLegal(r, c - i);
                    }

                    grid[r, c].legalNextMove = false;

                    break;
                case "Bishop":

                    for (int i = 0; i < 8; i++)
                    {
                        isMoveLegal(r + i, c + i);
                    }
                    for (int i = 0; i < 8; i++)
                    {
                        isMoveLegal(r + i, c - i);
                    }
                    for (int i = 0; i < 8; i++)
                    {
                        isMoveLegal(r - i, c + i);
                    }
                    for (int i = 0; i < 8; i++)
                    {
                        isMoveLegal(r - i, c - i);
                    }

                    grid[r, c].legalNextMove = false;

                    break;
                case "Queen":

                    for (int i = 0; i < 8; i++)
                    {
                        isMoveLegal(r + i, c + i);
                    }
                    for (int i = 0; i < 8; i++)
                    {
                        isMoveLegal(r + i, c - i);
                    }
                    for (int i = 0; i < 8; i++)
                    {
                        isMoveLegal(r - i, c + i);
                    }
                    for (int i = 0; i < 8; i++)
                    {
                        isMoveLegal(r - i, c - i);
                    }
                    for (int i = 0; i < 8; i++)
                    {
                        isMoveLegal(r + i, c);
                        isMoveLegal(r, c + i);
                    }

                    for (int i = 0; i < 8; i++)
                    {
                        isMoveLegal(r - i, c);
                        isMoveLegal(r, c - i);
                    }

                    grid[r, c].legalNextMove = false;

                    break;
            }
        }


        //Checking bounds, if out of them, return
        private void isMoveLegal(int r, int c)
        {
            if (r > 7 || r < 0 || c > 7 || c < 0) return;

            grid[r, c].legalNextMove = true;

        }
    }
}

