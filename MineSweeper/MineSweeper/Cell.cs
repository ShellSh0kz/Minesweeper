using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MineSweeper
{
    class Cell
    {

        //constructor
        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
            _num = 0;


            //Console.WriteLine("New Cell at {0} {1}", x, y);
        }


        //deconstructor

        ~Cell()
        {

        }


        //fields
        private int x;
        private int y;
        private int _num;
        private bool _isHidden = true;
        private bool _hasFlag = false;

        //allows us to check if a square has 0
        public int Num
        {
            get
            {
                    return _num;
            }
            set
            {
                    _num = value;
            }
        }

        public bool Flag {
            get {
                return _hasFlag;
            }
            set { }
        }


        public bool CheckLoss()
        {
            if(_num == -1)
            {
                return true;
            }
            return false;
        }

        public void show()
        {
            if (_isHidden == true && _hasFlag == false)
            {
                _isHidden = false;
                
            }
        }

        public bool isHidden()
        {
            if(_isHidden == true)
            {
                return true;
            }
            return false;
        }


        public void placeFlag()
        {
            if(_hasFlag == true)
            {
                _hasFlag = false;
            }
            else
            {
                _hasFlag = true;
            }
        }

        public void Inc()
        {
            if(_num != -1)
            {
                _num++;
            }
        }


        public void render(PaintEventArgs e, int sides)
        {

            //draw the thing
            int offset = sides + 5;
            int numOffset = (int)(sides / 2.5);

            Point pnt = new Point(x * offset + 5, y * offset + 5);
            Size sz = new Size(sides, sides);
            Rectangle img = new Rectangle(pnt, sz);
            Pen blk = new Pen(Brushes.Black);
            Brush lg = new SolidBrush(Color.LightGray);
            e.Graphics.DrawRectangle(blk, img);


            //if the thing isnt hidden

            if (_isHidden)
            {
                //fill with blank square
                e.Graphics.FillRectangle(lg, img);

                if(_hasFlag)
                {

                    Font fnt = new Font("Helvetica", (float)(sides * 0.25), FontStyle.Regular);
                    Brush brsh = new SolidBrush(Color.Green);


                    e.Graphics.DrawString("F", fnt, brsh, x * offset + numOffset, y * offset + numOffset);
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


                    e.Graphics.DrawString(_num.ToString(), fnt, brsh, x * offset + numOffset, y * offset + numOffset);
                }


                
            }

            
            
        }
    }
}
