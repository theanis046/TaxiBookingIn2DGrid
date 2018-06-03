using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModels
{
    public class AvailableCar
    {
        public int car_id { get; set; }
        public int total_time { get; set; }
        public AvailableCar()
        {
            car_id = 0;
            total_time = 0;
        }

        public AvailableCar(int _car_id, int _total_time)
        {
            car_id = _car_id;
            total_time = _total_time;
        }

        public int SortByNameAscending(int total_time1, int total_time2)
        {

            return total_time1.CompareTo(total_time2);
        }

        // Default comparer for Part type.
        public int CompareTo(AvailableCar compareTime)
        {
            // A null value means that this object is greater.
            if (compareTime == null)
                return 1;

            else
                return this.total_time.CompareTo(compareTime.total_time);
        }
        public override int GetHashCode()
        {
            return total_time;
        }
        public bool Equals(AvailableCar other)
        {
            if (other == null) return false;
            return (this.total_time.Equals(other.total_time));
        }
    }
}
