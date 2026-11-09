using System;
using System.Collections.Generic;
using System.Text;

namespace Tappancs_Hotel.Models
{
    internal class PetHotel
    {
        public List<Pet> Pets { get; } = new()
        {
            new Dog ("Gyere ide Takarodj"),
            new Cat ("De szép macska vagy, te Sanyi"),
            new Dog ("Milyen feri"),
        };

        public int day { get; private set; } = 1;
        public int Money { get; private set; } = 1800;
        public int Treats { get; private set; } = 2;
        public int averageHappiness => (int)Pets.Average(p => p.Happiness);

        //Hét nap után cél amit el kell érni, hogy a játékos nyerjen:
        public bool HasWon => day >= 7 && averageHappiness >= 75 && Money >=2500;

        public string FeedPet(Pet pet)
        {
            const int price = 120;
            if (Money < price)
                return "Nincs elég pénzed, hogy megetesd a kisállatot!";

            Money -= price;
            pet.Feed();
            return $"{pet.name} megetetve! -{price} Ft, +30 jóllakottság";
        }

        public string RestPet(Pet pet)
        {
            pet.Rest();
            return $"{pet.name} pihent! +30 energia";
        }

        public string GivePetTreat(Pet pet)
        {
            if (Treats == 0)
                return "Nincs elég jutalomfalatod, hogy megjutalmazd a kisállatot!";
            Treats--;
            pet.GiveTreat();
            return $"{pet.name} megkapta a jutalomfalatot! +15 jókedv";
        }
        public bool BuyTreatPack()
        {
            if (Money < 350)
                return false;
            Money -= 350;
            Treats += 3;
            return true;
        }

        public bool BuyParty()
        {
            if (Money < 450)
                return false;
            Money -= 450;
            foreach (Pet pet in Pets)
                pet.EnjoyParty();
            return true;
        }
        public string NextDay()
        {
            int income = Pets.Sum(p => 100 + p.Happiness * 2);
            Money += income;
            day++;
            foreach (Pet pet in Pets)
                pet.EndDay();
            return $"Új nap kezdődött! Napi bevétel: +{income} Ft";
        }
    }
}
