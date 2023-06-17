using Wpf.Ui.Common.Interfaces;

namespace UiDesktopApp1.Views.Pages
{
    /// <summary>
    /// Interaction logic for DashboardPage.xaml
    /// </summary>
    public partial class WeatherPage : INavigableView<ViewModels.WeatherViewModel>
    {
        public ViewModels.WeatherViewModel ViewModel
        {
            get;
        }

        public WeatherPage(ViewModels.WeatherViewModel viewModel)
        {
            ViewModel = viewModel;

            InitializeComponent();
        }
    }
}