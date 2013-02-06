using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DriverManager.Models.Interfaces;

namespace DriverManager.Models
{
    public class Address : IAddress
    {
        private string _streetName;
        private string _city;
        private string _country;
        private string _postCode;

        public string StreetName
        {
            get { return _streetName; }
            set { _streetName = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public string PostCode
        {
            get { return _postCode; }
            set { _postCode = value; }
        }
    }
}
