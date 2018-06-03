using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class DestinationOrigin : IOrigin
    {
        private int _x = 0;
        private int _y = 0;
        public bool isTraversed { get; set; }
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
        public DestinationOrigin()
        {
            x = 0;
            y = 0;
            isTraversed = false;
        }
        public DestinationOrigin(int _x, int _y, bool _isTraversed)
        {
            x = _x;
            y = _y;
            isTraversed = _isTraversed;
        }
    }
}
