using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Business.Core.Manager;
using Business.Core.BookingManager;
using Domain.Vehicle;
using Domain.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaxiBookingSystem_nutonomy.Controllers
{
    public class NutonomyTaxiBooking : Controller
    {
        IDistanceManager _distanceManger;
        IBookingManager _bookingManager;

        public NutonomyTaxiBooking(IDistanceManager distanceManager, IBookingManager bookingManager)
        {
            this._distanceManger = distanceManager;
            this._bookingManager = bookingManager;
        }

        /// <summary>
        /// Gets All available cars with respect to customer and desired destination
        /// </summary>
        /// <param name="request">
        /// Gets user Location and Desired Destination
        /// </param>
        /// <returns>
        /// List of nearby cars. If there is no nearby car then returns HTTP status code 204.
        /// </returns>
        [HttpPost]
        [Route("api/v1/book")]
        public AvailableCar GetAvailableCars([FromBody]CarRequestModel request)
        {
            return _bookingManager.getAvailableCars(request);
        }

        /// <summary>
        /// To view current position of all cars(booked or free) in system.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/cars")]
        public IEnumerable<Car> GetAllCars()
        {
            return _bookingManager.getAllCars();
        }


        /// <summary>
        /// Book a ride. For a customer. 
        /// </summary>
        /// <param name="request"></param>
        /// <returns>
        /// </returns>
        [HttpPost]
        [Route("api/v1/bookACar")]
        public dynamic BookCar([FromBody]BookCarRequestModel request)
        {
            return _bookingManager.bookCar(request);
        }


        /// <summary>
        /// Increments service time stamp by 1 unit.
        /// Moves all cars one step ahead.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/tick")]
        public bool incrementTimeStamp()
        {
            return _bookingManager.incrementTimeStamp();
        }


        /// <summary>
        /// resets all system to initial position.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/reset")]
        public bool reset()
        {
            return _bookingManager.reset();
        }
    }
}
