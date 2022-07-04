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
  public  class Square : CommonAttributes
    {
        public Piece piece = null;
        public Square(Color color, int rank, int file, Point point )
        {
            this.color = color;
            this.rank = rank;
            this.file = file;
            this.position = point;
            this.width = 90;
            this.height = 90;
        }
        public override void DrawSelf(Graphics graphics)

        {
            if (color == Color.White)
                graphics.FillRectangle(Brushes.White, position.X, position.Y, width, height);
            if (color == Color.Black)
                graphics.FillRectangle(Brushes.Maroon, position.X, position.Y, width, height);


        }

        public void attachPiece(Piece obj)
        {
            this.piece = obj;
            this.piece.rank = rank;
            this.piece.file = file;
            this.piece.position = getPiecePointOnSquare();
       
        }
        public void removePiece()
        {
            this.piece.rank = -1;

            this.piece = null;
        }

        public Point getPiecePointOnSquare()
        {
            Point val = new Point(position.X   , position.Y );

            return val;
        }

    }
}
