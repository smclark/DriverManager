using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DriverManager.Models.Interfaces
{
    public interface IDriver
    {
        int ID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string FullName { get; }
        IAddress AddressInfo { get; set; }
        IVehicle VehicleInfo { get; set; }
    }
}
