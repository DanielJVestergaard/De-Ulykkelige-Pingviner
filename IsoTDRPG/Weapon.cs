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
        private Game1 gameClass;
        public int rof;
        int dmg;
        int rng;
        int accHip;
        int accSpread;
        int rec;
        int mgs;
        float reloadSpd;
        float reloadProg;
        public float fireDelay;
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
            KeyboardState keyState = Keyboard.GetState();
            //if (keyState.IsKeyDown())
            //{
            //    if (auto)
            //    {
            //        if (mgs > 0 && fireDelay <= 0)
            //        {
            //            gameClass.activeProjectiles.Add(type);
            //        }
            //        else Reload(reloadSpd);
            //    }
            //}
            
            

        }
        public void Reload(float reloadSpeed)
        {
            if (mgs < maxMag && reloadProg <= 0) reloadProg += reloadSpeed;
        }

    }
}
