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
    class Pawn : Piece
    {

        public Pawn(int rank, int file, Color c, pieceTypes type)
        {
            this.rank = rank;
            this.file = file;
            this.color = c;
            this.pieceType = type;
            switch (c)
            {
                case Color.Black:
                    this.img = new Bitmap("assets/BlackPawn.png");
                    break;
                case Color.White:
                    this.img = new Bitmap("assets/WhitePawn1.png");
                    break;

            }


            

        }

        public override List<Square> GetLegalMovesOnBoard(Boardcs board)
        {
            List<Square> L = new List<Square>();


            try
            {
                if (color == Color.White)
                {

                    // one step if no piece
                    if (board.squares[rank + 1, file].piece == null)
                    {
                        L.Add(board.squares[rank + 1, file]);
                        // two steps if on second row
                        if (rank == 1 && board.squares[rank + 2, file].piece == null)
                        {
                            L.Add(board.squares[rank + 2, file]);
                        }
                    }
                    // capture if possible
                    if (board.squares[rank + 1, file + 1].piece != null && board.squares[rank + 1, file + 1].piece.color != color)
                    {
                        L.Add(board.squares[rank + 1, file + 1]);
                    }
                    if (board.squares[rank + 1, file - 1].piece != null && board.squares[rank + 1, file - 1].piece.color != color)
                    {
                        L.Add(board.squares[rank + 1, file - 1]);
                    }


                }
                else
                {
                    if (board.squares[rank - 1, file].piece == null)
                    {
                        L.Add(board.squares[rank - 1, file]);
                        if (rank == 6 && board.squares[rank - 2, file].piece == null)
                        {
                            L.Add(board.squares[rank - 2, file]);
                        }
                    }
                    if (board.squares[rank - 1, file + 1].piece != null && board.squares[rank - 1, file + 1].piece.color != color)
                    {
                        L.Add(board.squares[rank - 1, file + 1]);
                    }
                    if (board.squares[rank - 1, file - 1].piece != null && board.squares[rank - 1, file - 1].piece.color != color)
                    {
                        L.Add(board.squares[rank - 1, file - 1]);
                    }
                }
            }
            catch
            {

            }
           
            return L;
        }
    }
}
