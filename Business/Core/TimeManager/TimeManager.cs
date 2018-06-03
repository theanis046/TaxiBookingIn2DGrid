using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Core.TimeManager
{
    public class TimeManager : ITimeManager
    {
        public int calculateTime(int distance)
        {
            return distance * 1;
        }
    }
}
