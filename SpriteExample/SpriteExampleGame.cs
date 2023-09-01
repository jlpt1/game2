using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace SpriteExample
{
    /// <summary>
    /// A game demonstrating the use of sprites
    /// </summary>
    public class SpriteExampleGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private PaddleSprite slimeGhost;
        private Texture2D atlas;
        private BallSprite[] balls;
        private SpriteFont bangers;
        private SpriteFont bangersSmall;


        /// <summary>
        /// Constructs the game
        /// </summary>
        public SpriteExampleGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Initializes the game
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            slimeGhost = new PaddleSprite();
            balls = new BallSprite[10];

            for (int i = 0; i < 10; i++)
            {
                Random r = new Random();
              
                


                balls[i] = new BallSprite() { Position = new Vector2((float)r.NextDouble() * 800, (float)r.NextDouble() * 400), animationFrame = (short)r.Next(0,8)};
            }
          
            base.Initialize();
        }

        /// <summary>
        /// Loads game content
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            slimeGhost.LoadContent(Content);
            atlas = Content.Load<Texture2D>("colored_packed");
            foreach (var bat in balls) bat.LoadContent(Content);

            bangers = Content.Load<SpriteFont>("bangers");
            bangersSmall = Content.Load<SpriteFont>("bangers2");
        }

        /// <summary>
        /// Updates the game world
        /// </summary>
        /// <param name="gameTime">the measured game time</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            slimeGhost.Update(gameTime);
            foreach (var bat in balls) bat.Update(gameTime);
            base.Update(gameTime);
        }
        private int i = 0;
        /// <summary>
        /// Draws the game world
        /// </summary>
        /// <param name="gameTime">the measured game time</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            bangers.MeasureString("This is a string to measure");
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            
            spriteBatch.Draw(atlas, new Vector2(50, 50), new Rectangle(i*16, 16, 16, 16), Color.White);
            i++;
            foreach (var bat in balls) bat.Draw(gameTime, spriteBatch);
            slimeGhost.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(bangers, "Paddle ball!", new Vector2(200, 50), Color.Gold);

            spriteBatch.DrawString(bangersSmall, "press ESC to exit!", new Vector2(250, 400), Color.Red);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
