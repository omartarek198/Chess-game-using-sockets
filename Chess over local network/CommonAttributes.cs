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
    public class CommonAttributes : iDraw
    {

       public Point position;
        public int width, height, rank, file;
        public enum Color
        {
            Black,White
        }

        public Color  color;


        public virtual void DrawSelf(Graphics screen)
        {
            MessageBox.Show("default draw");
        }

        public bool IsClicked(int x, int y)
        {

            if (x > position.X && x < position.X + width && y > position.Y && y < position.Y + height)
            {
                return true;
            }
            return false;
        }




    }
}
