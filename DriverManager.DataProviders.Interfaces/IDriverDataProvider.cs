using System;
using System.Collections.Generic;
using System.Text;
using DriverManager.Models.Interfaces;

namespace DriverManager.DataProviders.Interfaces
{
    public interface IDriverDataProvider
    {
        IList<IDriver> GetAll();
        IDriver GetById(int id);
        IDriver GetByName(string driverName);
        int Save(IDriver driver);
        int Delete(int driverId);
        int Update(IDriver driver);
    }
}
