using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
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

        protected Texture2D sprite;
        public Projectile(int damage, int speed, Vector2 direction, string projectileType, Vector2 position)
        {
            dmg = damage;
            spd = speed;
            heading = direction;
            type = projectileType;
            pos = position;
            
        }

        public void Move(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            pos += heading * spd * deltaTime;
        }
        public void LoadContent(ContentManager content)
        {
            
        }
        public void Update(GameTime gameTime)
        {
            
            Move(gameTime);
        }
        public virtual void OnCollision(Unit other)
        {

        }


        public void CheckCollision(Unit other)
        {
            if (CollisionBox.Intersects(other.CollisionBox))
            {
                OnCollision(other);
            }
        }
        public virtual Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)pos.X, (int)pos.Y, 2, 2);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(GameWorld.projectileB, pos, Color.White);
        }
        
    }
}
