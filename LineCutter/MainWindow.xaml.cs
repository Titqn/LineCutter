using System;
using System.Diagnostics;
using System.Windows;
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
    }
}