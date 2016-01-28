using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using SampleUniversalApp.Models;

namespace SampleUniversalApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private RelayCommand _showMessageCommand;
        public RelayCommand ShowMessageCommand => _showMessageCommand ?? (_showMessageCommand = new RelayCommand(ShowMessage));

        private string _helloWorld;

        public string HelloWorld
        {
            get
            {
                return _helloWorld;
            }
            set
            {
                Set(() => HelloWorld, ref _helloWorld, value);
            }
        }

        public MainViewModel()
        {
            HelloWorld = IsInDesignMode
                ? "Runs in design mode"
                : "Runs in runtime mode";
        }

        private void ShowMessage()
        {
            var msg = new ShowMessageDialog { Message = "Hello World" };
            Messenger.Default.Send<ShowMessageDialog>(msg);
        }
    }
}
