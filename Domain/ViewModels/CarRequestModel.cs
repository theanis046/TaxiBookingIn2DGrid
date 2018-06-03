using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModels
{
    public class CarRequestModel
    {
        public IOrigin customerPosition { get; set; }
        public IOrigin destination { get; set; }
        public CarRequestModel()
        {
            customerPosition = new Origin();
            destination = new Origin();
        }
    }
}
