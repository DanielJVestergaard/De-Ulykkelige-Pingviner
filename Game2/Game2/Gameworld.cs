using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Gameworld : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<GameObject> list = new List<GameObject>();
        List<GameObject> listEnemy = new List<GameObject>();
        float respawntimer;
        Texture2D collisionTexture;

        //Spawn Settings
        public int spawnCount = 0;
        public int spawnAmount = 5;

        public Gameworld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 800;
        }
        protected override void Initialize()
        {
            list.Add(new Player());
            base.Initialize();
        }
        protected override void LoadContent()
        {
            collisionTexture = Content.Load<Texture2D>("OnePixel");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            foreach (GameObject go in list)
            {
                go.LoadContent(Content);
            }
        }
        private void DrawCollisionBox(GameObject go)
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
        protected override void UnloadContent()
        {

        }
        public void Spawn()
        {
            Enemy newEnemy = new Enemy();
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

            foreach (GameObject go in list)
            {
                go.Update(gameTime);
                foreach (GameObject other in list)
                {
                    go.CheckCollision(other);
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            foreach (GameObject go in list)
            {
                go.Draw(spriteBatch);
#if DEBUG
                DrawCollisionBox(go);
#endif
                // go.Update(gameTime);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
