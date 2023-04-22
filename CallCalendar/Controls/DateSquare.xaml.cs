using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace CallCalendar
{
    public partial class DateSquare : UserControl
    {
        public UserChoose choose;
        public int Day => choose.date.Day;
        private string image = "/icons/phone.png";
        public DateSquare(UserChoose choose)
        {
            InitializeComponent();

            this.choose = choose;
            label.Content = Day.ToString();

            image = "/icons/phone.png";
            if (choose.items.Count > 0)
                image = $"/icons/{choose.items[0]}.png";

            picture.Source = new BitmapImage(new Uri(image, UriKind.Relative)); ;
        }

        private void Click(object sender, MouseButtonEventArgs e)
        {
            MainWindow window = (MainWindow)App.Current.MainWindow;
            window.Frame.Content = new ListPage(choose);
        }
    }
}