using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class Piece : CommonAttributes, iMove, iDraw
    {

        public Bitmap img;
        public bool CanSeeKing = false;
        public List<Piece> LprotectedPieces = new List<Piece>();
        public enum pieceTypes
        {
            Pawn, King, Queen, Rook, Bishop, Knight
        }
        public Piece()
        {
            width = 80;
            height = 80;
        }
        public pieceTypes pieceType;

        public override void DrawSelf(Graphics graphics)

        {
            graphics.DrawImage(img, position);
        }

        

        public virtual List<Square> GetLegalMovesOnBoard(Boardcs boardcs)
        {
            return null;
        }

    }
}
