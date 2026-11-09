using System;
using System.Collections.Generic;
using System.Text;

namespace Tappancs_Hotel.Models
{
    internal class Cat : Pet
    {
        public Cat(string name) : base(name, "Macska", "🐱")
        { }
        public override string Speak()
        {
            return "Miau!";
        }
        public override string Play()
        {
            ChangeStats(-8, 20, -10);
            return $"{name} megharapott egy négert! +20 jókedv";
        }
    {

    }
}
