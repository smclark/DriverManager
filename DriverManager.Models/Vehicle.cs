using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DriverManager.Models.Interfaces;

namespace DriverManager.Models
{
    public class Vehicle : IVehicle
    {
        private string _registrationNumber;
        private string _vin;

        public string RegistrationNumber
        {
            get { return _registrationNumber; }
            set { _registrationNumber = value; }
        }

        public string VIN
        {
            get { return _vin; }
            set { _vin = value; }
        }
    }
}
