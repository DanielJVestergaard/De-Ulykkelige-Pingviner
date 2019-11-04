using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoTDRPG
{
    class Projectile
    {
        int dmg;
        int spd;
        Vector2 heading;
        string type;
        Vector2 pos;
        public Projectile(int damage, int speed, Vector2 direction, string projectileType, Vector2 position)
        {
            dmg = damage;
            spd = speed;
            heading = direction;
            type = projectileType;
            pos = position;
        }
    }
}
