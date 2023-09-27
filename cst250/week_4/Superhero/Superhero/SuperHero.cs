using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SuperHero
{
    string name;
    string dateOfBirth;
    string homeTown;
    string abilities;
    string allyOrEnemyName;
    string compass;
    int looks;
    string colorWay1;
    string colorWay2;
    string colorWay3;

    public SuperHero(string name, string dateOfBirth, string homeTown, string abilities, string allyOrEnemyName, string compass, int looks, string colorWay1, string colorWay2, string colorWay3)
    {
        this.name = name;
        this.homeTown= homeTown;
        this.dateOfBirth = dateOfBirth;
        this.abilities = abilities;
        this.allyOrEnemyName = allyOrEnemyName;
        this.compass = compass;
        this.looks = looks;
        this.colorWay1 = colorWay1;
        this.colorWay2 = colorWay2;
        this.colorWay3 = colorWay3;
    }

    public string GetName() { return name; }
    public string GetDateofBirth() { return dateOfBirth; }
    public string GetHomeTown() { return homeTown; }

    public string GetAbilities() { return abilities; }

    public string GetAllyOrEnemy() { return allyOrEnemyName; }

    public string GetCompass() { return compass; }

    public int GetLooks() { return looks; }

    public string GetColorWay1() { return colorWay1; }

    public string GetColorWay2() { return colorWay2; }

    public string GetColorWay3() { return colorWay3; }
}

