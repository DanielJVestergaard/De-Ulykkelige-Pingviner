using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace IsoTDRPG
{
    class AssaultRifle : Weapon
    {
        
        public AssaultRifle(int damage) : base(new Projectile(damage,200, new Vector2(0,0),"Bullet", new Vector2(0,0)), 50, damage, 200, 40, 20, 10, 30,1.2f, true)
        {
            
        }
    }
}
