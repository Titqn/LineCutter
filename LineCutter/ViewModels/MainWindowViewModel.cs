using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using LineCutter.Annotations;
using LineCutter.Models;

namespace LineCutter.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindowViewModel()
        {
            FilePath = "Choose a file to process";
            OutputDirectory = "Choose an output folder";
        }

        public ToDoStandardEnum ToDoStandardChosen { get; set; }
        public ToDoComplexEnum ToDoComplexChosen { get; set; }

        private int _numberOfLinesStandard;

        public int NumberOfLinesStandard
        {
            get => _numberOfLinesStandard;
            set
            {
                //We obviously don't want to trigger OnPropertyChanged if the value is the same as before
                if (value == _numberOfLinesStandard) return;
                _numberOfLinesStandard = value;
                OnPropertyChanged(nameof(NumberOfLinesStandard));
            }
        }

        private string _filePath;

        /// <summary>
        /// FilePath of the input file chosen
        /// </summary>
        public string FilePath
        {
            get => _filePath;
            set
            {
                //We obviously don't want to trigger OnPropertyChanged if the value is the same as before
                if (value == _filePath) return;
                _filePath = value;
                OnPropertyChanged(nameof(FilePath));
            }
        }

        private string _outputDirectory;

        /// <summary>
        /// Path of the output directory chosen
        /// </summary>
        public string OutputDirectory
        {
            get => _outputDirectory;
            set
            {
                if (value == _outputDirectory) return;
                _outputDirectory = value;
                OnPropertyChanged(nameof(OutputDirectory));
            }
        }

        /// <summary>
        /// Start the real process (Get-Content powershell)
        /// </summary>
        /// <param name="isStandardMode">Define if we want to launch the standard mode or the complex mode</param>
        public async Task Start(bool isStandardMode = true)
        {
            throw new System.NotImplementedException();
        }
    }
}