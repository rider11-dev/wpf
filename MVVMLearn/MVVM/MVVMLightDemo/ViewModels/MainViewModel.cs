using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMLightDemo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string title;

        public string Title
        {
            get { return title; }
            set { Set(ref title, value); }
        }

        public ICommand ChangeTitleCommand { get; set; }

        public MainViewModel()
        {
            Title = "hello";
            ChangeTitleCommand = new RelayCommand(ChangeTitle);
        }

        private void ChangeTitle()
        {
            Title = "hello MvvmLight";
        }

        public override void Cleanup()
        {
            base.Cleanup();
        }
    }
}
