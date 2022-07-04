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
    class Knight : Piece
    {
        public Knight(int rank, int file, Color c, pieceTypes type)
        {
            this.rank = rank;
            this.file = file;
            this.color = c;
            this.pieceType = type;
            switch (c)
            {
                case Color.Black:
                    this.img = new Bitmap("assets/BlackKnight.png");
                    break;
                case Color.White:
                    this.img = new Bitmap("assets/WhiteHorse.png");
                    break;

            }


        }


        public bool validJK(int j, int k)
        {
            if (j >=0 && j <8)
            {
                if (k >=0 && k <8)
                {
                    return true;
                }
            }

            return false;
        }

        public override List<Square> GetLegalMovesOnBoard(Boardcs board)
        {
            List<Square> L = new List<Square>();
            Color oppositeColor;
            if (color == Color.White)
            {
                oppositeColor = Color.Black;
            }
            else
            {
                oppositeColor = Color.White;
            }

            int j = rank;
            int k = file;

            j = j + 2;
            k--;

            if ( validJK(j,k))
            {

                if (board.squares[j, k].piece == null)
                {
                    L.Add(board.squares[j, k]);

                }

                if (board.squares[j, k].piece != null)
                {
                    if (board.squares[j, k].piece.color == oppositeColor)
                    {
                        L.Add(board.squares[j, k]);
                    }
                    else
                    {

                    }

                    

                }
            }

             j = rank;
             k = file;

            j = j + 2;
            k++;

            if (validJK(j, k))
            {

                if (board.squares[j, k].piece == null)
                {
                    L.Add(board.squares[j, k]);

                }

                if (board.squares[j, k].piece != null)
                {
                    if (board.squares[j, k].piece.color == oppositeColor)
                    {
                        L.Add(board.squares[j, k]);
                    }
                    else
                    {

                    }



                }
            }


            j = rank;
            k = file;

            j = j - 2;
            k++;

            if (validJK(j, k))
            {

                if (board.squares[j, k].piece == null)
                {
                    L.Add(board.squares[j, k]);

                }

                if (board.squares[j, k].piece != null)
                {
                    if (board.squares[j, k].piece.color == oppositeColor)
                    {
                        L.Add(board.squares[j, k]);
                    }
                    else
                    {

                    }



                }
            }
            j = rank;
            k = file;

            j = j - 2;
            k--;

            if (validJK(j, k))
            {

                if (board.squares[j, k].piece == null)
                {
                    L.Add(board.squares[j, k]);

                }

                if (board.squares[j, k].piece != null)
                {
                    if (board.squares[j, k].piece.color == oppositeColor)
                    {
                        L.Add(board.squares[j, k]);
                    }
                    else
                    {

                    }



                }
            }

            j = rank;
            k = file;

            j--;
            k = k-2;

            if (validJK(j, k))
            {

                if (board.squares[j, k].piece == null)
                {
                    L.Add(board.squares[j, k]);

                }

                if (board.squares[j, k].piece != null)
                {
                    if (board.squares[j, k].piece.color == oppositeColor)
                    {
                        L.Add(board.squares[j, k]);
                    }
                    else
                    {

                    }



                }
            }

            j = rank;
            k = file;

            j++;
            k = k - 2;

            if (validJK(j, k))
            {

                if (board.squares[j, k].piece == null)
                {
                    L.Add(board.squares[j, k]);

                }

                if (board.squares[j, k].piece != null)
                {
                    if (board.squares[j, k].piece.color == oppositeColor)
                    {
                        L.Add(board.squares[j, k]);
                    }
                    else
                    {

                    }



                }
            }


            j = rank;
            k = file;

            j++;
            k = k + 2;

            if (validJK(j, k))
            {

                if (board.squares[j, k].piece == null)
                {
                    L.Add(board.squares[j, k]);

                }

                if (board.squares[j, k].piece != null)
                {
                    if (board.squares[j, k].piece.color == oppositeColor)
                    {
                        L.Add(board.squares[j, k]);
                    }
                    else
                    {

                    }



                }
            }


            j = rank;
            k = file;

            j--;
            k = k + 2;

            if (validJK(j, k))
            {

                if (board.squares[j, k].piece == null)
                {
                    L.Add(board.squares[j, k]);

                }

                if (board.squares[j, k].piece != null)
                {
                    if (board.squares[j, k].piece.color == oppositeColor)
                    {
                        L.Add(board.squares[j, k]);
                    }
                    else
                    {

                    }



                }
            }
            return L;

        }
    }
}
