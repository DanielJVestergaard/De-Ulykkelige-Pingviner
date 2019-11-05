using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoTDRPG
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    class GameWorld : Game
    {
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        static public Player playerInstance;
        static public List<Projectile> activeProjectiles = new List<Projectile>();
        List<Unit> list = new List<Unit>();
        static public List<Enemy> listEnemy = new List<Enemy>();
        float respawntimer;
        Texture2D collisionTexture;
        Texture2D backGround;
        static public Texture2D projectileB;

        //Spawn Settings
        public int spawnCount = 0;
        public int spawnAmount = 5;
        Random random = new Random();

        public GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 800;

        }
        protected override void Initialize()
        {
            playerInstance = new Player(100, 60, 0, new Vector2(500, 400));
            list.Add(playerInstance);
            base.Initialize();
        }
        protected override void LoadContent()
        {
            collisionTexture = Content.Load<Texture2D>("OnePixel");
            backGround = Content.Load<Texture2D>("Need To Have");
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            foreach (Unit go in list)
            {
                go.LoadContent(Content);
            }
            foreach (Projectile a in activeProjectiles)
            {
                a.LoadContent(Content);
            }
            projectileB = Content.Load<Texture2D>("Bullet");
        }
        private void DrawCollisionBox(Unit go)
        {
            Rectangle collisionBox = go.CollisionBox;
            Rectangle topLine = new Rectangle(collisionBox.X, collisionBox.Y, collisionBox.Width, 1);
            Rectangle bottomLine = new Rectangle(collisionBox.X, collisionBox.Y + collisionBox.Height, collisionBox.Width, 1);
            Rectangle rightLine = new Rectangle(collisionBox.X + collisionBox.Width, collisionBox.Y, 1, collisionBox.Height);
            Rectangle leftLine = new Rectangle(collisionBox.X, collisionBox.Y, 1, collisionBox.Height);
            

            spriteBatch.Draw(collisionTexture, topLine, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, bottomLine, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, rightLine, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, leftLine, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 1);
        }
        private void DrawCollisionBoxP(Projectile p)
        {
            Rectangle collisionBox = p.CollisionBox;
            Rectangle topLine = new Rectangle(collisionBox.X, collisionBox.Y, collisionBox.Width, 1);
            Rectangle bottomLine = new Rectangle(collisionBox.X, collisionBox.Y + collisionBox.Height, collisionBox.Width, 1);
            Rectangle rightLine = new Rectangle(collisionBox.X + collisionBox.Width, collisionBox.Y, 1, collisionBox.Height);
            Rectangle leftLine = new Rectangle(collisionBox.X, collisionBox.Y, 1, collisionBox.Height);


            spriteBatch.Draw(collisionTexture, topLine, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, bottomLine, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, rightLine, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, leftLine, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 1);
        }
        protected override void UnloadContent()
        {

        }
        public void Spawn()
        {
            Enemy newEnemy = new Enemy("Brian",100,0, new Pistol(10), new Vector2(random.Next(999),random.Next(799)));
            listEnemy.Add(newEnemy);
            list.Add(newEnemy);
            newEnemy.LoadContent(Content);
            foreach (Enemy go in listEnemy)
            {
                go.LoadContent(Content);
            }
        }
        protected override void Update(GameTime gameTime)
        {
            if (listEnemy.Count == 0)
            {
                NewRound();
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (spawnCount != spawnAmount)
            {
                //Spawn();
                //spawnCount++;

                respawntimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (respawntimer > 0.05f)
                {
                    respawntimer = 0f;
                    Spawn();
                    spawnCount++;
                }
            }

            foreach (Unit go in list)
            {
                go.Update(gameTime);
                foreach (Unit other in list)
                {
                    go.CheckCollision(other);
                }
            }
            foreach (Projectile go in activeProjectiles)
            {
                go.Update(gameTime);
                foreach (Unit other in list)
                {
                    go.CheckCollision(other);
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AliceBlue);
            Rectangle backGroundR = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            
            spriteBatch.Begin();
            spriteBatch.Draw(backGround, backGroundR, Color.AliceBlue);
            foreach (Unit go in list)
            {
                go.Draw(spriteBatch);
                DrawCollisionBox(go);

                // go.Update(gameTime);
            }
            foreach (Projectile go in activeProjectiles)
            {
                go.Draw(spriteBatch);
                DrawCollisionBoxP(go);
                // go.Update(gameTime);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
        public void NewRound()
        {

        }
    
    }
}
