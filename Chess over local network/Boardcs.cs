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
    public class Boardcs
    {

        public Square[,] squares = new Square[8, 8];
        public List<Piece> Lpieces = new List<Piece>();
        public Piece selectedPiece = null;
        public Square selectedPieceSquare = null;
        List<Square> LHighlighted = new List<Square>();
        public List<Square> All = new List<Square>();
        public List<Piece> CurrProtectedPieces = new List<Piece>();
        public List<Square> CurrProtectedSquares = new List<Square>();
        public CommonAttributes.Color currentTurn = CommonAttributes.Color.White;



        public Boardcs()
        {
            Lpieces = MakePieces();
            squares = MakeSquares();
            PutPiecesOnSquares();
        }

        public Boardcs(Boardcs boardToCopyFrom)
        {

            Lpieces = new List<Piece>();

            for (int i=0;i<boardToCopyFrom.Lpieces.Count;i++)
            {
                Lpieces.Add( CopyPiece(boardToCopyFrom.Lpieces[i]));
            }

            for (int j=0;j<8;j++)
            {
                for (int i=0;i<8; i++)
                {
                    squares[j, i] = new Square(boardToCopyFrom.squares[j, i]);
                }
            }
            PutPiecesOnSquares();

        }


        public Piece CopyPiece(Piece piece)
        {
            Piece CopiedPiece = null;

            switch (piece.pieceType)
            {
                case Piece.pieceTypes.King:
                    CopiedPiece = new King(piece.rank, piece.file, piece.color, piece.pieceType);
                    break;
                case Piece.pieceTypes.Queen:
                    CopiedPiece = new Queen(piece.rank, piece.file, piece.color, piece.pieceType);
                    break;
                case Piece.pieceTypes.Bishop:
                    CopiedPiece = new Bishop(piece.rank, piece.file, piece.color, piece.pieceType);
                    break;
                case Piece.pieceTypes.Knight:
                    CopiedPiece = new Knight(piece.rank, piece.file, piece.color, piece.pieceType);
                    break;
                case Piece.pieceTypes.Rook:
                    CopiedPiece = new Rook(piece.rank, piece.file, piece.color, piece.pieceType);
                    break;
                case Piece.pieceTypes.Pawn:
                    CopiedPiece = new Pawn(piece.rank, piece.file, piece.color, piece.pieceType);
                    break;


            }
            return CopiedPiece;
        }
        public void FindAllProtectedPiecesForColor(CommonAttributes.Color color)
        {
            for (int i = 0; i < Lpieces.Count; i++)
            {
                if (Lpieces[i].color == color)
                {
                    Lpieces[i].GetLegalMovesOnBoard(this);

                }
            }
            CurrProtectedPieces = new List<Piece>();
            for (int i = 0; i < Lpieces.Count; i++)
            {
                if (Lpieces[i].color == color)
                {
                    for (int k = 0; k < Lpieces[i].LprotectedPieces.Count; k++)
                    {
                        CurrProtectedPieces.Add(Lpieces[i].LprotectedPieces[k]);
                    }
                }
            }


            for (int i = 0; i < CurrProtectedPieces.Count; i++)
            {
                CurrProtectedSquares.Add(GetSquare(CurrProtectedPieces[i].file,
                    CurrProtectedPieces[i].rank));
            }
        }
        public void FindAllLegalMovesForColor(CommonAttributes.Color color)
        {
            List<Square> temp = new List<Square>();
            All = new List<Square>();
            for (int i = 0; i < Lpieces.Count; i++)
            {
                if (Lpieces[i].color == color)
                {
                    temp = Lpieces[i].GetLegalMovesOnBoard(this);

                    if (temp != null)
                    {
                        for (int k = 0; k < temp.Count; k++)
                        {
                            All.Add(temp[k]);
                        }
                    }

                }
            }
        }

        public Square[,] MakeSquares()
        {

            Square[,] squares = new Square[8, 8];
            CommonAttributes.Color Blackcolor = CommonAttributes.Color.Black;
            CommonAttributes.Color Whitecolor = CommonAttributes.Color.White;
            CommonAttributes.Color color = Whitecolor;


            Point point = new Point(0, 0);
            for (int i = 7; i > -1; i--)
            {
                for (int j = 0; j < 8; j++)
                {



                    squares[i, j] = new Square(color, i, j, point);


                    if (color == CommonAttributes.Color.White)
                        color = CommonAttributes.Color.Black;
                    else
                        color = CommonAttributes.Color.White;

                    point = new Point(point.X + 90, point.Y);
                }

                if (color == CommonAttributes.Color.White)
                    color = CommonAttributes.Color.Black;
                else
                    color = CommonAttributes.Color.White;
                point = new Point(0, point.Y + 90);

            }

            return squares;


        }
        public List<Piece> MakePieces()
        {
            List<Piece> Lpieces = new List<Piece>();
            Piece piece;
            //MakingPawns
            for (int i = 0; i < 8; i++)
            {
                piece = new Pawn(1, i, CommonAttributes.Color.White, Piece.pieceTypes.Pawn);
                Lpieces.Add(piece);

            }

            for (int i = 0; i < 8; i++)
            {
                piece = new Pawn(6, i, CommonAttributes.Color.Black, Piece.pieceTypes.Pawn);
                Lpieces.Add(piece);

            }


            // rooks


            piece = new Rook(0, 0, CommonAttributes.Color.White, Piece.pieceTypes.Rook);
            Lpieces.Add(piece);



            piece = new Rook(0, 7, CommonAttributes.Color.White, Piece.pieceTypes.Rook);
            Lpieces.Add(piece);


            piece = new Rook(7, 0, CommonAttributes.Color.Black, Piece.pieceTypes.Rook);
            Lpieces.Add(piece);

            piece = new Rook(7, 7, CommonAttributes.Color.Black, Piece.pieceTypes.Rook);
            Lpieces.Add(piece);
            //knights


            piece = new Knight(0, 1, CommonAttributes.Color.White, Piece.pieceTypes.Knight);
            Lpieces.Add(piece);


            piece = new Knight(0, 6, CommonAttributes.Color.White, Piece.pieceTypes.Knight);
            Lpieces.Add(piece);


            piece = new Knight(7, 1, CommonAttributes.Color.Black, Piece.pieceTypes.Knight);
            Lpieces.Add(piece);


            piece = new Knight(7, 6, CommonAttributes.Color.Black, Piece.pieceTypes.Knight);
            Lpieces.Add(piece);

            //bishops


            piece = new Bishop(0, 2, CommonAttributes.Color.White, Piece.pieceTypes.Bishop);
            Lpieces.Add(piece);
            piece = new Bishop(0, 5, CommonAttributes.Color.White, Piece.pieceTypes.Bishop);
            Lpieces.Add(piece);

            piece = new Bishop(7, 2, CommonAttributes.Color.Black, Piece.pieceTypes.Bishop);
            Lpieces.Add(piece);


            piece = new Bishop(7, 5, CommonAttributes.Color.Black, Piece.pieceTypes.Bishop);
            Lpieces.Add(piece);

            //queens
            piece = new Queen(0, 3, CommonAttributes.Color.White, Piece.pieceTypes.Queen);
            Lpieces.Add(piece);
            piece = new Queen(7, 3, CommonAttributes.Color.Black, Piece.pieceTypes.Queen);
            Lpieces.Add(piece);

            //kings 
            piece = new King(0, 4, CommonAttributes.Color.White, Piece.pieceTypes.King);
            Lpieces.Add(piece);

            piece = new King(7, 4, CommonAttributes.Color.Black, Piece.pieceTypes.King);
            Lpieces.Add(piece);
            return Lpieces;
        }

        public void PutPiecesOnSquares()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    for (int j = 0; j < Lpieces.Count; j++)
                    {
                        if (squares[i, k].file == Lpieces[j].file)
                        {
                            if (squares[i, k].rank == Lpieces[j].rank)
                            {
                                squares[i, k].attachPiece(Lpieces[j]);
                            }
                        }
                    }
                }
            }
        }


        public bool SquareIsLegal(Square obj)
        {
            for (int i=0;i<LHighlighted.Count;i++)
            {
                if (obj == LHighlighted[i]) return true;
            }

            return false;
        }

        public CommonAttributes.Color SwitchColor(CommonAttributes.Color color)
        {

            switch (color)
            {
                case CommonAttributes.Color.Black:
                    return CommonAttributes.Color.White;
                case CommonAttributes.Color.White:
                    return CommonAttributes.Color.Black;
                default:
                    return CommonAttributes.Color.Black;
            }
            //returns the other color
        }

        public void FindClickedPiece(int x, int y)
        {

            if (selectedPiece != null)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (squares[i, j].IsClicked(x, y) && SquareIsLegal(squares[i,j]))
                        {
                            if (squares[i, j].piece == null)
                            {
                                GetSquare(selectedPiece.file, selectedPiece.rank).removePiece();
                                squares[i, j].attachPiece(selectedPiece);
                                if (CheckForChecks())
                                {
                                    MessageBox.Show("check");
                                }
                                selectedPiece = null;
                                LHighlighted.RemoveRange(0, LHighlighted.Count);
                                currentTurn = SwitchColor(currentTurn);

                                break;
                            }
                            else
                            {
                                //remove ig?
                                GetSquare(selectedPiece.file, selectedPiece.rank).removePiece();
                                Lpieces.Remove(GetPiece(i, j));
                                squares[i, j].attachPiece(selectedPiece);
                                if (CheckForChecks())
                                {
                                    MessageBox.Show("check");
                                }

                                selectedPiece = null;

                                LHighlighted.RemoveRange(0, LHighlighted.Count);
                                currentTurn = SwitchColor(currentTurn);

                                break;
                            }

                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < Lpieces.Count; i++)
                {
                    if (Lpieces[i].IsClicked(x, y) && Lpieces[i].color == currentTurn)
                    {
                        selectedPiece = Lpieces[i];

                        if (selectedPiece.pieceType == Piece.pieceTypes.King)
                        {
                            CommonAttributes.Color opposite;

                            if (selectedPiece.color == CommonAttributes.Color.White)
                            {
                                opposite = CommonAttributes.Color.Black;
                            }
                            else
                            {
                                opposite = CommonAttributes.Color.White;
                            }
                            FindAllLegalMovesForColor(opposite);
                        }

                        if (selectedPiece.color == CommonAttributes.Color.Black)
                        {
                            FindAllProtectedPiecesForColor(CommonAttributes.Color.White);

                        }

                        if (selectedPiece.color == CommonAttributes.Color.White)
                        {
                            FindAllProtectedPiecesForColor(CommonAttributes.Color.Black);

                        }

                        LHighlighted = Lpieces[i].GetLegalMovesOnBoard(this);
                        //LHighlighted = CurrProtectedSquares;

                    }

                }

            }



        }

        public bool CheckForChecks(){



            for (int i = 0; i < Lpieces.Count; i++)
            {
                if (Lpieces[i].color == selectedPiece.color)
                {
                    Lpieces[i].GetLegalMovesOnBoard(this);

                }
            }


            for (int i=0;i<Lpieces.Count;i++)
            {
                if (Lpieces[i].color == selectedPiece.color)
                {
                    if (Lpieces[i].CanSeeKing)
                    {
                        return true;
                    }
                }
            }


            return false;
        }

        public Square GetSquare(int file, int rank)
        {
            for (int i=0;i<8;i++)
            {
                for (int j=0;j<8;j++)
                {
                    if (squares[i,j].file == file && squares[i,j].rank == rank)
                    {
                        return squares[i,j];
                    }
                }
            }

            return null;


        }
        public Piece GetPiece(int rank, int file)
        {
            Piece t = new Piece();
            for (int i = 0; i < Lpieces.Count; i++)
            {
                if (Lpieces[i].file == file)
                {
                    if (Lpieces[i].rank == rank)
                    {
                        t = Lpieces[i];
                    }
                }
            }
                

            return t;
        }

        public bool IsPieceProtected(Piece piece)
        {

            for (int i=0;i<CurrProtectedPieces.Count;i++)
            {
                if (CurrProtectedPieces[i] == piece)
                {
                    return true;
                }
            }
            return false;
        }
         
        public void DrawBoard(Graphics screen)
        {
            iDraw draw;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                     draw = squares[i, j];
                    draw.DrawSelf(screen);
                }
            }
            for (int i = 0; i < LHighlighted.Count; i++)
            {
                screen.FillRectangle(Brushes.DarkCyan, LHighlighted[i].position.X, LHighlighted[i].position.Y, LHighlighted[i].width, LHighlighted[i].height);
            }

            for (int i = 0; i < CurrProtectedSquares.Count; i++)
            {
               // screen.FillRectangle(Brushes.DarkGreen, CurrProtectedSquares[i].position.X,CurrProtectedSquares[i].position.Y, CurrProtectedSquares[i].width, CurrProtectedSquares[i].height);
            }
            for (int i=0;i<Lpieces.Count;i++)
            {
                draw = Lpieces[i];
                draw.DrawSelf(screen);
            }
        }

    }
}
