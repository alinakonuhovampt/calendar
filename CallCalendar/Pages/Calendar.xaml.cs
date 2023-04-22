using CallCalendar.Data;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CallCalendar
{
    /// <summary>
    /// Логика взаимодействия для Calendar.xaml
    /// </summary>
    public partial class Calendar : Page
    {
        public Calendar()
        {
            InitializeComponent();
            datePicker.SelectedDate = DateTime.Now;
        }

        public Calendar(DateOnly date)
        {
            InitializeComponent();
            datePicker.SelectedDate = date.ToDateTime(new TimeOnly());
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            ReBuild();
        }


        private void _SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Resize();
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsLoaded)
                ReBuild();
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            if (datePicker.SelectedDate == null)
                return;

            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddMonths(-1);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (datePicker.SelectedDate == null)
                return;

            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddMonths(1);
        }


        private void Resize()
        {
            foreach (DateSquare square in canvas.Children.OfType<DateSquare>())
                square.Margin = new Thickness(10 + ((square.Day - 1) % ((int)(canvas.RenderSize.Width) / 80)) * 80, 10 + ((square.Day - 1) / ((int)canvas.RenderSize.Width / 80)) * 80, 10, 10);
        }

        private void ReBuild()
        {
            canvas.Children.Clear();
            if (datePicker.SelectedDate == null)
                return;

            DateTime selectedDate = datePicker.SelectedDate ?? DateTime.Now;
            DateLabel.Content = selectedDate.ToString("MMMM yyyy");

            for (int i = 1; i <= DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month); i++)
            {
                DateSquare square = new (LoadSaveHelper.LoadUserChoose(new DateOnly(selectedDate.Year, selectedDate.Month, i)))
                {
                    Margin = new Thickness(10 + 80 * (i - 1), 10, 10, 10),
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left
                };

                canvas.Children.Add(square);
            }

            Resize();
        }
    }
}