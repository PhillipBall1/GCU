using System.Xml.Linq;

namespace MilestoneGUI
{
    public partial class Form1 : Form
    {
        ProductsDAO productsDAO = new ProductsDAO();

        public Form1()
        {
            InitializeComponent();

            dataGridView2.DataSource = productsDAO.GetAllCategories();
            dataGridView1.DataSource = productsDAO.GetAllProducts();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = productsDAO.GetProductsBySearch(textBox1.Text);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            int rowClicked = dataGridView.CurrentRow.Index;

            int id = (int)dataGridView.Rows[rowClicked].Cells[0].Value;

            dataGridView1.DataSource = productsDAO.GetAllProductsByCategoryID(id);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rowClicked = dataGridView1.CurrentRow.Index;

            int id = (int)dataGridView1.Rows[rowClicked].Cells[0].Value;

            dataGridView1.DataSource = productsDAO.DeleteProductByID(id);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = productsDAO.GetCategoryBySearch(textBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int rowClicked = dataGridView2.CurrentRow.Index;

            int id = (int)dataGridView2.Rows[rowClicked].Cells[0].Value;

            dataGridView2.DataSource = productsDAO.DeleteCategoryByID(id);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Products prod = new Products
            {
                Name= txt_ProductName.Text,
                RetailPrice= float.Parse(txt_RetailPrice.Text),
                WholesalePrice= float.Parse(txt_WholesalePrice.Text),
                Description= txt_Description.Text,
                CategoryID= Int32.Parse(txt_CategoryID.Text),
                VendorID = Int32.Parse(txt_VendorID.Text),
            };
            MessageBox.Show("Inserted " + productsDAO.AddOneProduct(prod) + " new row(s)");
            dataGridView2.DataSource = productsDAO.GetAllCategories();
            dataGridView1.DataSource = productsDAO.GetAllProducts();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ProductCategories prod = new ProductCategories
            {
                Name = txt_CategoryName.Text,
                Description = txt_CategoryDescription.Text,
            };
            MessageBox.Show("Inserted " + productsDAO.AddOneCategory(prod) + " new row(s)");
            dataGridView2.DataSource = productsDAO.GetAllCategories();
            dataGridView1.DataSource = productsDAO.GetAllProducts();
        }
    }
}