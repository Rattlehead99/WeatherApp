using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WeatherApp.Model;
using WeatherApp.ViewModel.Commands;
using WeatherApp.ViewModel.Helpers;

namespace WeatherApp.ViewModel
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        private string _query;
        private WeatherConditions _currentConditions;
        private City _selectedCity;

        public WeatherViewModel()
        {
            //T79. Using Design Mode Bindings
            //Testing if the binding is working
            
            //Set the property values when the program isn't working:
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                SelectedCity = new City()
                {
                    LocalizedName = "Azbadjuk"
                };
                CurrentConditions = new WeatherConditions()
                {
                    WeatherText = "Sunny",
                    Temperature = new Temperature()
                    {
                        Metric = new Units()
                        {
                            Value = 21
                        }
                    }
                };
            }

            SearchCommand = new SearchCommand(this);
            CurrentConditionsCommand = new GetCurrentConditionsCommand(this);
            Cities = new ObservableCollection<City>();
        }

        public SearchCommand SearchCommand { get; set; }

        public GetCurrentConditionsCommand CurrentConditionsCommand { get; set; }

        public string Query
        {
            get => _query;
            set
            {
                if (value == _query) return;
                _query = value;
                OnPropertyChanged(nameof(Query));
            }
        }

        public WeatherConditions CurrentConditions
        {
            get => _currentConditions;
            set
            {
                if (Equals(value, _currentConditions)) return;
                _currentConditions = value;
                OnPropertyChanged(nameof(CurrentConditions));
            }
        }

        public City SelectedCity
        {
            get => _selectedCity;
            set
            {
                if (Equals(value, _selectedCity)) return;
                _selectedCity = value;
                OnPropertyChanged(nameof(SelectedCity));
                GetCurrentConditions();
            }
        }

        public ObservableCollection<City> Cities { get; set; }

        public async void GetCurrentConditions()
        {
            Query = "";
            Cities.Clear();
            if (SelectedCity != null)
            {
                CurrentConditions = await AcuWeatherHelper.GetWeatherConditions(SelectedCity.Key);
            }
        }

        public async Task MakeQuery()
        {
            List<City>? cities = await AcuWeatherHelper.GetCities(Query);

            Cities.Clear();
            cities.ForEach(city => Cities.Add(city));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
