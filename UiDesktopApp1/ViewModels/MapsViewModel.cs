using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media;
using UiDesktopApp1.Models;
using Wpf.Ui.Common.Interfaces;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Windows.Resources;
using System.Windows;

namespace UiDesktopApp1.ViewModels
{
    public partial class MapsViewModel : ObservableObject, INavigationAware
    {
        [ObservableProperty]
        public ObservableCollection<String> _myCollection;

        [ObservableProperty]
        public String _newItemText;

        public MapsViewModel()
        {
            StreamResourceInfo resourceInfo = Application.GetResourceStream(new Uri("/UiDesktopApp1;component/Assets/collection.txt", UriKind.RelativeOrAbsolute));

            // Read the lines from the stream (assuming it's a text file)
            using (StreamReader reader = new StreamReader(resourceInfo.Stream))
            {
                List<string> lines = new List<string>();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }

                // Initialize the ObservableCollection<string> with the lines
                MyCollection = new ObservableCollection<string>(lines);
            }


        }

        public void OnNavigatedTo()
        {
        }

        public void OnNavigatedFrom()
        {
        }

        [RelayCommand]
        private void AddItem()
        {
            MyCollection.Add(NewItemText);
            NewItemText = string.Empty; // Clear the text box after adding the item
        }
    }
}
