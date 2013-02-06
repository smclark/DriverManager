using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DriverManager.DataProviders.Interfaces;
using DriverManager.Models;
using DriverManager.Models.Interfaces;

namespace DriverManager.DataProviders
{
    public class DriverDataProvider : IDriverDataProvider
    {
        private IList<IDriver> _drivers;

        public DriverDataProvider()
        {
            _drivers = new List<IDriver>()
                           {
                               new Driver {FirstName = "Pedro", LastName = "Lamont", ID = 1},
                               new Driver {FirstName = "Peter", LastName = "Peterson", ID = 2},
                               new Driver {FirstName = "Grant", LastName = "Davids", ID = 3},
                               new Driver {FirstName = "Steve", LastName = "Clark", ID = 4},
                               new Driver {FirstName = "Jonny", LastName = "Larsson", ID = 5}
                           };
        }

        public IList<IDriver> GetAll()
        {
            return _drivers;
        }

        public IDriver GetById(int id)
        {
            return (from driver in GetAll() where driver.ID == id select driver).First();
        }

        public IDriver GetByName(string driverName)
        {
            return (from driver in GetAll() where driver.FullName == driverName select driver).First();
        }

        public int Delete(int driverId)
        {
            throw new NotImplementedException();
        }

        public int Update(IDriver driver)
        {
            throw new NotImplementedException();
        }

        public int Save(IDriver driver)
        {
            _drivers.Add(driver);
            return 0;
        }
    }
}
