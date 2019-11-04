using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace IsoTDRPG
{
    class Shotgun : Weapon
    {
        public Shotgun(int damage) : base(new Projectile(damage,150,new Vector2(0,0),"Pellet", new Vector2(0,0)), 100, damage, 50, 70, 30, 30, 7, 1.8f)
        {

        }
    }
}
