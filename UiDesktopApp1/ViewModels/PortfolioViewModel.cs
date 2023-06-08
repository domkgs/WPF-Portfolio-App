using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media;
using UiDesktopApp1.Models;
using Wpf.Ui.Common.Interfaces;

namespace UiDesktopApp1.ViewModels
{
    public partial class PortfolioViewModel : ObservableObject, INavigationAware
    {
        [ObservableProperty]
        private int _counter = 0;


        [ObservableProperty]
        private ObservableCollection<Links> _linklist = new();

        public void OnNavigatedTo()
        {

            Linklist = new ObservableCollection<Links>
            {
                new Links()
                {
                    Name = "LinkedIn",
                    Url = "https://www.linkedin.com/in/dominic-khoo-214212191/"
                },

                new Links()
                {
                    Name = "Github",
                    Url = "https://github.com/domkgs"
                }
            };

            ChartData = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Python",
                    Values = new ChartValues<double> { 10 },
                    DataLabels = true,
                    Fill = new SolidColorBrush(Color.FromRgb(0, 120, 215)),
                    Stroke = Brushes.Transparent,
                    Foreground = Brushes.White, // Set the font color
                    FontFamily = new FontFamily("Segoe UI")
                },
                new PieSeries
                {
                    Title = "Java",
                    Values = new ChartValues<double> { 20 },
                    DataLabels = true,
                    Fill = new SolidColorBrush(Color.FromRgb(255, 120, 0)),
                    Stroke = Brushes.Transparent,
                    Foreground = Brushes.White, // Set the font color
                    FontFamily = new FontFamily("Segoe UI")
                },
                // Add more pie series as needed
            };
        }

        public void OnNavigatedFrom()
        {
        }

        [RelayCommand]
        private void OnCounterIncrement()
        {
            Counter++;
        }

        private SeriesCollection _chartData;
        public SeriesCollection ChartData
        {
            get { return _chartData; }
            set
            {
                _chartData = value;
                OnPropertyChanged(); // Implement INotifyPropertyChanged interface or use a base view model class
            }
        }
    }
}
