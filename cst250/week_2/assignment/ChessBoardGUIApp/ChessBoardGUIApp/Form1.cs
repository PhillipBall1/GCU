using ChessBoardModel;

namespace ChessBoardGUIApp
{
    public partial class Form1 : Form
    {
        static public Board myBoard = new Board(8);
        public Button[,] grid = new Button[myBoard.size, myBoard.size];
        public Form1()
        {
            InitializeComponent();
            PopulateGrid();
        }

        public void PopulateGrid()
        {
            int buttonSize = panel1.Width / myBoard.size;
            panel1.Height = panel1.Width;

            for(int i =0; i < myBoard.size; i++)
            {
                for(int j = 0; j < myBoard.size; j++)
                {
                    grid[i, j] = new Button();

                    grid[i, j].Width = buttonSize;
                    grid[i, j].Height = buttonSize;

                    grid[i, j].Click += Grid_Button_Click;
                    panel1.Controls.Add(grid[i, j]);
                    grid[i, j].Location = new Point(buttonSize * i, buttonSize * j);

                    grid[i, j].Text = i.ToString() + "|" + j.ToString();
                    grid[i, j].Tag  = i.ToString() + "|" + j.ToString();
                }
            }
        }

        private void Grid_Button_Click(object? sender, EventArgs e)
        {
            string[] strArr = (sender as Button).Tag.ToString().Split('|');
            int r = int.Parse(strArr[0]);
            int c = int.Parse(strArr[1]);
            for (int i = 0; i < myBoard.size; i++)
            {
                for (int j = 0; j < myBoard.size; j++)
                {
                    myBoard.grid[i, j].currentlyOccupied = false;
                    grid[i, j].BackColor = default(Color);
                }
            }
            Cell currentCell = myBoard.grid[r, c];
            if(comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please Select an Item");
                return;
            }
            currentCell.currentlyOccupied = true;
            myBoard.MarkLegalMove(currentCell, comboBox1.SelectedItem.ToString());
            UpdateButtonLabels();

            
            

            (sender as Button).BackColor = Color.Cornsilk;
        }

        private void UpdateButtonLabels()
        {
            for(int i = 0; i < myBoard.size; i++)
            {
                for(int j = 0; j < myBoard.size; j++)
                {
                    grid[i, j].Text = "";
                    if (myBoard.grid[i, j].currentlyOccupied) grid[i, j].Text = comboBox1.SelectedItem.ToString();
                    if (myBoard.grid[i, j].legalNextMove) grid[i, j].Text = "Legal";
                }
            }
        }
    }
}