using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Portable.Annotations;

namespace Portable
{
    public class StartPageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ChartData> categoricalChartDataCollection;

        public StartPageViewModel()
        {

        }

        public ObservableCollection<ChartData> CategoricalChartDataCollection
        {
            get { return categoricalChartDataCollection ?? (categoricalChartDataCollection = GenerateChartData()); }
            set { categoricalChartDataCollection = value; OnPropertyChanged(); }
        }

        private ObservableCollection<ChartData> GenerateChartData() => new ObservableCollection<ChartData>()
        {
            new ChartData { Category = "Apples", Value = 510000.25 },
            new ChartData { Category = "Oranges1", Value = 1251000 },
            new ChartData { Category = "Oranges2", Value = 125000 },
            new ChartData { Category = "Oranges3", Value = 1251000 }
        };

        #region INPC

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    public class ChartData
    {
        public string Category { get; set; }
        public double Value { get; set; }
    }
}
