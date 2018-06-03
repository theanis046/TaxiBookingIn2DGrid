using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModels
{
    public class BookCarResponseModel
    {
        public string message { get; set; }
        public bool isBooked { get; set; }
        public BookCarResponseModel(string _message, bool _isBooked)
        {
            message = _message;
            isBooked = _isBooked;
        }
    }
}
