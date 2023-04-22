using CallCalendar.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CallCalendar
{
    /// <summary>
    /// Логика взаимодействия для ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {
        public UserChoose choose;
        public ListPage(UserChoose choose)
        {
            InitializeComponent();

            this.choose = choose;
            foreach(string option in UserChoose.options)
            {
                listBox.Items.Add(new ChooseItem(option, choose.items.Contains(option)));
            }

            DateLabel.Content = choose.date.ToString("d MMMM yyyy");
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            choose.items.Clear();

            foreach (ChooseItem item in listBox.Items.OfType<ChooseItem>())
                if (item.isOn)
                    choose.items.Add(item.name);

            LoadSaveHelper.SaveUserChoose(choose);

            Exit();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Exit();
        }

        private void Exit()
        {
            MainWindow window = (MainWindow)App.Current.MainWindow;
            window.Frame.Content = new Calendar(choose.date);
        }
    }
}