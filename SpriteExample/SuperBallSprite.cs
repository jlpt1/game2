using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;


using System.Text;

namespace SpriteExample
{

    /// <summary>
    /// A class representing a bat sprite
    /// </summary>
    public class SuperBallSprite
    {
        private Texture2D texture;

        private double animationTimer;

        

        public short animationFrame;

        /// <summary>
        /// Position of the Ball
        /// </summary>
        public Vector2 Position;

        public Vector2 Velocity;

  

        /// <summary>
        /// Loads the bat sprite texture
        /// </summary>
        /// <param name="content">The content manager ot load with</param>
        public void LoadContent(ContentManager content)
        {
            Random r = new Random();

            if (r.NextDouble() > 0.5f)
            {
                texture = content.Load<Texture2D>("greenball");
            }
            else
            {
                texture = content.Load<Texture2D>("basketball");
            }

        }
        /// <summary>
        /// Updates the bat sprite to fly in a pattern
        /// </summary>
        /// <param name="gameTime"> Game time</param>
        public void Update(GameTime gameTime)
        {
            Position += Velocity;
            if (Position.X > 800 - 32)
            {
                Velocity.X = -Velocity.X;
            }
            if (Position.X < 0)
            {
                Velocity.X = -Velocity.X;
            }
            if (Position.Y < 0)
            {
                Velocity.Y = -Velocity.Y;
            }
            if (Position.Y > 480 - 32)
            {
                Velocity.Y = -Velocity.Y;
            }
        }

        /// <summary>
        /// Drfaws the animated bat sprite
        /// </summary>
        /// <param name="gameTime">The game time</param>
        /// <param name="spriteBatch">The SpriteBatch to draw with</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //Update animation timer
        
            //Draw the sprite
            var source = new Rectangle(0, 0, 32, 32);
            spriteBatch.Draw(texture, Position, source, Color.White);
        }
        



    }
}
