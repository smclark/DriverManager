using System;
using System.Collections.Generic;
using DriverManager.DataProviders.Interfaces;
using DriverManager.Enums;
using DriverManager.Models.Interfaces;
using NLog;

namespace DriverManager.Models
{
    public class DriverModel : IDriverModel
    {
        private readonly IDriverDataProvider _dataProvider;
        private Logger _logger;
        public DriverModel(IDriverDataProvider dataProvider)
        {
            if (dataProvider == null)
                throw new ArgumentNullException("dataProvider");

            _dataProvider = dataProvider;

            _logger = LogManager.GetLogger("f");

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

        public OpResult SaveDriver(IDriver newDriver)
        {
            OpResult result = OpResult.Success;

            if (newDriver == null)
                result = OpResult.NullParameter;
            
            if (result == OpResult.Success)
            {
                if(newDriver.Validate())
                {
                    try
                    {
                        result = _dataProvider.Save(newDriver);
                    }
                    catch (Exception ex)
                    {
                        result = OpResult.ExceptionOccurred;
                        _logger.TraceException(ex.Message, ex);
                    }
                }
                else
                {
                    result = OpResult.InvalidParameters;
                }
            }
            return result;
        }

        public OpResult DeleteDriver(IDriver driver)
        {
            OpResult result = OpResult.Success;

            if (driver == null)
                result = OpResult.NullParameter;

            if (result == OpResult.Success)
            {
                try
                {
                    result = _dataProvider.Delete(driver);
                }
                catch (Exception ex)
                {
                    result = OpResult.ExceptionOccurred;
                    _logger.TraceException(ex.Message, ex);
                }
            }

            return result;
        }

        public OpResult UpdateDriver(IDriver newDriverDetails)
        {
            OpResult result = OpResult.Success;

            if (newDriverDetails == null)
                result = OpResult.NullParameter;

            if (result == OpResult.Success)
            {
                try
                {
                    result = _dataProvider.Update(newDriverDetails);
                }
                catch (Exception ex)
                {
                    result = OpResult.ExceptionOccurred;
                    _logger.TraceException(ex.Message, ex);
                }
            }

            return result;
        }

    }
}
