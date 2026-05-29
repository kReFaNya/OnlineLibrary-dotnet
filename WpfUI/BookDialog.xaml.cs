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
using System.Windows.Shapes;
using Core;
using System.Globalization;

namespace WpfUI
{
    public partial class BookDialog : Window
    {
        public Book Book { get; private set; }

        public BookDialog()
        {
            InitializeComponent();
            DateRelease.SelectedDate = DateTime.Now;
        }

        public BookDialog(Book book)
        {
            InitializeComponent();

            TxtId.Text = book.Id.ToString();
            TxtTitle.Text = book.Title;
            TxtPages.Text = book.Pages.ToString();
            TxtRating.Text = book.Rating.ToString(CultureInfo.InvariantCulture);
            DateRelease.SelectedDate = book.ReleaseDate;
            TxtCategory.Text = book.Category;
            ChkAvailable.IsChecked = book.IsAvailable;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int pages;
            double rating;

            if (!int.TryParse(TxtId.Text, out id))
            {
                MessageBox.Show("Некоректний ID.");
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtTitle.Text))
            {
                MessageBox.Show("Введіть назву книги.");
                return;
            }

            if (!int.TryParse(TxtPages.Text, out pages))
            {
                MessageBox.Show("Некоректна кількість сторінок.");
                return;
            }

            if (!double.TryParse(TxtRating.Text.Replace(',', '.'),
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out rating))
            {
                MessageBox.Show("Некоректний рейтинг.");
                return;
            }

            if (DateRelease.SelectedDate == null)
            {
                MessageBox.Show("Виберіть дату.");
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtCategory.Text))
            {
                MessageBox.Show("Введіть категорію.");
                return;
            }

            Book = new Book(
                id,
                TxtTitle.Text,
                pages,
                rating,
                DateRelease.SelectedDate.Value,
                ChkAvailable.IsChecked == true,
                TxtCategory.Text
            );

            DialogResult = true;
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
