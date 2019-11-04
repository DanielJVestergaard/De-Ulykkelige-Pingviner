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
    class Player : GameObject
    {
        
        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("RedPanda");
            position.X = 450;
            position.Y = 450;
            speed = 700f;
            
        }
        private void HandleInput()
        {
            velocity = Vector2.Zero;

            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.W))
            {
                velocity += new Vector2(0, -1);
            }
            
            if (keyState.IsKeyDown(Keys.S))
            {
                velocity += new Vector2(0, +1);
            }

            if (keyState.IsKeyDown(Keys.A))
            {
                velocity += new Vector2(-1, 0);
            }

            if (keyState.IsKeyDown(Keys.D))
            {
                velocity += new Vector2(+1, 0);
            }

            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }
        }
        public override void Update(GameTime gameTime)
        {
            HandleInput();
            Move(gameTime);
            playerPosition = new Vector2(position.X, position.Y);
        }
        public void Move(GameTime gameTime)
        {
            base.Move(gameTime);

            if(position.X < 0)
            {
                position.X = 0;
            }
            if (position.Y < 0)
            {
                position.Y = 0;
            }
            if (position.X > 900)
            {
                position.X = 900;
            }
            if (position.Y > 800)
            {
                position.Y = 800;
            }
            else
            {
                
            }
            
        }
        public override void OnCollision(GameObject other)
        {
            if(other is Enemy)
            {

            }
        }
    }
}
