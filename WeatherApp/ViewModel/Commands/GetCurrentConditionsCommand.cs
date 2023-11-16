using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherApp.ViewModel.Commands
{

    public class GetCurrentConditionsCommand : ICommand
    {
        public WeatherViewModel WeatherVm { get; set; }

        public GetCurrentConditionsCommand(WeatherViewModel vm)
        {
            WeatherVm = vm;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            await WeatherVm.LoadCurrentConditions();
        }

        public event EventHandler? CanExecuteChanged;
    }
}
