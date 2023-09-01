using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SpriteExample
{
    /// <summary>
    /// A class representing a slime ghost
    /// </summary>
    public class PaddleSprite
    {


        private Texture2D texture;

        private double rotation;
     

        private Vector2 position = new Vector2(400, 300);

        /// <summary>
        /// Loads the sprite texture using the provided ContentManager
        /// </summary>
        /// <param name="content">The ContentManager to load with</param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("paddle");
        }

        /// <summary>
        /// Updates the sprite's position based on user input
        /// </summary>
        /// <param name="gameTime">The GameTime</param>
        public void Update(GameTime gameTime)
        {

            rotation += gameTime.ElapsedGameTime.TotalSeconds*2;
        }

        /// <summary>
        /// Draws the sprite using the supplied SpriteBatch
        /// </summary>
        /// <param name="gameTime">The game time</param>
        /// <param name="spriteBatch">The spritebatch to render with</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            
            spriteBatch.Draw(texture, position, null, Color.White, (float)rotation, new Vector2(0, 16), 4.0f, SpriteEffects.None, 0);
        }
    }
}
