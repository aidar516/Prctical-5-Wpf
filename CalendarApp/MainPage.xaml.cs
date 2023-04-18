using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents.Serialization;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace CalendarApp
{
    public partial class MainPage : Page
    {
        public DateTime picker;
        public MainPage()
        {
            InitializeComponent();
            DatePicker.SelectedDate = DateTime.Now;
            buttonBlock();
        }
        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            DatePicker.SelectedDate = ((DateTime)DatePicker.SelectedDate).AddMonths(1);
        }

        private void PrevBtn_Click(object sender, RoutedEventArgs e)
        {
            DatePicker.SelectedDate = ((DateTime)DatePicker.SelectedDate).AddMonths(-1);
        }

        private void SecondPageBtn_Click(object sender, RoutedEventArgs e)
        {
            int datePic;
            datePic = Convert.ToInt32(((Button)sender).Name.Split('B')[1]);
            DateTime date = (DateTime)DatePicker.SelectedDate;
            DatePicker.SelectedDate = new DateTime(date.Year, date.Month, datePic, date.Hour, date.Minute, date.Second, date.Millisecond);
            NavigationService.Navigate(new SelectionPage());
        }

        private void buttonBlock()
        {
            var uri = new Uri("C:\\Users\\valiu\\source\\repos\\C#\\CalendarApp\\CalendarApp\\iconBtn.png");
            MainContent.Children.Clear();
            for (int i = 1; i <= DateTime.DaysInMonth(((DateTime)DatePicker.SelectedDate).Year, ((DateTime)DatePicker.SelectedDate).Month); i++)
            {
                ButtonControl button = new ButtonControl();
                button.DayBtn.Click += SecondPageBtn_Click;
                button.Margin = new Thickness(5);
                button.Width = 100;
                button.Height = 100;
                button.TextBlock.Text = i.ToString();
                button.DayBtn.Name ='B'+i.ToString();
                button.IMG.Source = new BitmapImage(uri);
                MainContent.Children.Add(button);
            }
        }

        private void DtPc(object sender, SelectionChangedEventArgs e)
        {
            buttonBlock();
        }
    }
}
