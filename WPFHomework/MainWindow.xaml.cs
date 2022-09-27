using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace WPFHomework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _seconds;
        private int _num;
        public MainWindow()
        {
            InitializeComponent();
            SimpleTextBox.Text = _num.ToString();
        }
        public void Foo()
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background,
            new Action(() =>
            {
                Thread.Sleep(_seconds);
                SimpleTextBox.Text += _num++ + " ";                
            }));
        }

        private void SecondsSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _seconds = (int)SecondsSlider.Value * 1000;
            Thread f = new Thread(Foo);
            f.Start();
        }
    }
}
