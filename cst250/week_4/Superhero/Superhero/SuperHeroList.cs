using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superhero
{
    public class SuperHeroList
    {
        private List<SuperHero> listOfHeros = new List<SuperHero>();

        public void AddHero(SuperHero hero){ listOfHeros.Add(hero); }

        public void RemoveHero(SuperHero hero){ listOfHeros.Remove(hero); }

        public List<SuperHero> GetList() { return listOfHeros; }
    }
}
