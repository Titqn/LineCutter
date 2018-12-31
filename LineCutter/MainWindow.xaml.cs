using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using LineCutter.Models;
using LineCutter.ViewModels;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using RadioButton = System.Windows.Controls.RadioButton;

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

        /// <summary>
        /// To have the ViewModel defined in all our code-behind method
        /// </summary>
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

        private void OutputRepertory_OnClick(object sender, RoutedEventArgs e)
        {
            using (var dialog = new FolderBrowserDialog {ShowNewFolderButton = true})
            {
                var result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK ||
                    result == System.Windows.Forms.DialogResult.Yes)
                {
                    ViewModel.OutputDirectory = dialog.SelectedPath;
                }
            }
        }

        private void StandardRadio_OnChecked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioChosen && radioChosen.Tag is ToDoStandardEnum enumChosen)
            {
                ViewModel.ToDoStandardChosen = enumChosen;
                ViewModel.RefreshCanGoStandard();
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