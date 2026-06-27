using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.AbstractFactory
{
    public abstract class FighterFactory
    {
        public abstract Fighter CreateFighter();
        public abstract Missile CreateMissile();
        public abstract Bomb CreateBomb();
    }
}
