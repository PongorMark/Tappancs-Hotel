using System;
using System.Collections.Generic;
using System.Text;

namespace Tappancs_Hotel.Models
{
    internal class Pet
    {

        public string name { get; }
        public string species { get; }
        public string icon { get; }
        public int Fullness { get; private set; } = 70;
        public int Happiness { get; private set; } = 65;
        public int Energy { get; private set; } = 75;
        public string mood => Happiness >= 75 ? "Nagyon boldog" :
            Happiness >= 45 ? "Jól van" : "Törődésre vár";

        public Pet(string name, string species, string icon)
        {
            this.name = name;
            this.species = species;
            this.icon = icon;
        }

        public virtual string Speak()
        {
            return "Szia!";
        }

        public virtual string Play()
        {
            return $"{name} játszott egy jót!";
        }

        public void Feed()
        {
            ChangeStats(30, 5, 0);
        }
        public void Rest()
        {
            ChangeStats(-5, 4, 30);
        }

        public void EnjoyParty()
        {
            ChangeStats(-5, 18, -5);
        }
        public void GiveTreat()
        {
            ChangeStats(15, 15, 0);
        }

        public void EndDay()
        {
            ChangeStats(-15, -10, -12);
        }

        protected void ChangeStats(int fullness, int happiness, int energy)
        {
            Fullness = Math.Clamp(Fullness+ fullness, 0, 100);
            Happiness = Math.Clamp(Happiness + happiness, 0, 100);
            Energy = Math.Clamp(Energy + energy, 0, 100);
        }
    }
}
