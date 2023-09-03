namespace CarShopGUI
{
    public partial class Form1 : Form
    {
        Store store = new Store();

        BindingSource CarListBinding = new BindingSource();
        BindingSource ShoppingListBinding = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            SetBindings();
        }

        private void SetBindings()
        {
            CarListBinding.DataSource = store.CarList;
            listBox1.DataSource = CarListBinding;
            listBox1.DisplayMember = "Display";
            listBox1.ValueMember = "Display";

            ShoppingListBinding.DataSource = store.ShoppingList;
            listBox2.DataSource = ShoppingListBinding;
            listBox2.DisplayMember = "Display";
            listBox2.ValueMember = "Display";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Car newCar = new Car();
            newCar.Make = textBox1.Text;
            newCar.Model = textBox2.Text;
            try
            {
                newCar.Price = Decimal.Parse(textBox3.Text);
            }
            catch
            {
                textBox3.Text = "Invalid input";
            }
            try
            {
                newCar.Miles = int.Parse(textBox4.Text);
            }
            catch
            {
                textBox4.Text = "Invalid input";
            }
            try
            {
                newCar.Year = int.Parse(textBox5.Text);
            }
            catch
            {
                textBox5.Text = "Invalid input";
            }

            store.CarList.Add(newCar);

            CarListBinding.ResetBindings(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            store.ShoppingList.Add((Car)listBox1.SelectedItem);

            ShoppingListBinding.ResetBindings(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            decimal total = store.checkout();
            label7.Text = "$" + total.ToString();
        }
    }
}