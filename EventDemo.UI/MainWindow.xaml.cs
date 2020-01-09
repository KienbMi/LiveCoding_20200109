using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EventDemo.Logic;

namespace EventDemo.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FastClock _fastClock;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnInitialized(object sender, EventArgs e)
        {
            _fastClock = new FastClock(DateTime.Now);
            _fastClock.OneMinuteIsOver += FastClockOneMinuteIsOver;
            
        }

        private void FastClockOneMinuteIsOver(object sender, DateTime e)
        {
            txtTime.Text = $"Aktuelle Zeit: {e.ToShortTimeString()}";
        }

        private void ChkIsRunning_Click(object sender, RoutedEventArgs e)
        {
            _fastClock.IsRunning = chkIsRunning.IsChecked == true;
        }
    }
}
