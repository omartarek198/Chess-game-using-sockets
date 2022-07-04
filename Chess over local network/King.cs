using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_over_local_network
{
    class King : Piece
    {
        public King(int rank, int file, Color c, pieceTypes type)
        {
            this.rank = rank;
            this.file = file;
            this.color = c;
            this.pieceType = type;
            switch (c)
            {
                case Color.Black:
                    this.img = new Bitmap("assets/BlackKing.png");
                    break;
                case Color.White:
                    this.img = new Bitmap("assets/WhiteKing.png");
                    break;

            }


            

        }

        public bool validJK(int j, int k)
        {
            if (j >= 0 && j < 8)
            {
                if (k >= 0 && k < 8)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsSquareSafe(Boardcs board, Square square)
        {
            for (int i=0;i<board.All.Count;i++)
            {
                if (square == board.All[i])
                {
                    return false;
                }
            }
            return true;
        }
        public override List<Square> GetLegalMovesOnBoard(Boardcs board)
        {
            List<Square> L = new List<Square>();
            int j = rank;
            int k = file;

            j--;
            if (validJK(j,k))
            {
                if (board.squares[j, k].piece == null)
                {
                    if (IsSquareSafe(board,board.squares[j,k]))
                    {
                        L.Add(board.squares[j, k]);
                    }

                }
            }

             j = rank;
             k = file;

            k++;
            if (validJK(j, k))
            {
                if (board.squares[j, k].piece == null)
                {
                    if (IsSquareSafe(board, board.squares[j, k]))
                    {
                        L.Add(board.squares[j, k]);
                    }

                }
            }



            j = rank;
            k = file;

            j++;
            if (validJK(j, k))
            {
                if (board.squares[j, k].piece == null)
                {
                    if (IsSquareSafe(board, board.squares[j, k]))
                    {
                        L.Add(board.squares[j, k]);
                    }

                }
            }

            j = rank;
            k = file;
            k--;
            if (validJK(j, k))
            {
                if (board.squares[j, k].piece == null)
                {
                    if (IsSquareSafe(board, board.squares[j, k]))
                    {
                        L.Add(board.squares[j, k]);
                    }

                }
            }


            j = rank;
            k = file;
            k--;
            j--;
            if (validJK(j, k))
            {
                if (board.squares[j, k].piece == null)
                {
                    if (IsSquareSafe(board, board.squares[j, k]))
                    {
                        L.Add(board.squares[j, k]);
                    }

                }
            }
            j = rank;
            k = file;
            k--;
            j++;
            if (validJK(j, k))
            {
                if (board.squares[j, k].piece == null)
                {
                    if (IsSquareSafe(board, board.squares[j, k]))
                    {
                        L.Add(board.squares[j, k]);
                    }

                }
            }

            j = rank;
            k = file;
            k++;
            j--;
            if (validJK(j, k))
            {
                if (board.squares[j, k].piece == null)
                {
                    if (IsSquareSafe(board, board.squares[j, k]))
                    {
                        L.Add(board.squares[j, k]);
                    }

                }
            }

            j = rank;
            k = file;
            k++;
            j++;
            if (validJK(j, k))
            {
                if (board.squares[j, k].piece == null)
                {
                    if (IsSquareSafe(board, board.squares[j, k]))
                    {
                        L.Add(board.squares[j, k]);
                    }

                }
            }




            return L;
        }
    }
}
