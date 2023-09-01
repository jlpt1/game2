using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;


using System.Text;

namespace SpriteExample
{
    public enum Direction
    {
        Down = 0,
        Right = 1,
        Up = 2,
        Left = 3,

    }
    /// <summary>
    /// A class representing a bat sprite
    /// </summary>
    public class BallSprite
    {
        private Texture2D texture;

        private double animationTimer;

        

        public short animationFrame;

        /// <summary>
        /// Position of the Ball
        /// </summary>
        public Vector2 Position;

  

        /// <summary>
        /// Loads the bat sprite texture
        /// </summary>
        /// <param name="content">The content manager ot load with</param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("ball3");
           
    }
        /// <summary>
        /// Updates the bat sprite to fly in a pattern
        /// </summary>
        /// <param name="gameTime"> Game time</param>
        public void Update(GameTime gameTime)
        {  

        }

        /// <summary>
        /// Drfaws the animated bat sprite
        /// </summary>
        /// <param name="gameTime">The game time</param>
        /// <param name="spriteBatch">The SpriteBatch to draw with</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //Update animation timer
            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;
            //Update animation frame
            if (animationTimer > 0.1)
            {
                animationFrame++;
                if (animationFrame > 8) animationFrame = 0;
                animationTimer -= 0.1;
            }

            //Draw the sprite
            var source = new Rectangle(animationFrame*32, 0, 32, 32);
            spriteBatch.Draw(texture, Position, source, Color.White);
        }
        



    }
}
