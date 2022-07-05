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
    class Rook : Piece
    {

        public Rook(int rank, int file, Color c, pieceTypes type)
        {
            this.rank = rank;
            this.file = file;
            this.color = c;
            this.pieceType = type;
            switch (c)
            {
                case Color.Black:
                    this.img = new Bitmap("assets/BlackRook.png");
                    break;
                case Color.White:
                    this.img = new Bitmap("assets/WhiteRook.png");
                    break;

            }


        }
        public override List<Square> GetLegalMovesOnBoard(Boardcs board)
        {
            List<Square> L = new List<Square>();
            Color oppositeColor;
            this.LprotectedPieces = new List<Piece>();
            if (color == Color.White)
            {
                oppositeColor = Color.Black;
            }
            else
            {
                oppositeColor = Color.White;
            }

            int j = rank+1;
            int k = file ;
            for (; j < 8; j++)
            {
                if (board.squares[j, k].piece == null)
                {
                    L.Add(board.squares[j, k]);

                }

                if (board.squares[j, k].piece!=null)
                {
                    if (board.squares[j, k].piece.color == oppositeColor)
                    {
                        L.Add(board.squares[j, k]);
                    }
                    else
                    {
                        LprotectedPieces.Add(board.squares[j, k].piece);
                    }

                    break;

                }

            }

            j = rank - 1;
             k = file;
            for (; j > -1; j--)
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
                        LprotectedPieces.Add(board.squares[j, k].piece);

                    }

                    break;

                }

            }


            j = rank  ;
            k = file-1;
            for (; k > -1; k--)
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
                        LprotectedPieces.Add(board.squares[j, k].piece);

                    }

                    break;

                }

            }



            j = rank;
            k = file +1;
            for (; k< 8; k++)
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
                        LprotectedPieces.Add(board.squares[j, k].piece);

                    }

                    break;

                }

            }




            return L;
        }
    }
}
