using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace IsoTDRPG
{
    class Unit
    {
        public Vector2 direction;
        public Vector2 pos;
        public Weapon weapon;
        protected int hp;
        protected int spd;
        protected int arm;
        protected Texture2D sprite;
        public Unit(int health, int speed, int armor, Vector2 position, Weapon equippedWeapon)
        {
            hp = health;
            spd = speed;
            arm = armor;
            pos = position;
            weapon = equippedWeapon;
        }
        public virtual Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)pos.X, (int)pos.Y, sprite.Width, sprite.Height);
            }
        }
        public virtual void LoadContent(ContentManager content)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, pos, Color.White);
        }
        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Move(GameTime gameTime)
        {
            //Debug.WriteLine(this.GetType());
            //if (this is Enemy)
            //{
            //    if (spd > 200f)
            //    {
            //        Debug.WriteLine("Too fast: " + speed);
            //    }

            //    if (Math.Sqrt(velocity.LengthSquared()) > 1) Debug.WriteLine("Velocity: " + Math.Sqrt(velocity.LengthSquared()));
            //}
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            pos += direction * spd * deltaTime;
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

        public virtual void HealthCheck()
        {

        }
        
        
        public virtual void Fire()
        {

        }

    }
}
