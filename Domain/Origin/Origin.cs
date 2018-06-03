using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Origin : IOrigin
    {
        private int _x = 0;
        private int _y = 0;
        public int x
        {
            get { return _x; }
            set { _x = value; }
        }
        public int y
        {
            get { return _y; }
            set { _y = value; }
        }
        public Origin()
        {
            x = 0;
            y = 0;
        }

        public Origin(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }
}
