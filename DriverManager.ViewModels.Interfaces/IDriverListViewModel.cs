using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using DriverManager.Models.Interfaces;

namespace DriverManager.ViewModels.Interfaces
{
    public interface IDriverListViewModel : IScreen
    {
        ObservableCollection<IDriver> Drivers { get; set; }

        void Populate();
    }
}
