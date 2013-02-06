using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DriverManager.Models.Interfaces
{
    public interface  IDriverModel
    {
        IList<IDriver> GetAllDrivers();
        IDriver GetDriverDetails(int id);
        //Returns a list as there may be multiple drivers with the same name
        IDriver GetDriverByName(string name);
        int CreateDriver(IDriver newDriver);
        int DeleteDriver(int driverID);
        int UpdateDriver(IDriver newDriverDetails, int driverID);
    }
}
