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
    }
}
