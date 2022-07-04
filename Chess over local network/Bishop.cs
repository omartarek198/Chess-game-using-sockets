﻿using System;
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
    class Bishop : Piece
    {
        public Bishop(int rank, int file, Color c, pieceTypes type)
        {
            this.rank = rank;
            this.file = file;
            this.color = c;
            this.pieceType = type;
            switch (c)
            {
                case Color.Black:
                    this.img = new Bitmap("assets/BlackBishop.png");
                    break;
                case Color.White:
                    this.img = new Bitmap("assets/WhiteBishop.png");
                    break;

            }


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
           //try
            {
                for (; ; )
                {
                    if (j < 7) j++;
                    else
                        break;
                    if (k < 7) k++;
                    else
                        break;

                    if (board.squares[j, k].piece == null)
                    {
                        L.Add(board.squares[j, k]);

                    }

                    if (board.squares[j, k].piece != null && board.squares[j,k].piece.file != board.selectedPiece.file
                       && board.squares[j, k].piece.rank != board.selectedPiece.rank)
                    {
                        if (board.squares[j, k].piece.color == oppositeColor)
                        {
                            L.Add(board.squares[j, k]);
                        }
                        else
                        {

                        }

                        break;

                    }

                    if (j >= 7&& k >= 7) break;


                }
                j = rank ;
                k = file ;
                for (; ; )
                {
                    if (j > 0) j--;
                    else
                        break;
                    if (k < 7) k++;
                    else
                        break;
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

                        break;

                    }
                    if (j < 0 || k >= 7) break;

                }

                j = rank ;
                k = file ;
                for (; ; )
                {

                    if (j < 8) j++;
                    else
                        break;
                    if (k > 0) k--;
                    else break;

                    if (k < 0 || j >= 8) break;
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

                        break;

                    }
                   
                }

                j = rank ;
                k = file;
                for (; ; )
                {

                    if (j > 0) j--;
                    else
                        break;
                    if (k > 0) k--;
                    else
                        break;
                    if (j < 0 || k < 0) break;
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

                        break;

                    }
              
                }
              
            }
            //catch
            {

            }

            return L;

        }
        }
}
