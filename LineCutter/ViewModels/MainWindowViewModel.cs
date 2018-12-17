using System.ComponentModel;
using System.Runtime.CompilerServices;
using LineCutter.Annotations;

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
            FilePath = "Pick a file to cut";
        }

        private string _filePath;
        /// <summary>
        /// FilePath of the input file
        /// </summary>
        public string FilePath
        {
            get => _filePath;
            set
            {
                if (value == _filePath) return;
                _filePath = value;
                OnPropertyChanged(nameof(FilePath));
            }
        }
    }
}