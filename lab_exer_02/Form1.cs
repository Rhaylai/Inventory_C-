using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static lab_exer_02.InvalidProductException;

namespace lab_exer_02
{
    public partial class frmAddProduct : Form
    {
        BindingSource showProductList; // declare a BindingSource object at the class level

        public frmAddProduct()
        {
            InitializeComponent();
            showProductList = new BindingSource(); //instantiates the BindingSource object in the constructor of frmAddProduct
        }
        /*modified the code given in the txt file of the module we are throwing an InvalidProductException when the input does not match the regular expression. 
          This way, all code paths in the method either return a value or throw an exception*/
        public string Product_Name(string name)
        {
            if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
            {
                throw new StringFormatException("Product name must only contain letters");
            }
            return name;
        }

        public int Quantity(string qty)
        {
            if (!Regex.IsMatch(qty, @"^[0-9]"))
            {
                throw new NumberFormatException("Quantity must be a number");
            }
            return Convert.ToInt32(qty);
        }

        public double SellingPrice(string price)
        {
            if (!Regex.IsMatch(price.ToString(), @"^(\d*\.)?\d+$"))
            {
                throw new CurrencyFormatException("Price must be a number");
            }
            return Convert.ToDouble(price);
        } /*Further modified the code  to throw these custom exceptions when the input does not match the specified regular expression */


        private void Form1_Load(object sender, EventArgs e)
        {
            string[] categories = new string[] { "Electronics", "Books", "Clothing", "Food" };

            foreach (string category in categories)
            {
                cbCategory.Items.Add(category);
            }
            gridViewProductList.DataSource = showProductList;


        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string productName = Product_Name(txtProductName.Text);
                int quantity = Quantity(txtQuantity.Text);
                double price = SellingPrice(txtSellPrice.Text);
                string category = cbCategory.SelectedItem.ToString();
                string mfgDate = dtPickerMfgDate.Value.ToString("dd/MM/yyyy");
                string expDate = dtPickerExpDate.Value.ToString("dd/MM/yyyy");
                string description = richTxtDescription.Text;

                // Create new Product and add it to the DataGridView
                ProductClass product = new ProductClass(productName, category, mfgDate, expDate, price, quantity, description);
                gridViewProductList.Rows.Add(product.productName, product.category, product.manufacturingDate, product.expirationDate, product.sellingPrice, product.quantity, product.description);
            }
            catch (NumberFormatException ex)
            {
                MessageBox.Show(ex.Message, "Number Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (StringFormatException ex)
            {
                MessageBox.Show(ex.Message, "String Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (CurrencyFormatException ex)
            {
                MessageBox.Show(ex.Message, "Currency Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
