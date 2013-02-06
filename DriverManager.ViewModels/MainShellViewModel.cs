using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using DriverManager.Models.Interfaces.Messages;
using DriverManager.ViewModels.Interfaces;

namespace DriverManager.ViewModels
{
    public class MainShellViewModel : Conductor<IScreen>.Collection.OneActive, IMainShellViewModel, IHandle<IDriverCreatedMessage>, IHandle<IErrorMessage>
    {
        private const string DarkGreen = "DarkGreen";
        private const string DarkRed = "DarkRed";

        private string _outputText;
        private string _outputTextColour;

        public string OutputText
        {
            get { return _outputText; }
            set
            {
                _outputText = value;
                NotifyOfPropertyChange(() => OutputText);
            }
        }

        public string OutputTextColour
        {
            get { return _outputTextColour; }
            set
            {
                _outputTextColour = value;
                NotifyOfPropertyChange(() => OutputTextColour);
            }
        }

        private IEventAggregator _eventAggregator;
        private IAddDriverViewModel _addDriverViewModel;
        private IDriverListViewModel _driverListViewModel;

        public MainShellViewModel(IDriverListViewModel driverListViewModel, IAddDriverViewModel addDriverViewModel, IEventAggregator eventAggregator)
        {
            _driverListViewModel = driverListViewModel;
            _addDriverViewModel = addDriverViewModel;
            _eventAggregator = eventAggregator;

            ActiveItem = _driverListViewModel;
        }

        public void List()
        {
            ActiveItem = IoC.Get<IDriverListViewModel>();
        }

        public void Create()
        {
            ActiveItem = IoC.Get<IAddDriverViewModel>();
        }

        public void Handle(IDriverCreatedMessage message)
        {
            _outputTextColour = DarkGreen;
            _outputText = string.Format("Driver {0} was created", message.Name);
        }

        public void Handle(IErrorMessage message)
        {
            _outputTextColour = DarkRed;
            _outputText = string.Format("Error : Code {0} ", message.ErrorCode);
        }
    }
}
