using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace Business.Core
{
    public class ManhattenDistance : IDistance
    {
        public int calculateDistance(IOrigin _startingPoint, IOrigin _destinationPoint)
        {
            int p1 = Math.Abs(_startingPoint.x - _destinationPoint.x);
            int p2 = Math.Abs(_startingPoint.y - _destinationPoint.y);
            return p1 + p2;
        }
    }
}
