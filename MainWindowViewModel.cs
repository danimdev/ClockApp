using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClockApp
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            StartClockAsync();
        }

        bool isRunning = true;

        DateTime datetime;

        public event PropertyChangedEventHandler? PropertyChanged;

        public DateTime DateTime
        {
            get => datetime;
            set
            {
                datetime = value;
                OnPropertyChanged(nameof(DateTime));
            }
        }

        async void StartClockAsync()
        {
            while (isRunning)
            {
                DateTime = DateTime.Now;
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if(!string.IsNullOrEmpty(propertyName))
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
