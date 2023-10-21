using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_exer_02
{
    public partial class frmAddProduct : Form
    {
        public frmAddProduct()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] categories = new string[] { "Electronics", "Books", "Clothing", "Food" };

            foreach (string category in categories)
            {
                cbCategory.Items.Add(category);
            }

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string productName = txtProductName.Text;
                int quantity = int.Parse(txtQuantity.Text);
                double price = double.Parse(txtSellPrice.Text);
                string category = cbCategory.SelectedItem.ToString();
                string mfgDate = dtPickerMfgDate.Value.ToString("dd/MM/yyyy");
                string expDate = dtPickerExpDate.Value.ToString("dd/MM/yyyy");
                string description = richTxtDescription.Text;

                if (string.IsNullOrWhiteSpace(productName) || quantity <= 0 || price <= 0 || string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(mfgDate) || string.IsNullOrWhiteSpace(expDate) || string.IsNullOrWhiteSpace(description))
                {
                    throw new InvalidProductException("All fields must be filled correctly");
                }

                // Create new Product and add it to the DataGridView
                ProductClass product = new ProductClass(productName, category, mfgDate, expDate, price, quantity, description);
                gridViewProductList.Rows.Add(product.productName, product.category, product.manufacturingDate, product.expirationDate, product.sellingPrice, product.quantity, product.description);
            }
            catch (InvalidProductException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unknown error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
