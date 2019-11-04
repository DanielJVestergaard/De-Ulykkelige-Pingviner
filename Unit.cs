using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace IsoTDRPG
{
    class Unit
    {
        Vector2 direction;
        Vector2 pos;
        int hp;
        int spd;
        int arm;

        public Unit(int health, int speed, int armor, Vector2 position)
        {
            hp = health;
            spd = speed;
            arm = armor;
            pos = position;
        }

        public virtual void Move()
        {
            
        }
        public virtual void Fire()
        {

        }

    }
}
