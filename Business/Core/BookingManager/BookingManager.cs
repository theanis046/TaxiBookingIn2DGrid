using Business.Core.Manager;
using Business.Core.TimeManager;
using Domain.Vehicle;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Domain;

namespace Business.Core.BookingManager
{
    public class BookingManager : IBookingManager
    {

        /// <summary>
        /// For keeping this exercise simple. There is no persistance layer. so declaring cars here.
        /// Ideally it should be fetched from db through repositories.
        /// </summary>
        public static Car car1 = new Car(1, "D1", "");
        public static Car car2 = new Car(2, "D2", "");
        public static Car car3 = new Car(3, "D3", "");
        public static List<Car> lstCars = new List<Car> { car1, car2, car3 };
        public IDistanceManager distanceManager;
        public ITimeManager timeManager;


        public BookingManager(IDistanceManager distanceManager, ITimeManager timeManager)
        {
            this.distanceManager = distanceManager;
            this.timeManager = timeManager;
        }

        public AvailableCar getAvailableCars(CarRequestModel request)
        {
            int minDistanceValue = int.MaxValue;
            List<AvailableCar> cars = new List<AvailableCar>() ;

            lstCars.ForEach(c =>
            {
                if (c.isBooked == false && c.bookedBy == "")
                {
                    int distance_car_to_customer = distanceManager.calculateDistance(c.currentPosition, request.customerPosition);
                    int customer_to_destination = distanceManager.calculateDistance(request.customerPosition, request.destination);
                    int distance = distance_car_to_customer + customer_to_destination;
                    if (distance <= minDistanceValue)
                    {
                        minDistanceValue = distance;
                        int time = timeManager.calculateTime(distance);

                        AvailableCar availableCar = new AvailableCar(c.id,time);

                        cars.Add(availableCar);
                    }
                }
            });

            cars = cars.OrderBy(c => c.total_time).ToList();
            return cars.FirstOrDefault();
        }



        public BookCarResponseModel bookCar(BookCarRequestModel bookCarRequestModel)
        {

            if (lstCars.Where(lc => lc.bookedBy == bookCarRequestModel.customerId).Count() != 0)
            {
                return new BookCarResponseModel( string.Format ("{0} is already booked" , bookCarRequestModel.car_id), false);
            }
            Car car =  lstCars.Find(c => c.id == bookCarRequestModel.car_id && c.isBooked == false);
            if (car != null)
            {
                car.isBooked = true;
                car.bookedBy = bookCarRequestModel.customerId;
                car.lstDestinationPosition.Clear();

                DestinationOrigin dOrigin = new DestinationOrigin(bookCarRequestModel.customerCurrentPosition.x, bookCarRequestModel.customerCurrentPosition.y,false);
                DestinationOrigin dOrigin1 = new DestinationOrigin(bookCarRequestModel.customerDestinationPosition.x, bookCarRequestModel.customerDestinationPosition.y,false);
                
                car.lstDestinationPosition.Add(dOrigin);
                car.lstDestinationPosition.Add(dOrigin1);
                return new BookCarResponseModel(string.Format("{0} is booked for {1}", bookCarRequestModel.car_id, bookCarRequestModel.customerId), true);
            }
            return new BookCarResponseModel(string.Format("{0} is already booked", bookCarRequestModel.car_id), false);

        }

        public List<Car> getAllCars()
        {
            return lstCars;
        }

        public bool incrementTimeStamp()
        {
            List<Car> cars = new List<Car>();

            lstCars.FindAll(c => c.isBooked == true).ForEach(c =>
            {
               c = c.incrementOrigin();
            });

            return true;
        }

        public bool reset()
        {
            lstCars.ForEach(lc =>
            {
                lc.reset();
            });

            return true;
        }
    }
}
