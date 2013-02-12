using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DriverManager.Enums;

namespace DriverManager.Models.Interfaces
{
    public interface  IDriverModel
    {
        IList<IDriver> GetAllDrivers();
        IDriver GetDriverDetails(int id);
        IDriver GetDriverByName(string name);
        OpResult SaveDriver(IDriver newDriver);
        OpResult DeleteDriver(IDriver driverID);
        OpResult UpdateDriver(IDriver newDriverDetails);
    }
}
