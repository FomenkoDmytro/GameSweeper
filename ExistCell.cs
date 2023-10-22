using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSwiper
{
    public partial class Form1 : Form
    {
        int x;
        int y;
        public bool ExistCellTop(int x, int y)
        {
            if ((x - 1) >= 0)
            {
                return true;
            }
            return false;
        }

        public bool ExistCellTopRight(int x, int y)
        {
            if ((x - 1) >= 0 && (y + 1) < FieldCols)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ExistCellRight(int x, int y)
        {
            if ((y + 1) < FieldCols)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ExistCellBottomRight(int x, int y)
        {
            if ((x + 1) < FieldRows && (y + 1) < FieldCols)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ExistCellBottom(int x, int y)
        {
            if ((x + 1) < FieldRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ExistCellBottomLeft(int x, int y)
        {
            if ((x + 1) < FieldRows && (y - 1) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ExistCellLeft(int x, int y)
        {
            if ((y - 1) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ExistCellTopLeft(int x, int y)
        {
            if ((x - 1) >= 0 && (y - 1) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
