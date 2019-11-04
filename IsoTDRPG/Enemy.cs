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
    class Enemy : Unit
    {
        
        string type;
        public Enemy(string enemyType, int health, int armor) : base(health, 10, armor, new Microsoft.Xna.Framework.Vector2(0, 0))
        {
            type = enemyType;
        }
        public override void Update(GameTime gameTime)
        {
            Move(gameTime);
        }
        public override void Move(GameTime gameTime)
        {
            //Checking X Range
            if (Game1.playerInstance.pos.X > pos.X)
            {
                if (Game1.playerInstance.pos.X - 200 < pos.X)
                {
                    direction = new Vector2(0, 0);
                }
                else
                {
                    direction = new Vector2(1, 0);
                }

            }
            if (Game1.playerInstance.pos.X < pos.X)
            {
                if (Game1.playerInstance.pos.X + 200 > pos.X)
                {
                    direction = new Vector2(0, 0);
                }
                else
                {
                    direction = new Vector2(-1, 0);
                }

            }

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            pos += ((direction * spd) * deltaTime);

            //Checking Y Range
            if (Game1.playerInstance.pos.Y > pos.Y)
            {
                if (Game1.playerInstance.pos.Y - 200 < pos.Y)
                {
                    direction = new Vector2(0, 0);
                }

                else
                {
                    direction = new Vector2(0, 1);
                }

            }
            if (Game1.playerInstance.pos.Y < pos.Y)
            {
                if (Game1.playerInstance.pos.Y + 200 > pos.Y)
                {
                    direction = new Vector2(0, 0);
                }
                else
                {
                    direction = new Vector2(0, -1);
                }

            }

            //Concludes Movement

            pos += ((direction * spd) * deltaTime);

        }
        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("Bad Guy 1");
        }

        public override void OnCollision(Unit other)
        {

            if (other is Enemy && other.pos.X < this.pos.X)
            {
                pos.X += 10;
            }
            if (other is Enemy && other.pos.Y < this.pos.Y)
            {
                pos.Y += 10;
            }

        }
    }
}
