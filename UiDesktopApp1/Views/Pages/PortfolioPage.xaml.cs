using LiveCharts.Definitions.Charts;
using LiveCharts.Wpf;
using System.Windows.Media;
using Wpf.Ui.Common.Interfaces;

namespace UiDesktopApp1.Views.Pages
{
    /// <summary>
    /// Interaction logic for DashboardPage.xaml
    /// </summary>
    public partial class PortfolioPage : INavigableView<ViewModels.PortfolioViewModel>
    {
        public ViewModels.PortfolioViewModel ViewModel
        {
            get;
        }

        public PortfolioPage(ViewModels.PortfolioViewModel viewModel)
        {
            ViewModel = viewModel;

            InitializeComponent();
        }


        private void Card_PreviewDrop(object sender, System.Windows.DragEventArgs e)
        {

        }
    }
}