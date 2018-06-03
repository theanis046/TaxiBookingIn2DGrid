using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace Business.Core.Manager
{
    public class DistanceManager : IDistanceManager
    {
        IDistance _distanceCalculator;
        public DistanceManager(IDistance _distanceCalculator)
        {
            this._distanceCalculator = _distanceCalculator;
        }
        public int calculateDistance(IOrigin startingPoint, IOrigin destinationPoint)
        {
            return _distanceCalculator.calculateDistance(startingPoint, destinationPoint);
        }
    }
}
