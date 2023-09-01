using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace SpriteExample
{
    /// <summary>
    /// A game demonstrating the use of sprites
    /// </summary>
    public class GameProject : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private PaddleSprite paddleSprite;
        private Texture2D atlas;
        private BallSprite[] eyes;
        private SpriteFont bangers;
        private SpriteFont bangersSmall;
        private SuperBallSprite[] balls;


        /// <summary>
        /// Constructs the game
        /// </summary>
        public GameProject()
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
            paddleSprite = new PaddleSprite();
            eyes = new BallSprite[10];
            balls = new SuperBallSprite[8];
            for (int i = 0; i < 8; i++)
            {
                Random r = new Random();
                balls[i] = new SuperBallSprite();
                balls[i].Velocity = new Vector2((float)((r.NextDouble() * 10)-5), (float)((r.NextDouble() * 10) - 5));
                balls[i].Position = new Vector2((float)((r.NextDouble() * 650) - 5), (float)((r.NextDouble() * 450) - 5));
            }
            

            for (int i = 0; i < 10; i++)
            {
                Random r = new Random();
              
                


                eyes[i] = new BallSprite() { Position = new Vector2((float)r.NextDouble() * 800, (float)r.NextDouble() * 400), animationFrame = (short)r.Next(0,8)};
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
            paddleSprite.LoadContent(Content);
            foreach (var ball in balls) ball.LoadContent(Content);
            atlas = Content.Load<Texture2D>("colored_packed");
            foreach (var eye in eyes) eye.LoadContent(Content);

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
            paddleSprite.Update(gameTime);
            foreach (var ball in balls) ball.Update(gameTime);
            foreach (var eye in eyes) eye.Update(gameTime);
            base.Update(gameTime);
        }

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
            for (int temp1 = 0; temp1 < 20; temp1++)
            {
                for (int temp2 = 0; temp2 < 10; temp2++)
                {

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            spriteBatch.Draw(atlas, new Vector2(temp1*48+(i * 16), temp2*48+(j * 16)), new Rectangle(i * 16, 256 + j * 16, 16, 16), Color.White);
                        }


                    }
                }
            }
            foreach (var eye in eyes) eye.Draw(gameTime, spriteBatch);
            paddleSprite.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(bangers, "Paddle ball!", new Vector2(200, 1), Color.Gold);
            foreach (var ball in balls) ball.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(bangers, "press ESC to exit!", new Vector2(100, 400), Color.Red);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
