namespace Minesweeper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = true;
            PopulatePanel(15);
        }

        private void PopulatePanel(int size)
        {
            for (int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    Button button = new Button
                    {
                        Text = "",
                        Width = panel2.Width / size,
                        Height = panel2.Height / size,
                        Location = new Point(j * (panel2.Width / size), (i % size) * (panel2.Height / size))
                    };

                    button.Click += GameButtonClicked;

                    panel2.Controls.Add(button);
                }
            }
        }

        private void GameButtonClicked(object sender, EventArgs e)
        {
            Int32.TryParse(((Button)sender).Text, out int count);
            count++;
            ((Button)sender).Text = count.ToString();
        }
    }

}