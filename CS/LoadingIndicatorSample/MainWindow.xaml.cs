using DevExpress.Mvvm;
using System;
using System.Windows;
using System.Windows.Threading;

namespace LoadingIndicatorSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
    }

    public class LoadingScreenViewModel : ViewModelBase {
        public int Progress { get { return GetProperty(() => Progress); } set { SetProperty(() => Progress, value); } }
        public LoadingScreenViewModel() {
            DispatcherTimer tmr = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(0.5) };
            tmr.Tick += OnTick;
            tmr.Start();
        }
        void OnTick(object sender, EventArgs e) {
            Progress++;
            if(Progress >= 100) {
                Progress = 0;
            }
        }
    }
}
