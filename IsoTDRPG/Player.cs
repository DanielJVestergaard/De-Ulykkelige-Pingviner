using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace IsoTDRPG
{
    class Player : Unit
    {
        public Player(int health, int speed, int armor) : base(health, speed, armor, new Vector2(0, 0))
        {

        }
        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("Good Guy");

        }
        
        private void HandleInput()
        {
            direction = Vector2.Zero;

            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.W))
            {
                direction += new Vector2(0, -1);
            }

            if (keyState.IsKeyDown(Keys.S))
            {
                direction += new Vector2(0, +1);
            }

            if (keyState.IsKeyDown(Keys.A))
            {
                direction += new Vector2(-1, 0);
            }

            if (keyState.IsKeyDown(Keys.D))
            {
                direction += new Vector2(+1, 0);
            }

            if (direction != Vector2.Zero)
            {
                direction.Normalize();
            }
        }
        public override void Update(GameTime gameTime)
        {
            HandleInput();
            Move(gameTime);
        }
        public override void Move(GameTime gameTime)
        {
            base.Move(gameTime);

            if (pos.X < 0)
            {
                pos.X = 0;
            }
            if (pos.Y < 0)
            {
                pos.Y = 0;
            }
            if (pos.X > 900)
            {
                pos.X = 900;
            }
            if (pos.Y > 800)
            {
                pos.Y = 800;
            }
            else
            {

            }

        }
        public override void OnCollision(Unit other)
        {
            if (other is Enemy)
            {

            }

        }

    }
}