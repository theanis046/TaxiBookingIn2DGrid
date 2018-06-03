using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModels
{
    public class BookCarRequestModel
    {
        public int car_id { get; set; }
        public string customerId { get; set; }
        public IOrigin customerCurrentPosition { get; set; } 
        public IOrigin customerDestinationPosition { get; set; }
        public BookCarRequestModel()
        {
            car_id = 0;
            customerId = string.Empty;
            customerCurrentPosition = new DestinationOrigin();
            customerDestinationPosition = new DestinationOrigin();
        }


        public BookCarRequestModel(int _carId, string _customerId, DestinationOrigin _customerCurrentPosition, DestinationOrigin _customerDestinationPosition)
        {
            car_id = _carId;
            customerId = _customerId;
            customerCurrentPosition = _customerCurrentPosition;
            customerDestinationPosition = _customerDestinationPosition;
        }
    }
}
