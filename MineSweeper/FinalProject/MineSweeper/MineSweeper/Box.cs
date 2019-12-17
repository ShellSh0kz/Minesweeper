using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace MineSweeper
{
    class Box : Cell
    {
        public Box(int x, int y)
        {
            this.z = x;
            this.y = y;
            this._num = 0;
        }




        public void render(PaintEventArgs e, int sides)
        {

            //draw the thing
            int offset = sides + 5;
            int numOffset = (int)(sides / 2.5);

            Point pnt = new Point(z * offset + 5, y * offset + 5);
            Size sz = new Size(sides, sides);
            Rectangle img = new Rectangle(pnt, sz);
            Pen blk = new Pen(Brushes.Black);
            Brush lg = new SolidBrush(Color.LightGray);
            e.Graphics.DrawRectangle(blk, img);


            //if the thing isnt hidden

            if (this._isHidden)
            {
                //fill with blank square
                e.Graphics.FillRectangle(lg, img);

                if (this._hasFlag)
                {

                    Font fnt = new Font("Helvetica", (float)(sides * 0.25), FontStyle.Regular);
                    Brush brsh = new SolidBrush(Color.Green);


                    e.Graphics.DrawString("F", fnt, brsh, z * offset + numOffset, y * offset + numOffset);
                }
            }
            else
            {
                //fill with number

                if (_num != 0)
                {

                    Color colour;
                    if (_num == -1)
                    {
                        colour = Color.Red;
                    }
                    else
                    {
                        colour = Color.Blue;
                    }

                    Font fnt = new Font("Helvetica", (float)(sides * 0.25), FontStyle.Regular);
                    Brush brsh = new SolidBrush(colour);


                    e.Graphics.DrawString(_num.ToString(), fnt, brsh, z * offset + numOffset, y * offset + numOffset);
                }



            }

        }


        }
}
