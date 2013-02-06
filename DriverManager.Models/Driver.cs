using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DriverManager.Models.Interfaces;

namespace DriverManager.Models
{
    public class Driver : IDriver
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private IAddress _addressInfo;
        private IVehicle _vehicleInfo;
        
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string FullName
        {
            get { return _firstName + " " + _lastName; }
        }

        public IAddress AddressInfo
        {
            get { return _addressInfo; }
            set { _addressInfo = value; }
        }

        public IVehicle VehicleInfo
        {
            get { return _vehicleInfo; }
            set { _vehicleInfo = value; }
        }
    }
}
