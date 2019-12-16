using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace MineSweeper
{
    class Board
    {
        public Board(int len, int wid, int mines)
        {
            _length = len;
            _width = wid;
            _mines = mines;
            _gameover = false;
            if(ValidGame())
            {
                GenerateBoard();
            }
            else
            {
                throw new Exception("Invalid Game");
            }

           
        }


        public Board(int gameNO)
        {
            throw new Exception("Not implemented");
        }

        private int _length;
        private int _width;
        private int _mines;
        private Cell[,] _cells;
        private bool _gameover;
        private bool _gamewin = false;


        private bool ValidGame()
        {
            if(_width * _length >= _mines)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void GenerateBoard()
        {
            int i, k, m, n;
            Random x = new Random();




            //create new cells
            _cells = new Cell[_length, _width];
            for(i = 0; i < _length; i++)
            {
                for(k = 0; k < _width; k++)
                {
                    _cells[i,k] = new Cell(i, k);
                }
            }

            //populate the array with mines

            for (i = 0; i < _mines; i++)
            {

                m = x.Next(0, _length);
                n = x.Next(0, _width);
                if (_cells[m, n].Num != -1)
                {
                    Console.WriteLine("Mine " + i + " at " + m + " " + n);
                    _cells[m, n].Num = -1;
                    UpdateCells(m, n);
                }
                else
                {
                    i--;
                }
            }

        }

        private void UpdateCells(int x, int y)
        {
           
            for(int i = x - 1; i<= (x + 1); i++)
            {

                if (i >= 0 && i <= _length - 1)
                {

                    for (int k = y - 1; k <= (y + 1); k++)
                    {


                        if (!(i == x && k == y) && k >= 0 && k <= _width - 1)
                        {
                            
                            _cells[i, k].Inc();
                        }
                    }
                }

            }
        }
        public void ConsolePrintBoard()
        {

            for(int i = 0; i < _length; i++)
            {
                for(int k = 0; k < _width; k++)
                {
                    Console.Write("{0} ", _cells[i,k].Num);
                }
                Console.WriteLine("");
            }
        }

        public void RenderBoard(PaintEventArgs e)
        {

            //sizes to render
            int sides = 50;

            for (int i = 0; i < _length; i++)
            {
                for(int k = 0; k < _width; k++)
                {
                    _cells[i, k].render(e, sides);
                }
            }
        }

        // how a user interacts with the game
        public void Click(Point cursorPos, char type)
        {
            int sides = 50;
            int x = cursorPos.X / (sides + 5);
            int y = cursorPos.Y / (sides + 5);

            if (cursorPos.X % (sides + 5) >= 5 && cursorPos.Y % (sides + 5) >= 5 && _gameover == false && _gamewin == false)
            {
                Console.WriteLine("Cell {0} {1}", y, x);
                if (type == 'l')
                {                   
                    Show(x, y);
                    if(_cells[x,y].CheckLoss())
                    {
                        GameOver();
                    }
                }
                else
                {
                    _cells[x, y].placeFlag();
                    CheckWin();
                }

            }
        }


        public void Show(int x, int y)
        {
            _cells[x,y].show();

            if(_cells[x,y].Num == 0)
            {
                if(x - 1 >= 0 && y - 1 >= 0 && _cells[x-1, y-1].isHidden())
                {
                    Show(x - 1, y - 1);
                }
                if (y - 1 >= 0 && _cells[x, y - 1].isHidden())
                {
                    Show(x, y - 1);
                }
                if (x + 1 < _length && y - 1 >= 0 && _cells[x + 1, y - 1].isHidden())
                {
                    Show(x + 1, y - 1);
                }


                if (x - 1 >= 0 && _cells[x - 1, y].isHidden())
                {
                    Show(x - 1, y);
                }
                if (x + 1 < _length && _cells[x + 1, y].isHidden())
                {
                    Show(x + 1, y);
                }

                if (x + 1 < _length && y + 1 < _width && _cells[x + 1, y + 1].isHidden())
                {
                    Show(x + 1, y + 1);
                }
                if ( y + 1 < _width && _cells[x, y + 1].isHidden())
                {
                    Show(x, y + 1);
                }
                if (x - 1 >= 0 && y + 1 < _width && _cells[x - 1, y + 1].isHidden())
                {
                    Show(x - 1, y + 1);
                }

            }
        }

        public void GameOver()
        {
            _gameover = true;
            //show remainging mines
            for(int i = 0; i < _length; i++)
            {
                for(int k = 0; k < _width; k++)
                {
                    if (_cells[i, k].Num == -1)
                    {
                        Show(i, k);
                    }
                }
            }
        }

        private void CheckWin()
        {
            int correct = 0;
            bool thing = true;
            //show remainging mines
            for (int i = 0; i < _length; i++)
            {
                for (int k = 0; k < _width; k++)
                {
                    if (_cells[i, k].Flag && _cells[i,k].Num == -1)
                    {
                        correct++;
                    }
                    if (_cells[i, k].Flag && _cells[i, k].Num != 0)
                    {
                        thing = false;
                    }
                }
            }

            if(correct == _mines && thing)
            {
                _gamewin = true;
                Console.WriteLine("Winner");
            }
        }

    }





}
