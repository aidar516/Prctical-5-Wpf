using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace CalendarApp
{
    public partial class ButtonControl : UserControl
    {
        public event RoutedEventHandler Clicked;
        public ButtonControl()
        {
            InitializeComponent();
        }

        private void DayBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Clicked != null)
            {
                Clicked.Invoke(sender, e);
            }
        }
    }
}
