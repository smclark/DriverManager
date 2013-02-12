using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DriverManager.DataProviders.Interfaces;
using DriverManager.Enums;
using DriverManager.Models;
using DriverManager.Models.Interfaces;

namespace DriverManager.DataProviders
{
    /// <summary>
    /// Data Provider to provide a simple set of Drivers. 
    /// Acting as a Database to allow the user to add/remove/update Drivers.
    /// </summary>
    public class DriverDataProvider : IDriverDataProvider
    {
        private readonly IList<IDriver> _drivers;



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

        /// <summary>
        /// Retrieve all the Drivers.
        /// </summary>
        /// <returns>IList of IDriver objects.</returns>
        public IList<IDriver> GetAll()
        {
            return _drivers;
        }

        /// <summary>
        /// Gets a Driver by the ID.
        /// </summary>
        /// <param name="id">The ID associated with the Driver.</param>
        /// <returns>IDriver Object</returns>
        public IDriver GetById(int id)
        {
            return (from driver in GetAll() where driver.ID == id select driver).First();
        }

        /// <summary>
        /// Gets a Driver by their FullName property.
        /// </summary>
        /// <param name="driverName">The FullName associated with the Driver.</param>
        /// <returns>IDriver Object</returns>
        public IDriver GetByName(string driverName)
        {
            return (from driver in GetAll() where driver.FullName == driverName select driver).First();
        }


        /// <summary>
        /// Deletes the specified driver.
        /// </summary>
        /// <param name="driver">The driver</param>
        /// <exception cref="ArgumentNullException">NULL Driver passed into method</exception>
        /// <returns></returns>
        public OpResult Delete(IDriver driver)
        {
            OpResult result = OpResult.Success;
            
            if (driver == null)
                result = OpResult.NullParameter;

            if (result == OpResult.Success)
            {
                if (_drivers.Contains(driver))
                    _drivers.Remove(driver);
                else
                    result = OpResult.ObjectNotExists;
            }

            return result;
        }

        /// <summary>
        /// Updates the an existing Driver.
        /// </summary>
        /// <param name="driver">The updated Driver.</param>
        /// <returns></returns>
        public OpResult Update(IDriver driver)
        {

            OpResult result = OpResult.Success;

            if (driver == null)
                result = OpResult.NullParameter;

            IDriver existingDriver = GetById(driver.ID);

            if (result == OpResult.Success)
            {
                if (existingDriver != null)
                {
                    int driverIndex = _drivers.IndexOf(existingDriver);

                    if (driverIndex >= 0)
                        _drivers[driverIndex] = driver;
                    else
                        result = OpResult.ObjectNotExists;
                }
                else
                {
                    result = OpResult.ObjectNotExists;
                }
            }

            return result;
        }

        /// <summary>
        /// Saves a New Driver to the "DB".
        /// </summary>
        /// <param name="driver">The new Driver.</param>
        /// <returns></returns>
        public OpResult Save(IDriver driver)
        {
            OpResult result = OpResult.Success;

            if (driver == null)
                result = OpResult.NullParameter;

            if (result == OpResult.Success)
            {
                if (!_drivers.Contains(driver))
                    _drivers.Add(driver);
                else
                    result = OpResult.ObjectExists;
            }

            return result;
        }
    }
}
