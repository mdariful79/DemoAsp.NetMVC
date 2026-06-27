using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.AbstractFactory
{
    public class Mig29FighterFactory : FighterFactory
    {
        public override Fighter CreateFighter()
        {
            return new Mig29();
        }
        public override Bomb CreateBomb()
        {
            return new Mig29Bomb();
        }
        public override Missile CreateMissile()
        {
            return new Mig29Missile();
        }
    }
}
