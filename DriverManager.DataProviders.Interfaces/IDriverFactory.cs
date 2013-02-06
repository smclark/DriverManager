using System;
using System.Collections.Generic;
using System.Text;
using DriverManager.Models.Interfaces;

namespace DriverManager.DataProviders.Interfaces
{
    public interface IDriverFactory
    {
        IDriver CreateInstance();
    }
}
