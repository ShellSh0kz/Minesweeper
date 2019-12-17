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


        //deconstructor

        ~Cell()
        {

        }


        //fields
        internal int z;
        internal int y;
        internal int _num;
        internal bool _isHidden = true;
        internal bool _hasFlag = false;

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


       

            
            
    }
}
