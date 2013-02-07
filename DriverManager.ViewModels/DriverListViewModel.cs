using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using DriverManager.Models.Interfaces;
using DriverManager.ViewModels.Interfaces;

namespace DriverManager.ViewModels
{
    public class DriverListViewModel : Screen, IDriverListViewModel
    {
        private ObservableCollection<IDriver> _drivers;

        public ObservableCollection<IDriver> Drivers
        {
            get { return _drivers; }
            set
            {
                _drivers = value;
                NotifyOfPropertyChange(() => Drivers);
            }
        }
        
        private IDriverModel _model;
        private Func<IDriver> _createDriver;
        public DriverListViewModel(Func<IDriver> createDriver, IDriverModel model)
        {
            _createDriver = createDriver;
            _model = model;
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            Populate();
        }

        public void Populate()
        {
            Drivers = new ObservableCollection<IDriver>(_model.GetAllDrivers());
        }

        public void DriverSelected(IDriver sender)
        {
            IDriver driver = _createDriver();
            driver.FirstName = sender.FirstName;

        }
    }
}
