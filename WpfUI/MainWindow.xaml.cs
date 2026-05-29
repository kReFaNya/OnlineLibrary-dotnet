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
using Core;
using System.Collections.ObjectModel;

namespace WpfUI
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Book> Books { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Books = new ObservableCollection<Book>();

            InitializeData();

            DataContext = this;
        }

        private void InitializeData()
        {
            Books.Add(new Book(1, "The Witcher", 320, 9.4, new DateTime(2015, 5, 19), true, "Fantasy"));
            Books.Add(new Book(2, "Dune", 500, 9.7, new DateTime(1976, 8, 1), false, "Science Fiction"));
            Books.Add(new Book(3, "The Hobbit", 310, 9.5, new DateTime(1967, 9, 21), true, "Fantasy"));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            BookDialog dialog = new BookDialog();

            if (dialog.ShowDialog() == true)
            {
                Books.Add(dialog.Book);
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Book selectedBook = BooksDataGrid.SelectedItem as Book;

            if (selectedBook == null)
            {
                MessageBox.Show("Виберіть книгу для редагування.");
                return;
            }

            BookDialog dialog = new BookDialog(selectedBook);

            if (dialog.ShowDialog() == true)
            {
                selectedBook.Id = dialog.Book.Id;
                selectedBook.Title = dialog.Book.Title;
                selectedBook.Pages = dialog.Book.Pages;
                selectedBook.Rating = dialog.Book.Rating;
                selectedBook.ReleaseDate = dialog.Book.ReleaseDate;
                selectedBook.IsAvailable = dialog.Book.IsAvailable;
                selectedBook.Category = dialog.Book.Category;

                BooksDataGrid.Items.Refresh();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Book selectedBook = BooksDataGrid.SelectedItem as Book;

            if (selectedBook == null)
            {
                MessageBox.Show("Виберіть книгу для видалення.");
                return;
            }

            MessageBoxResult result = MessageBox.Show(
                "Ви дійсно хочете видалити книгу?",
                "Підтвердження",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Books.Remove(selectedBook);
            }
        }
    }
}
