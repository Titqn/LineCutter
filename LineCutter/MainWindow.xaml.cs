using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LineCutter.Models;
using LineCutter.ViewModels;
using Microsoft.Win32;

namespace LineCutter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private MainWindowViewModel ViewModel { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            if (ViewModel == null && DataContext is MainWindowViewModel contextCasted)
            {
                ViewModel = contextCasted;
            }
        }

        private void SelectFile_OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                DefaultExt = ".csv"
            };
            var result = dialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                var fileName = dialog.FileName;
                ViewModel.FilePath = fileName;
            }
        }

        private void StandardRadio_OnChecked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioChosen && radioChosen.Tag is ToDoStandardEnum enumChosen)
            {
                ViewModel.ToDoStandardChosen = enumChosen;
            }
        }

        private void ComplexRadio_OnChecked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioChosen && radioChosen.Tag is ToDoComplexEnum enumChosen)
            {
                ViewModel.ToDoComplexChosen = enumChosen;
            }
        }

        private void ForceNumberInput_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void GoStandard_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.Start();
        }
    }
}