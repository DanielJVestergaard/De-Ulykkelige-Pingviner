using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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
        
        public int rof;
        int dmg;
        int rng;
        int accHip;
        int accSpread;
        int rec;
        int mgs;
        float reloadSpd;
        float reloadProg;
        protected float fireDelay;
        int maxMag;
        bool auto;


        public Weapon(Projectile weaponType, int rateOfFire, int damage, int range, int accuracyHipfire, int accuracySpread, int recoil, int magSize, float reloadSpeed, bool fullAuto)
        {
            type = weaponType;
            rof = rateOfFire;
            dmg = damage;
            rng = range;
            accHip = accuracyHipfire;
            accSpread = accuracySpread;
            rec = recoil;
            mgs = magSize;
            maxMag = magSize;
            reloadSpd = reloadSpeed;
            auto = fullAuto;
        }
        public virtual void Shoot()
        {
            Projectile shotProjectile = new Projectile(10, 200, new Vector2(1, 1), "Bullet", new Vector2(500, 400));
            GameWorld.activeProjectiles.Add(shotProjectile);
            fireDelay += 10 / rof;
        }
        public virtual void Aim()
        {

        }
        public void Reload(float reloadSpeed)
        {
            if (mgs < maxMag && reloadProg <= 0) reloadProg += reloadSpeed;
        }

    }
}
