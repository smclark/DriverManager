using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DriverManager.Models.Interfaces
{
    public interface IVehicle
    {
        string RegistrationNumber { get; set; }
        string VIN { get; set; }
    }
}
