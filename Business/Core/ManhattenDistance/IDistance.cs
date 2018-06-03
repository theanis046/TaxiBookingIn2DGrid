using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Core
{
    public interface IDistance
    {
        int calculateDistance(IOrigin _startingPoint, IOrigin _destinationPoint);
    }
}
