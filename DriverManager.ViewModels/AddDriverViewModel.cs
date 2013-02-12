using System;
using Caliburn.Micro;
using DriverManager.Enums;
using DriverManager.Models.Interfaces;
using DriverManager.Models.Messages;
using DriverManager.ViewModels.Interfaces;

namespace DriverManager.ViewModels
{
    public class AddDriverViewModel : Screen, IAddDriverViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressInfo { get; set; }
        public string VehicleInfo { get; set; }

        private readonly IDriverModel _model;
        private readonly IEventAggregator _eventAggregator;
        private readonly Func<IDriver> _createDriver;

        public AddDriverViewModel(Func<IDriver> createDriver, IDriverModel model, IEventAggregator eventAggregator)
        {
            if (model == null)
                throw new ArgumentNullException("model");
            if (createDriver == null)
                throw new ArgumentNullException("createDriver");

            _model = model;
            _createDriver = createDriver;

            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }

        public void Save()
        {
            var driver = _createDriver();
            driver.FirstName = FirstName;
            driver.LastName = LastName;

            var result = _model.SaveDriver(driver);

            if (result == OpResult.Success)//No error occurred
            {
                _eventAggregator.Publish(new DriverCreatedMessage(driver.FullName));
            }
            else
            {
                _eventAggregator.Publish(new ErrorMessage((int)result));
            }
        }
    }
}
