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
    public partial class Form1 : Form
    {
        iDraw test;

        Boardcs board;

        public Form1()
        {

            test = new Piece();
            //test.DrawSelf(CreateGraphics());
            //test = new Square();
            //test.DrawSelf(CreateGraphics());
            this.Paint += Form1_Paint;
            this.Load += Form1_Load;
            this.MouseDown += Form1_MouseDown;
            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            board.FindClickedPiece(e.X, e.Y);

            DrawScene(CreateGraphics());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            board = MakeBoard();
        }

       public Boardcs MakeBoard()
        {

            Boardcs board = new Boardcs();
            


            return new Boardcs(board);

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawScene(CreateGraphics());
        }

        public void DrawScene(Graphics g)
        {
            g.Clear(Color.White);

            board.DrawBoard(g);
        }
    }
}
