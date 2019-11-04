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
        int pltCount;
        public Shotgun(int damage, int pelletCount) : base(new Projectile(damage,150,new Vector2(0,0),"Pellet", new Vector2(0,0)), 10, damage, 50, 70, 30, 30, 7, 1.8f, false)
        {
            
        }
        public override void Shoot()
        {
            for(int i = 0; i<pltCount;i++) base.Shoot();
            base.fireDelay = 10 / base.rof;
        }

    }
}
