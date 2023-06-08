using LiveCharts.Definitions.Charts;
using LiveCharts.Wpf;
using System.Windows.Media;
using Wpf.Ui.Common.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;

namespace UiDesktopApp1.Views.Pages
{
    /// <summary>
    /// Interaction logic for DashboardPage.xaml
    /// </summary>
    public partial class MapsPage : INavigableView<ViewModels.MapsViewModel>
    {
        public ViewModels.MapsViewModel ViewModel
        {
            get;
        }

        public MapsPage(ViewModels.MapsViewModel viewModel)
        {
            ViewModel = viewModel;
 
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var apiResponse = await MakeApiRequest();

            if (apiResponse != null)
            {
                ResultTextBlock.Text = apiResponse;
            }
            else
            {
                ResultTextBlock.Text = "Error occurred during API request.";
            }
        }

        private async Task<string> MakeApiRequest()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://the-fork-the-spoon.p.rapidapi.com/locations/v2/auto-complete?text=milan"),
                Headers =
        {
            { "X-RapidAPI-Key", "5a1ba5019dmshafff6220fb19ac5p14e5fdjsna7f2289730c6" },
            { "X-RapidAPI-Host", "the-fork-the-spoon.p.rapidapi.com" },
        },
            };

            try
            {
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    return body;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
    }
}