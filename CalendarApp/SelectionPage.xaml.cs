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

namespace CalendarApp
{
    /// <summary>
    /// Логика взаимодействия для SelectionPage.xaml
    /// </summary>
    public partial class SelectionPage : Page
    {
        public SelectionPage()
        {
            InitializeComponent();
            SelectionItems();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void SaveExitBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveData();
            NavigationService.Navigate(new MainPage());
        }

        private void SelectionItems()
        {
            SelectionItem salat = new SelectionItem();
            salat.name = "Cалат";
            var uri1 = new Uri("C:\\Users\\valiu\\source\\repos\\C#\\CalendarApp\\CalendarApp\\Burger.png");
            var uri2 = new Uri("C:\\Users\\valiu\\source\\repos\\C#\\CalendarApp\\CalendarApp\\salat.png");
            var uri3 = new Uri("C:\\Users\\valiu\\source\\repos\\C#\\CalendarApp\\CalendarApp\\bread.png");
            var uri4 = new Uri("C:\\Users\\valiu\\source\\repos\\C#\\CalendarApp\\CalendarApp\\candy.png");
            var uri5 = new Uri("C:\\Users\\valiu\\source\\repos\\C#\\CalendarApp\\CalendarApp\\sup.png");
            var uri6 = new Uri("C:\\Users\\valiu\\source\\repos\\C#\\CalendarApp\\CalendarApp\\meat.png");
            SelectionItemControl first = new SelectionItemControl();
            SelectionItemControl second = new SelectionItemControl();
            SelectionItemControl third = new SelectionItemControl();
            SelectionItemControl forth = new SelectionItemControl();
            SelectionItemControl fifth = new SelectionItemControl();
            SelectionItemControl sixth = new SelectionItemControl();
            first.TextBlock.Text = "Фастфуд";
            first.img.Source = new BitmapImage(uri1);
            second.TextBlock.Text = salat.name;
            second.img.Source = new BitmapImage(uri2);
            third.TextBlock.Text = "Хлеб";
            third.img.Source = new BitmapImage(uri3);
            forth.TextBlock.Text = "Сладкое";
            forth.img.Source = new BitmapImage(uri4);
            fifth.TextBlock.Text = "Суп";
            fifth.img.Source = new BitmapImage(uri5);
            sixth.TextBlock.Text = "Мясо"; 
            sixth.img.Source = new BitmapImage(uri6);

            List<SelectionItemControl> items = new List<SelectionItemControl>() { first, second, third, forth, fifth, sixth };
            ListBox.ItemsSource = items;
        }

        private void LoadDate()
        {
            SelectionUser selection = Serializer.Deserialize<SelectionUser>("data.xml");
        }

        private void SaveData()
        {
            SelectionUser selection = new SelectionUser { Date = DateTime.Now, SelectedItems = new List<SelectionItem>() };
            Serializer.Serialize("data.xml", selection);
        }
    }
}
