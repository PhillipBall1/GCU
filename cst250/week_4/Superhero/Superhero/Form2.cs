using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Superhero
{
    public partial class Form2 : Form
    {
        public SuperHeroList heroList;
        public Form2(SuperHeroList list)
        {
            InitializeComponent();
            heroList = list;
            foreach(SuperHero hero in heroList.GetList())
            {
                herosList.Items.Add(hero.GetName());
            }
        }

        private void herosList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (herosList.SelectedItem == null) return;
            herosList.SelectedItem.ToString();
            SuperHero selectedHero= null;
            foreach(SuperHero hero in heroList.GetList()) 
            {
                if (hero.GetName() == herosList.SelectedItem.ToString()) selectedHero = hero;
            }

            string looks = selectedHero.GetLooks() >= 5 ? "\nFriendly appeal" : "\nScary appeal";

            heroInfo.Text = selectedHero.GetName() + " was born in " + selectedHero.GetHomeTown() + " on " + selectedHero.GetDateofBirth() +
                "\n\n-ABILITIES-" + selectedHero.GetAbilities() + selectedHero.GetAllyOrEnemy() + "\n\n-COMPASS-" + selectedHero.GetCompass() + 
                "\n\n-IMAGE-" + looks + "\nChosen color way: " + selectedHero.GetColorWay1() + " - " + selectedHero.GetColorWay2() + " - " +
                selectedHero.GetColorWay3();
        }
    }
}
