using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace IsoTDRPG
{
    class Pistol : Weapon
    {
        public Pistol(int damage) : base (new Projectile(damage, 150, new Vector2(0, 0), "Bullet", new Vector2(0, 0)), 250, damage, 200, 40, 10, 5, 8, 1)
        {

        }
    }
}
