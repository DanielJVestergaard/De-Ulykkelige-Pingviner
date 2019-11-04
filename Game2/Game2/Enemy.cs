using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2
{
    class Enemy : GameObject
    {
        public Enemy()
        {
            Random rnd = new Random();
            int r = rnd.Next(0, 4);
            if (r == 0)
            {
                position.X = rnd.Next(350, 450);
                position.Y = 0;
            }
            else if (r == 1)
            {
                position.X = 0;
                position.Y = rnd.Next(350, 450);
            }
            else if (r == 2)
            {
                position.X = 800;
                position.Y = rnd.Next(350, 450);
            }
            else
            {
                position.X = rnd.Next(350, 450);
                position.Y = 800;
            }

            speed = 150f;
        }
        public override void Update(GameTime gameTime)
        {
            Move(gameTime);
        }
        public override void Move(GameTime gameTime)
        {
            //Checking X Range
            if (playerPosition.X > position.X)
            {
                if (playerPosition.X - 200 < position.X)
                {
                    velocity = new Vector2(0, 0);
                }
                else 
                {
                    velocity = new Vector2(1, 0);
                }
                
            }
            if (playerPosition.X < position.X)
            {
                if (playerPosition.X + 200 > position.X)
                {
                    velocity = new Vector2(0, 0);
                }
                else
                {
                    velocity = new Vector2(-1, 0);
                }
              
            }

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            position += ((velocity * speed) * deltaTime);

            //Checking Y Range
            if (playerPosition.Y > position.Y)
            {
                if (playerPosition.Y - 200 < position.Y)
                {
                    velocity = new Vector2(0, 0);
                }
              
                else
                {
                    velocity = new Vector2(0, 1);
                }

            }
            if (playerPosition.Y < position.Y)
            {
                if (playerPosition.Y + 200 > position.Y)
                {
                    velocity = new Vector2(0, 0);
                }
                else
                {
                    velocity = new Vector2(0, -1);
                }

            }

            //Concludes Movement
            
            position += ((velocity * speed) * deltaTime);

        }
        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("RedPanda");
        }

        public override void OnCollision(GameObject other)
        {

            if (other is Enemy && other.position.X < this.position.X)
            {
                position.X += 10;
            }
            if (other is Enemy && other.position.Y < this.position.Y)
            {
                position.Y += 10;
            }
        }
    }
}
