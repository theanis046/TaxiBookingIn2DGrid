using Business.Core;
using Business.Core.BookingManager;
using Business.Core.Manager;
using Business.Core.TimeManager;
using Domain;
using Domain.Vehicle;
using Domain.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Business.UnitTests
{
    public class BookingManager_Test
    {

        /// <summary>
        /// On system Initialization there are only 3 cars. This test verifies the count of cars
        /// </summary>
        [Fact]
        public void TestTotalCarsCount()
        {
            var distanceManager = new Mock<IDistanceManager>();
            var timeManager = new Mock<ITimeManager>();
            var bookingManager = new BookingManager(distanceManager.Object, timeManager.Object);

            bookingManager.getAllCars();
            Assert.True(bookingManager.getAllCars().Count == 3);
        }

        /// <summary>
        /// Get Nearest available car with respect to destination and customer position.
        /// </summary>
        [Fact]
        public void AvailableCarsTest()
        {
            var distanceManager = new Mock<IDistanceManager>();
            var timeManager = new Mock<ITimeManager>();
            var bookingManager = new BookingManager(distanceManager.Object, timeManager.Object);

            CarRequestModel bookCarRequestModel = new CarRequestModel();
            bookCarRequestModel.customerPosition = new Origin(1, 1);
            bookCarRequestModel.destination = new Origin(2, 2);

            Assert.True(bookingManager.getAvailableCars(bookCarRequestModel).car_id == 1);
        }


        /// <summary>
        /// Books a car for a customer. Returns true if ride books successfully.
        /// This test will pass if ride books successfully.
        /// </summary>
        [Fact]
        public void BookCarTest()
        {
            var distanceManager = new Mock<IDistanceManager>();
            var timeManager = new Mock<ITimeManager>();
            var bookingManagerBookCarTest = new BookingManager(distanceManager.Object, timeManager.Object);
            bookingManagerBookCarTest.reset();
            BookCarRequestModel bookCarRequestModel = new BookCarRequestModel(1,"C1",new DestinationOrigin(1,1,false), new DestinationOrigin(2, 2, false));
            Assert.True(bookingManagerBookCarTest.bookCar(bookCarRequestModel).isBooked == true);
        }

        /// <summary>
        /// After booking a car. Next available car for customer booking.
        /// If more cars are available then one with lowest id will be returned
        /// </summary>
        [Fact]
        public void AvailableCarsAfterBooking()
        {
            var distanceManager = new Mock<IDistanceManager>();
            var timeManager = new Mock<ITimeManager>();
            var bookingManager = new BookingManager(distanceManager.Object, timeManager.Object);

            BookCarRequestModel bookCarRequestModel = new BookCarRequestModel(1, "C1", new DestinationOrigin(1, 1, false), new DestinationOrigin(2, 2, false));
            bookingManager.bookCar(bookCarRequestModel);

            CarRequestModel bookCarRequestModel1 = new CarRequestModel();
            bookCarRequestModel1.customerPosition = new Origin(1, 1);
            bookCarRequestModel1.destination = new Origin(2, 2);

            Assert.True(bookingManager.getAvailableCars(bookCarRequestModel1).car_id == 2);
        }

        /// <summary>
        /// Increments time stamp of service by one unit. It updates times and current position
        /// of all booked cars.
        /// </summary>
        [Fact]
        public void IncrementTimeStampForBookedCars()
        {
            var distanceManager = new Mock<IDistanceManager>();
            var timeManager = new Mock<ITimeManager>();
            var bookingManager = new BookingManager(distanceManager.Object, timeManager.Object);

            BookCarRequestModel bookCarRequestModel = new BookCarRequestModel(1, "C1", new DestinationOrigin(1, 1, false), new DestinationOrigin(2, 2, false));
            bookingManager.bookCar(bookCarRequestModel);


            bookingManager.incrementTimeStamp();

            Car car =BookingManager.lstCars.Where(c => c.isBooked == true).FirstOrDefault();
            Assert.True(car.currentPosition.x == 1);
        }

        /// <summary>
        /// It resets all cars to initial position
        /// </summary>
        [Fact]
        public void resetCars()
        {
            var distanceManager = new Mock<IDistanceManager>();
            var timeManager = new Mock<ITimeManager>();
            var bookingManager = new BookingManager(distanceManager.Object, timeManager.Object);
            bool flag = false;

            BookCarRequestModel bookCarRequestModel = new BookCarRequestModel(1, "C1", new DestinationOrigin(1, 1, false), new DestinationOrigin(2, 2, false));
            bookingManager.bookCar(bookCarRequestModel);
            bookingManager.incrementTimeStamp();

            
            bookingManager.reset();

            BookingManager.lstCars.ForEach(c =>
            {
                if (c.isBooked == true)
                {
                    flag = true;
                }
            });

            
            Assert.True(flag == false);
        }

        /// <summary>
        /// Calculates the distance between origin (0,0) and (1,1). Manhatten distance should be 2.
        /// Runs successfully if distance between these points is 2.
        /// </summary>
        [Fact]
        public void TestManhattenDistance()
        {
            IDistance manDistance = new ManhattenDistance();
            var distanceManager = new DistanceManager(manDistance);

            var distance = distanceManager.calculateDistance(new Origin(0, 0), new Origin(1, 1));

            Assert.True(distance == 2);
        }
    }
}
