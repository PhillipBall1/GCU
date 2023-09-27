namespace Superhero
{
    public partial class Form1 : Form
    {
        public string color1 = "";
        public string color2 = "";
        public string color3 = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string offensiveAbility = "\nOFFENSIVE\n";
            foreach(string item in offensiveCheckList.CheckedItems) offensiveAbility += item + "\n";

            string defensiveAbility = "\nDEFENSIVE\n";
            foreach (string item in defensiveCheckList.CheckedItems) defensiveAbility += item + "\n";

            string supportAbility = "\nSUPPORT\n";
            foreach (string item in supportCheckList.CheckedItems) supportAbility += item + "\n";

            string allyOrEnemy = "";

            if (allyButton.Checked) allyOrEnemy = "\nClosest Ally: " + allyEnemyBox.SelectedItem.ToString();
            if (enemyButton.Checked) allyOrEnemy = "\nClosest Enemy: " + allyEnemyBox.SelectedItem.ToString();

            string abilities = offensiveAbility + defensiveAbility + supportAbility;

            string morality = "\nMorality: " + moralScroll.Value;
            string motivation = "\nMotivation: " + motivationScroll.Value;
            string potential = "\nPotential: " + potentialScroll.Value;
            string luck = "\nLuck: " + luckScroll.Value;

            string compass = morality + motivation + luck + potential;

            SuperHero createdHero = new SuperHero(heroName.Text, heroDOB.Value.ToString(), heroHometown.Text, abilities, allyOrEnemy, compass, looksBar.Value, color1, color2, color3);
            SuperHeroList list = new SuperHeroList();
            list.AddHero(createdHero);
            Form2 f2 = new Form2(list);
            this.Hide();
            f2.Show();
        }

        private void allyButton_CheckedChanged(object sender, EventArgs e)
        {
            if(allyButton.Checked) enemyButton.Checked = false;
        }

        private void enemyButton_CheckedChanged(object sender, EventArgs e)
        {
            if(enemyButton.Checked) allyButton.Checked = false;
        }

        private void heroColor1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            heroColor1.BackColor = colorDialog1.Color;
            color1 = (colorDialog1.Color.ToArgb() & 0x00FFFFFF).ToString("X6");
        }

        private void heroColor2_Click(object sender, EventArgs e)
        {
            colorDialog2.ShowDialog();
            heroColor2.BackColor = colorDialog2.Color;
            color2 = (colorDialog2.Color.ToArgb() & 0x00FFFFFF).ToString("X6");
        }

        private void heroColor3_Click(object sender, EventArgs e)
        {
            colorDialog3.ShowDialog();
            heroColor3.BackColor = colorDialog3.Color;
            color3 = (colorDialog3.Color.ToArgb() & 0x00FFFFFF).ToString("X6");
        }

        private void offensiveCheckList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void moralScroll_Scroll(object sender, ScrollEventArgs e)
        {
            moralLabel.Text = "Morality: " + moralScroll.Value;
        }

        private void motivationScroll_Scroll(object sender, ScrollEventArgs e)
        {
            motivationLabel.Text = "Motivation: " + motivationScroll.Value;
        }

        private void potentialScroll_Scroll(object sender, ScrollEventArgs e)
        {
            potentialLabel.Text = "Potential: " + potentialScroll.Value;
        }

        private void luckScroll_Scroll(object sender, ScrollEventArgs e)
        {
            luckLabel.Text = "Luck: " + luckScroll.Value;
        }
    }
}