using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        private Board board;
        private int size = 10;
        private Stopwatch watch = new Stopwatch();
        private int difficulty = 0;
        string path = @"" + Application.StartupPath + "\\Resources\\scores.txt";
        List<Score> scores = new List<Score>();
        public Form1()
        {
            InitializeComponent();
            label3.Text = "Size: "  + size.ToString();
        }

        private void StartGame(object sender, EventArgs e)
        {
            panel1.Visible= false;
            panel3.Visible = true;
            PopulatePanel();
            watch.Start();
        }

        private void PopulatePanel()
        {
            panel2.Controls.Clear();
            
            if (radioButton1.Checked) difficulty = 90;
            if (radioButton2.Checked) difficulty = 75;
            if (radioButton3.Checked) difficulty = 60;
            board = new Board(size, difficulty);

            for (int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    Button button = new Button
                    {
                        FlatStyle = FlatStyle.Flat,
                        BackColor = Color.Black,
                        ForeColor = Color.White,
                        Name = i + " " + j,
                        Width = panel2.Width / size,
                        Height = panel2.Height / size,
                        Location = new Point(j * (panel2.Width / size), (i % size) * (panel2.Height / size)),
                        Tag = new Tuple<int, int>(i, j), 
                    };

                    button.MouseDown += new MouseEventHandler(GameButtonClicked);
                    panel2.Controls.Add(button);
                }
            }
        }

        public void GameButtonClicked(object sender, MouseEventArgs e)
        {
            Button clickedButton = (Button)sender;
            Tuple<int, int> rowColumn = (Tuple<int, int>)clickedButton.Tag;
            int r = rowColumn.Item1;
            int c = rowColumn.Item2;
            int reveal = 0;

            if (e.Button == MouseButtons.Left) reveal = board.RevealCells(board.GetCell(r, c));
            else if (e.Button == MouseButtons.Right)
            {
                if(clickedButton.BackgroundImage != null)
                {
                    clickedButton.BackgroundImage = null;
                    board.GetCell(r, c).SetMarked(false);
                }
                else
                {
                    clickedButton.BackgroundImage = FormatImage(Properties.Resources.Flag);
                    board.GetCell(r, c).SetMarked(true);
                }
                
            }
            EndingConditions(reveal);
            UpdateBoard(false);
        }

        private void UpdateBoard(bool reveal)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Control[] button = panel2.Controls.Find(i + " " + j, true);
                    Button currButton = (Button)button[0];
                    Cell currCell = board.GetCell(i, j);
                    if (!reveal)
                    {
                        if (currCell.GetVisited() == false) continue;
                    }
                    currButton.Text = " ";
                    if (currCell.GetLive()) currButton.BackgroundImage = FormatImage(Properties.Resources.Bomb);
                    else LiveNeighborButton(currButton, currCell.GetLiveNeighbors());
                }
            }
        }

        private void LiveNeighborButton(Button currButton, int neighbors)
        {
            currButton.BackgroundImage = null;
            switch (neighbors)
            {
                case 0: currButton.BackColor = Color.FromArgb(255, 240, 156); break;
                case 1: currButton.BackColor = Color.FromArgb(255, 220, 156); break;
                case 2: currButton.BackColor = Color.FromArgb(255, 200, 156); break;
                case 3: currButton.BackColor = Color.FromArgb(255, 180, 156); break;
                case 4: currButton.BackColor = Color.FromArgb(255, 160, 156); break;
                case 5: currButton.BackColor = Color.FromArgb(255, 140, 156); break;
                case 6: currButton.BackColor = Color.FromArgb(255, 120, 156); break;
                case 7: currButton.BackColor = Color.FromArgb(255, 100, 156); break;
                case 8: currButton.BackColor = Color.FromArgb(255, 80, 156); break;
            }
            currButton.ForeColor = Color.Black;
            if (neighbors == 0) return;

            currButton.Text = neighbors.ToString();
        }

        private Image FormatImage(Image prop)
        {
            Size bSize = new Size(panel2.Width / size, panel2.Height / size);
            Bitmap b = new Bitmap(prop, new Size((Point)bSize));
            return b;
        }

        private void EndingConditions(int condition)
        {
            if (condition == 0) return;
            UpdateBoard(true);

            watch.Stop();

            string time = watch.Elapsed.Minutes + ":" + watch.Elapsed.Seconds;

            if (condition == 1) MessageBox.Show("You Won!\nElapsed Time: " + time, "Minesweeper");

            if (condition == -1) MessageBox.Show("You Lost!", "Minesweeper");

            
            panel3.Visible = false;
            panel1.Visible = true;

            if(condition == 1) scores.Add(new Score(GenerateScore(watch.Elapsed.TotalSeconds, difficulty, size), GetDifficulty(), size, DateTime.Now.ToString()));

            SaveScores();

            watch.Reset();
        }

        private string GetDifficulty()
        {
            switch(difficulty)
            {
                case 90: return "Easy";
                case 75: return "Medium";
                case 60: return "Hard";
            }
            return "";
        }

        //Load scores, sort scores, the display in the listbox when leaderboards button is pressed.
        private void button2_Click(object sender, EventArgs e)
        {
            LoadScores();
            List<Score> sortedScores = scores.OrderByDescending(score => score.GetScore()).ToList();
            listBox1.Items.Clear();
            for (int i = 0; i < sortedScores.Count; i++)
            {
                listBox1.Items.Add((i + 1) + ": " + sortedScores[i].ToString());
            }
            panel4.Visible = true;
        }

        //makes the score more exciting instead of just a time
        private double GenerateScore(double seconds, int difficulty, int size)
        {
            return Math.Round((100 - difficulty) * size / seconds * 100, 2);
        }

        #region Save and Load scores

        //saves scores to file by taking the override ToString component from Score and coinverting List<Score> to a List<string>
        private void SaveScores()
        {
            List<string> stringList = new List<string>();
            foreach (Score score in scores)
            {
                stringList.Add(score.ToString());
            }
            File.WriteAllLines(path, stringList);
        }

        //loads scores from a file by just splitting the line using '|' getting the double score value and the string date value
        private void LoadScores()
        {
            List<string> file = File.ReadAllLines(path).ToList();
            if (file.Count <= 0) return;
            scores.Clear();
            foreach (string line in file)
            {
                string[] split = line.Split('|');
                scores.Add(new Score(double.Parse(split[0]), split[1], int.Parse(split[2]), split[3]));
            }
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            size = trackBar1.Value;
            label3.Text = "Size: " + size.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = "Elapsed Time: " + watch.Elapsed.Minutes.ToString() + " : " + watch.Elapsed.Seconds.ToString();
        }

    }

}