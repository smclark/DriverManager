using System;
using Caliburn.Micro;
using DriverManager.Models;
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

        private IDriverModel _model;
        private IEventAggregator _eventAggregator;

        public AddDriverViewModel(IDriverModel model, IEventAggregator eventAggregator)
        {
            if (model == null)
                throw new ArgumentNullException("model");
            _model = model;

            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }

        public void Save()
        {
            var driver = new Driver();
            driver.FirstName = FirstName;
            driver.LastName = LastName;
            //driver.AddressInfo = new Address();
            //driver.VehicleInfo = new Vehicle();

            int result = _model.CreateDriver(driver);

            if(result != -1)//No error occurred
            {
                _eventAggregator.Publish(new DriverCreatedMessage(driver.FullName));
            }
            else
            {
                _eventAggregator.Publish(new ErrorMessage(result));
            }
        }
    }
}
