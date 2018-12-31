using System;
using System.ComponentModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using LineCutter.Annotations;
using LineCutter.Models;

namespace LineCutter.ViewModels
{
    public sealed class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private const string _defaultValueOutputDirectory = "Choose an output folder";
        private const string _defaultValueFilePath = "Choose a file to process";

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindowViewModel()
        {
            FilePath        = _defaultValueFilePath;
            OutputDirectory = _defaultValueOutputDirectory;
        }

        public ToDoStandardEnum ToDoStandardChosen { get; set; }
        public ToDoComplexEnum ToDoComplexChosen { get; set; }

        public bool CanLaunchStandard => ToDoStandardChosen > 0
                                         && OutputDirectory != _defaultValueOutputDirectory
                                         && FilePath != _defaultValueFilePath
                                         && NumberOfLinesStandard > 0;

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
                RefreshCanGoStandard();
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
                RefreshCanGoStandard();
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
                RefreshCanGoStandard();
            }
        }

        /// <summary>
        /// Trigger manually the <see cref="PropertyChanged"/> event on <see cref="CanLaunchStandard"/>
        /// </summary>
        public void RefreshCanGoStandard()
        {
            OnPropertyChanged(nameof(CanLaunchStandard));
        }

        /// <summary>
        /// Start the real process (Get-Content powershell)
        /// </summary>
        /// <param name="isStandardMode">Define if we want to launch the standard mode or the complex mode</param>
        public async Task Start(bool isStandardMode = true)
        {
            if (CanLaunchStandard)
            {
                //ToDo : To develop
//                using (var psInstance = PowerShell.Create())
//                {
//                    var command = new PSCommand();
//                    command.AddCommand("Get-Content").AddParameter("Path", FilePath);
//                    switch (ToDoStandardChosen)
//                    {
//                        case ToDoStandardEnum.TakeFirstNLines:
//                            command.AddParameter("first", NumberOfLinesStandard);
//                            break;
//                    }
//                    
//                    psInstance.Commands = command;
//                }
            }
        }
    }
}