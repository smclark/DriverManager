using System;
using System.Collections.Generic;
using System.Text;
using DriverManager.Enums;
using DriverManager.Models.Interfaces;

namespace DriverManager.DataProviders.Interfaces
{
    public interface IDriverDataProvider
    {
        IList<IDriver> GetAll();
        IDriver GetById(int id);
        IDriver GetByName(string driverName);
        OpResult Save(IDriver driver);
        OpResult Delete(IDriver driver);
        OpResult Update(IDriver driver);
    }
}
