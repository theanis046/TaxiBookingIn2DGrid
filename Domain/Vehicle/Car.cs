using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Vehicle
{
    public class Car : IVehicle
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public bool isBooked { get; set; }
        public IOrigin currentPosition { get; set; }
        public List<DestinationOrigin> lstDestinationPosition { get; set; }
        public string driverId { get; set; }
        public string bookedBy { get; set; }

        public Car()
        {
            this._id = int.MinValue;
            this.isBooked = false;
            this.currentPosition = new Origin();
            this.lstDestinationPosition = new List<DestinationOrigin>();
            this.driverId = string.Empty;
            this.bookedBy = string.Empty;
        }

        public Car(int id, string driverId, string bookedBy)
        {
            this._id = id;
            this.driverId = driverId;
            this.bookedBy = bookedBy;
            this.isBooked = false;
            this.currentPosition = new Origin();
            this.lstDestinationPosition = new List<DestinationOrigin>();
        }

        public Car incrementOrigin()
        {
            foreach (DestinationOrigin origin in this.lstDestinationPosition.Where(c => c.isTraversed == false))
            {
                bool breakFlag = false;
                if (this.currentPosition.x < origin.x)
                {
                    this.currentPosition.x++;
                    breakFlag = true;
                }
                else if (this.currentPosition.x > origin.x)
                {
                    this.currentPosition.x--;
                    breakFlag = true;
                }


                else if (this.currentPosition.y < origin.y)
                {
                    this.currentPosition.y++;
                    breakFlag = true;
                }
                else if (this.currentPosition.y > origin.y)
                {
                    this.currentPosition.y--;
                    breakFlag = true;
                }

                if (this.currentPosition.x == origin.x &&
                    this.currentPosition.y == origin.y &&
                    origin.isTraversed == false
                     )
                {
                    origin.isTraversed = true;
                    breakFlag = true;
                }
                if (breakFlag == true)
                {
                    break;
                }
            }

            var destinations = this.lstDestinationPosition.Where(ld => ld.isTraversed == false);
            
            if (destinations.Count() == 0)
            {
                this.isBooked = false;
                this.bookedBy = "";
            }
            return this;
        }

        public bool reset()
        {
            this.bookedBy = "";
            this.currentPosition = new Origin();
            this.isBooked = false;
            this.lstDestinationPosition = new List<DestinationOrigin>();
            return true;
        }
    }
}
