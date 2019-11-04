using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace IsoTDRPG
{
    class Sniper : Weapon
    {
        bool pierce;
        public Sniper(int damage, bool piercingRounds) : base(new Projectile(damage, 150, new Vector2(0, 0), "Piercing", new Vector2(0,0)), 5, damage, 1000, 70, 0, 40, 5, 2, false)
        {
            pierce = piercingRounds;
        }
    }
}
