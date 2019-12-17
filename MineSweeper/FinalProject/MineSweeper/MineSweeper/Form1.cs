using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class Form1 : Form
    {
        Board game;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            int hieght = 10;
            int width = 10;

            game = new Board(width, hieght, 10);
            game.ConsolePrintBoard();

            this.Width = width * 55 + 20;
            this.Height = hieght * 55 + 50;


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            game.RenderBoard(e);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Point cursorPos = this.PointToClient(Cursor.Position);
            switch (e.Button)
            {
                case MouseButtons.Left:
                    
                    this.Invalidate();
                    game.Click(cursorPos, 'l');
                    break;
                case MouseButtons.Right:
                    game.Click(cursorPos, 'r');
                    this.Invalidate();
                    break;
            }
        }
            
    }
}
