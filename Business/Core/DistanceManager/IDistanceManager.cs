using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Core.Manager
{
    public interface IDistanceManager
    {
        int calculateDistance(IOrigin startingPoint, IOrigin destinationPoint);
    }
}
