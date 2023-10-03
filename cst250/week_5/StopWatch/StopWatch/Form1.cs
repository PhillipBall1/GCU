using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using System.Text.Json;
using static System.Formats.Asn1.AsnWriter;

namespace StopWatch
{
    public partial class Form1 : Form
    {

        public static Stopwatch watch = new Stopwatch();
        public static int points;
        public static Dictionary<string, int> scores = new Dictionary<string, int>();
        public static bool open;
        public static string filePath = "./scores.json";
        public static int difficulty = 0;

        public Form1()
        {
            InitializeComponent();
            groupBox1.Visible = false;
            label2.Text = points.ToString();
            label3.Text = "Current Difficulty: Easy";
        }

        //Updates the games timer and other objects that need to be checked, such as random ones and points
        private void timer1_Tick(object sender, EventArgs e)
        {
            TextHandlers();

            if (watch.IsRunning) DifficultyHandler();

            if (watch.ElapsedMilliseconds >= 30000) GameEnd();
        }

        #region Object Handlers
        //Handles the target and the bomb objects placement
        private void TargetsHandler(Button button)
        {
            Random r = new Random();

            button.Visible = true;
            button.Left = r.Next(100, this.Width - 100);
            button.Top = r.Next(100, this.Height - 100);
        }


        //Handles the timer and score objects text
        public void TextHandlers()
        {
            float time = (float)watch.Elapsed.TotalSeconds;
            double final = Math.Round(time, 2);
            label1.Text = "Time: " + final.ToString();
            label2.Text = "Score: " + points.ToString();
        }

        //Increases more bombs with higher difficulty
        private void DifficultyHandler()
        {
            switch (difficulty)
            {

                case 0: RandomChanceBomb(bomb); break;
                case 1:
                    RandomChanceBomb(bomb);
                    RandomChanceBomb(bomb2);
                    break;
                case 2:
                    RandomChanceBomb(bomb);
                    RandomChanceBomb(bomb2);
                    RandomChanceBomb(bomb3);
                    break;
            }
        }

        //Creates a chance for a bomb to spawn 
        private void RandomChanceBomb(Button bomb)
        {
            Random r = new Random();
            if (r.Next(0, 100) <= 10) TargetsHandler(bomb);
        }

        #endregion

        #region Game States


        //Game Started, hide unwanted components, start the watch, place target randomly
        private void GameStart()
        {
            watch.Start();
            target.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            label3.Visible = false;
            groupBox1.Visible = false;
            points = 0;

            Random r = new Random();
            target.Left = r.Next(100, this.Width - 100);
            target.Top = r.Next(100, this.Height - 100);
        }


        //Game ended, show wanted components, reset the watch, stop the watch, add players score
        public void GameEnd()
        {
            watch.Reset();

            switch (difficulty)
            {
                case 0: scores.Add(scores.Count() + 1 + "- Easy: ", points); break;
                case 1: scores.Add(scores.Count() + 1 + "- Medium: ", points); break;
                case 2: scores.Add(scores.Count() + 1 + "- Hard: ", points); break;
            }
            watch.Stop();
            target.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            label3.Visible = true;
            bomb.Visible = false;
            bomb2.Visible = false;
            bomb3.Visible = false;
        }

        #endregion

        #region Click Handlers


        //Start button clicked, start the game
        private void button1_Click(object sender, EventArgs e)
        {
            GameStart();
        }

        // Score button clicked, hide or show the scores based on if it is already open or not, clear current items in listbox,
        //      sort the scores from highest to lowest changing the dictionary to a list and then making a comparison of the
        //      difficulty, then making a comparison of the int value, and returning it, use a for loop to redisplay all of
        //      the scores in order
        private void button2_Click(object sender, EventArgs e)
        {
            open = !open;
            groupBox1.Visible = open;
            listBox1.Items.Clear();

            List<KeyValuePair<string, int>> sortedScores = scores.ToList();
            sortedScores.Sort((pair1, pair2) =>
            {
                string[] difficultyOrder = { "Hard: ", "Medium: ", "Easy: " };

                int comparison = Array.IndexOf(difficultyOrder, pair1.Key).CompareTo(Array.IndexOf(difficultyOrder, pair2.Key));

                if (comparison == 0)
                {
                    return pair2.Value.CompareTo(pair1.Value);
                }

                return comparison;
            });

            for( int i = 0; i < sortedScores.Count; i++)
            {
                listBox1.Items.Add(sortedScores[i]);
            }
        }

        //Bombs Clicked
        private void button3_Click(object sender, EventArgs e)
        {
            points -= 5;
            bomb.Visible = false;
        }
        private void bomb2_Click(object sender, EventArgs e)
        {
            points -= 5;
            bomb2.Visible = false;
        }
        private void bomb3_Click(object sender, EventArgs e)
        {
            points -= 5;
            bomb3.Visible = false;
        }

        //Target button clicked, add a point
        private void button4_Click(object sender, EventArgs e)
        {
            TargetsHandler(target);
            points++;
        }

        //Player clicks form, loses a point
        private void Form1_Click(object sender, EventArgs e)
        {
            if (watch.Elapsed.TotalMilliseconds <= 0) return;

            points--;
        }

        //Increases the difficulty
        private void button3_Click_1(object sender, EventArgs e)
        {
            difficulty++;
            if (difficulty > 2) difficulty = 0;

            switch (difficulty)
            {
                case 0: label3.Text = "Current Difficulty: Easy"; break;
                case 1: label3.Text = "Current Difficulty: Medium"; break;
                case 2: label3.Text = "Current Difficulty: Hard"; break;
            }
        }
        #endregion

        #region Save and Load scores

        public static void SaveScores()
        {
            try
            {
                string json = JsonSerializer.Serialize(scores);

                File.WriteAllText(filePath, json);
            }
            catch (IOException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public static void LoadScores()
        {
            scores.Clear();
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);

                    scores = JsonSerializer.Deserialize<Dictionary<string, int>>(json);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadScores();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveScores();
        }

        #endregion

        
    }
}