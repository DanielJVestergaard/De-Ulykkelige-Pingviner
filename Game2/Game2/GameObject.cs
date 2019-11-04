using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    abstract class GameObject
    {
        public static Vector2 playerPosition;
        protected Texture2D sprite;
        public Vector2 position;

        protected Vector2 velocity;
        protected float speed = 400;

        public int debugMoveCount = 0;

        public virtual Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
            }
        }

        public abstract void LoadContent(ContentManager content);

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, Color.White);
        }
        public abstract void Update(GameTime gameTime);

        public virtual void Move(GameTime gameTime)
        {
            //Debug.WriteLine(this.GetType());
            if (this is Enemy)
            {
                if (speed > 200f)
                {
                    Debug.WriteLine("Too fast: " + speed);
                }

                if (Math.Sqrt(velocity.LengthSquared()) > 1) Debug.WriteLine("Velocity: " + Math.Sqrt(velocity.LengthSquared()));
            }
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            position += ((velocity * speed) * deltaTime);
        }

        public abstract void OnCollision(GameObject other);
       

        public void CheckCollision(GameObject other)
        {
        if(CollisionBox.Intersects(other.CollisionBox))
        {
        OnCollision(other);
        }

        
     }

    }
}
