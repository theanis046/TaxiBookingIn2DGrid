using Domain.Vehicle;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Core.BookingManager
{
    public interface IBookingManager
    {
        List<Car> getAllCars();
        AvailableCar getAvailableCars(CarRequestModel request);
        BookCarResponseModel bookCar(BookCarRequestModel bookCarRequestModel);
        bool incrementTimeStamp();
        bool reset();
    }
}
