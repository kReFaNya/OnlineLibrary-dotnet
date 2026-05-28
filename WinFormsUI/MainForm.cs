using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;

namespace WinFormsUI
{
    public partial class MainForm : Form
    {
        private List<Book> books;
        private BindingSource bindingSource;
        private BookFileService fileService;

        public MainForm()
        {
            InitializeComponent();

            books = new List<Book>();
            bindingSource = new BindingSource();
            fileService = new BookFileService();

            InitializeData();
            UpdateGrid();
        }

        private void InitializeData()
        {
            books.Add(new Book(1, "The Witcher", 320, 9.4, new DateTime(2015, 5, 19), true, "Fantasy"));
            books.Add(new Book(2, "Dune", 500, 9.7, new DateTime(1976, 8, 1), false, "Science Fiction"));
            books.Add(new Book(3, "The Hobbit", 310, 9.5, new DateTime(1967, 9, 21), true, "Fantasy"));
        }

        private void UpdateGrid()
        {
            bindingSource.DataSource = null;
            bindingSource.DataSource = books;

            dataGridViewBooks.DataSource = bindingSource;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BookForm bookForm = new BookForm();

            if (bookForm.ShowDialog() == DialogResult.OK)
            {
                books.Add(bookForm.Book);
                UpdateGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.CurrentRow == null)
            {
                MessageBox.Show("Виберіть книгу для видалення.");
                return;
            }

            Book selectedBook = dataGridViewBooks.CurrentRow.DataBoundItem as Book;

            if (selectedBook == null)
            {
                MessageBox.Show("Помилка вибору книги.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Ви дійсно хочете видалити книгу?",
                "Підтвердження",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                books.Remove(selectedBook);
                UpdateGrid();
            }
        }

        private void btnSaveJson_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "JSON files (*.json)|*.json";
            dialog.FileName = "books.json";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fileService.SaveToJson(books, dialog.FileName);
                MessageBox.Show("Дані збережено у JSON.");
            }
        }

        private void btnLoadJson_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JSON files (*.json)|*.json";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                books = fileService.LoadFromJson(dialog.FileName);
                UpdateGrid();
                MessageBox.Show("Дані завантажено з JSON.");
            }
        }

        private void btnExportXml_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "XML files (*.xml)|*.xml";
            dialog.FileName = "available_books.xml";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fileService.ExportAvailableBooksToXml(books, dialog.FileName);
                MessageBox.Show("Дані експортовано у XML.");
            }
        }
    }
}
