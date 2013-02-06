using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DriverManager.DataProviders.Interfaces;
using DriverManager.Models.Interfaces;

namespace DriverManager.Models
{
    public class DriverModel : IDriverModel
    {
        private IDriverDataProvider _dataProvider;
        public DriverModel(IDriverDataProvider dataProvider)
        {
            if (dataProvider == null)
                throw new ArgumentNullException("dataProvider");

            _dataProvider = dataProvider;
        }
        public IList<IDriver> GetAllDrivers()
        {
            return _dataProvider.GetAll();
        }

        public IDriver GetDriverDetails(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Driver ID cannot be 0");

            return _dataProvider.GetById(id);
        }

        public IDriver GetDriverByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name Cannot Be Empty");

            return _dataProvider.GetByName(name);
        }

        public int CreateDriver(IDriver newDriver)
        {
            return _dataProvider.Save(newDriver);
        }

        public int DeleteDriver(int driverID)
        {
            throw new NotImplementedException();
        }

        public int UpdateDriver(IDriver newDriverDetails, int driverID)
        {
            throw new NotImplementedException();
        }
    }
}
