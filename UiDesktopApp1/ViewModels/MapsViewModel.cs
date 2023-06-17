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
            string filePath = "C:\\Users\\domin\\source\\repos\\UiDesktopApp1\\UiDesktopApp1\\Assets\\collection.txt";

            // Read the lines from the file
            List<string> lines = new List<string>();

            foreach (string line in File.ReadLines(filePath))
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    lines.Add(line);
                }
            }

            // Initialize the ObservableCollection<string> with the lines
            MyCollection = new ObservableCollection<string>(lines);

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
            if(!string.IsNullOrWhiteSpace(NewItemText)) { MyCollection.Add(NewItemText); }
            
            NewItemText = string.Empty; // Clear the text box after adding the item
        }

        [RelayCommand]
        private void RemoveItem(object parameter) 
        {
            string? itemToDelete = parameter as string;
            if (itemToDelete != null)
            {
                MyCollection.Remove(itemToDelete);
            }
        }


        public void SaveCollectionToFile()
        {
            string filePath = "C:\\Users\\domin\\source\\repos\\UiDesktopApp1\\UiDesktopApp1\\Assets\\collection.txt";

            // Open the text file in write mode, which will overwrite the existing contents
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                // Save each entry of the collection to the text file
                foreach (string item in MyCollection)
                {
                    writer.WriteLine(item);
                }
            }
        }

    }
}
