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
    public partial class BookForm : Form
    {
        public Book Book { get; private set; }

        public BookForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Введіть назву книги.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                MessageBox.Show("Введіть категорію книги.");
                return;
            }

            Book = new Book(
                (int)numId.Value,
                txtTitle.Text,
                (int)numPages.Value,
                (double)numRating.Value,
                dateRelease.Value,
                chkAvailable.Checked,
                txtCategory.Text
            );

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
