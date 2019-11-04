using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoTDRPG
{
    class Enemy : Unit
    {
        string type;
        public Enemy(string enemyType, int health, int armor) : base(health, 10, armor)
        {
            type = enemyType;
        }
    }
}
