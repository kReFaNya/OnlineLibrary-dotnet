using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using WpfUI.Commands;

namespace WpfUI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Book selectedBook;
        private readonly BookFileService fileService;
        private readonly string jsonPath = "wpf_books.json";

        public ObservableCollection<Book> Books { get; set; }

        public Book SelectedBook
        {
            get
            {
                return selectedBook;
            }
            set
            {
                selectedBook = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand LoadCommand { get; private set; }

        public MainViewModel()
        {
            fileService = new BookFileService();
            Books = new ObservableCollection<Book>();

            InitializeData();

            AddCommand = new RelayCommand(AddBook);
            EditCommand = new RelayCommand(EditBook, CanEditOrDelete);
            DeleteCommand = new RelayCommand(DeleteBook, CanEditOrDelete);
            SaveCommand = new RelayCommand(SaveBooks);
            LoadCommand = new RelayCommand(LoadBooks);
        }

        private void InitializeData()
        {
            Books.Add(new Book(1, "The Witcher", 320, 9.4, new DateTime(2015, 5, 19), true, "Fantasy"));
            Books.Add(new Book(2, "Dune", 500, 9.7, new DateTime(1976, 8, 1), false, "Science Fiction"));
            Books.Add(new Book(3, "The Hobbit", 310, 9.5, new DateTime(1967, 9, 21), true, "Fantasy"));
        }

        private void AddBook(object parameter)
        {
            BookDialog dialog = new BookDialog();

            if (dialog.ShowDialog() == true)
            {
                Books.Add(dialog.Book);
            }
        }

        private void EditBook(object parameter)
        {
            if (SelectedBook == null)
            {
                MessageBox.Show("Виберіть книгу для редагування.");
                return;
            }

            BookDialog dialog = new BookDialog(SelectedBook);

            if (dialog.ShowDialog() == true)
            {
                SelectedBook.Id = dialog.Book.Id;
                SelectedBook.Title = dialog.Book.Title;
                SelectedBook.Pages = dialog.Book.Pages;
                SelectedBook.Rating = dialog.Book.Rating;
                SelectedBook.ReleaseDate = dialog.Book.ReleaseDate;
                SelectedBook.IsAvailable = dialog.Book.IsAvailable;
                SelectedBook.Category = dialog.Book.Category;

                OnPropertyChanged("Books");
            }
        }

        private void DeleteBook(object parameter)
        {
            if (SelectedBook == null)
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
                Books.Remove(SelectedBook);
            }
        }

        private bool CanEditOrDelete(object parameter)
        {
            return SelectedBook != null;
        }

        private void SaveBooks(object parameter)
        {
            fileService.SaveToJson(new System.Collections.Generic.List<Book>(Books), jsonPath);
            MessageBox.Show("Дані збережено у файл " + jsonPath);
        }

        private void LoadBooks(object parameter)
        {
            var loadedBooks = fileService.LoadFromJson(jsonPath);

            Books.Clear();

            foreach (Book book in loadedBooks)
            {
                Books.Add(book);
            }

            MessageBox.Show("Дані завантажено з файлу " + jsonPath);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
