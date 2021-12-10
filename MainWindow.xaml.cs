using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace OrderDate
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        
        

        private void currentDate_Click(object sender, RoutedEventArgs e)
        {
            
            order.Text = DateTime.Now.ToString();
        }

        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            var ParseDate = DateTime.Parse(order.Text);

            if(ParseDate.DayOfWeek == DayOfWeek.Saturday)
            {
                output.Text = "Sending in Monday at 8:00";
                var hourofday = ParseDate.Hour;
                var minuteofday = ParseDate.Minute;
                var secofday = ParseDate.Second;

                DateTime sending = new DateTime();
                TimeSpan timeSpan = new TimeSpan((-hourofday + 104), -minuteofday, -secofday);
                sending = ParseDate.Add(timeSpan);

                output.Text += "\n\nDelivery date: " + sending;
            }
            else if(ParseDate.DayOfWeek == DayOfWeek.Sunday)
            {
                output.Text = "Sending in Monday at 8:00";
                var hourofday = ParseDate.Hour;
                var minuteofday = ParseDate.Minute;
                var secofday = ParseDate.Second;

                DateTime sending = new DateTime();
                TimeSpan timeSpan = new TimeSpan((-hourofday + 80), -minuteofday, -secofday);
                sending = ParseDate.Add(timeSpan);

                output.Text += "\n\nDelivery date: " + sending;
            }
            else if (ParseDate.Hour >= 17  && ParseDate.DayOfWeek != DayOfWeek.Saturday && ParseDate.DayOfWeek != DayOfWeek.Sunday)
            {
                output.Text = "Sending tomorrow at 8:00";
                var hourofday = ParseDate.Hour;
                var minuteofday = ParseDate.Minute;
                var secofday = ParseDate.Second;
                DateTime sending = new DateTime();
                TimeSpan timeSpan = new TimeSpan((-hourofday + 80), -minuteofday, -secofday);
                sending = ParseDate.Add(timeSpan);

                output.Text += "\n\nDelivery date: " + sending;
            }
            else if (ParseDate.Hour < 8 && ParseDate.DayOfWeek != DayOfWeek.Saturday && ParseDate.DayOfWeek != DayOfWeek.Sunday)
            {
                output.Text = "Sending today at 8:00";
                var hourofday = ParseDate.Hour;
                var minuteofday = ParseDate.Minute;
                var secofday = ParseDate.Second;
                DateTime sending = new DateTime();
                TimeSpan timeSpan = new TimeSpan((-hourofday + 56), -minuteofday, -secofday);
                sending = ParseDate.Add(timeSpan);

                output.Text += "\n\nDelivery date: " + sending;
            }
            else
            {
                
                TimeSpan timeSpan = new TimeSpan(48, 0, 0);
                DateTime end = ParseDate.Add(timeSpan);
                output.Text = "Sending now\nDelivery date: " + end.ToString();
            }

            
        }

        
    }
}
