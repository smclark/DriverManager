using System;
using DriverManager.Models.Interfaces.Messages;

namespace DriverManager.Models.Messages
{
    public class DriverCreatedMessage : IDriverCreatedMessage
    {
        public string Name { get; private set; }

        public DriverCreatedMessage(string driverName)
        {
            if(string.IsNullOrEmpty(driverName))
                throw new ArgumentException("Driver Name Cannot Be Empty");

            Name = driverName;
        }
    }
}
