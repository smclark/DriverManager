using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DriverManager.Enums;
using DriverManager.Models.Interfaces;

namespace DriverManager.Models
{
    public class Driver : IDriver
    {
        private int _id;
        private string _firstName;
        private string _lastName;

        private string _cardNumber;

        private string _country;

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

        public string CardNumber
        {
            get { return _cardNumber; }
            set { _cardNumber = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public bool Validate()
        {
            bool result = true;
            
            if (string.IsNullOrEmpty(_firstName))
                result = false;

            if (string.IsNullOrEmpty(_lastName))
                result = false;

            if (string.IsNullOrEmpty(_country))
                result = false;

            if (string.IsNullOrEmpty(_cardNumber))
                result = false;

            if (ID < 0)
                result = false;

            return result;
        }
    }
}
