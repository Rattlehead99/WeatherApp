using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherApp.ViewModel.Commands
{
    public class SearchCommand : ICommand
    {
        public WeatherViewModel WeatherVm { get; set; }

        public SearchCommand(WeatherViewModel vm)
        {
            WeatherVm = vm;
        }
        public bool CanExecute(object? parameter)
        {
            if (string.IsNullOrWhiteSpace(parameter as string))
            {
                return false;
            }

            return true;
        }

        public void Execute(object? parameter)
        {
            WeatherVm.MakeQuery();
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
