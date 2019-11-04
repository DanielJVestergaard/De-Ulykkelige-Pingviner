using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoTDRPG
{
    abstract class Weapon
    {
        Projectile type;
        int rof;
        int dmg;
        int rng;
        int accHip;
        int accSpread;
        int rec;
        int mgs;
        float reloadSpd;
        
        public Weapon(Projectile weaponType, int rateOfFire, int damage, int range, int accuracyHipfire, int accuracySpread, int recoil, int magSize, float reloadSpeed)
        {
            type = weaponType;
            rof = rateOfFire;
            dmg = damage;
            rng = range;
            accHip = accuracyHipfire;
            accSpread = accuracySpread;
            rec = recoil;
            mgs = magSize;
            reloadSpd = reloadSpeed;
            
        }
        public virtual void Shoot()
        {
            if (mgs > 0)
            {
                
            }
            else Reload(reloadSpd);

        }
        public void Reload(float reloadSpeed)
        {

        }

    }
}
