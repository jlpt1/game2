﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollisionExample.Collisions
{
    public static class CollisionHelper
    {

        /// <summary>
        /// Detects a collision between two BoundingCircles
        /// </summary>
        /// <param name="a">The first boudning circle</param>
        /// <param name="b">The second bounding circle</param>
        /// <returns>returns true for collision false for not colliding</returns>
        public static bool Collides(BoundingCircle a, BoundingCircle b)
        {
            return Math.Pow(a.Radius + b.Radius,2) >= Math.Pow(a.Center.X - b.Center.X, 2) + Math.Pow(a.Center.Y - b.Center.Y , 2);
        }

        /// <summary>
        /// Detects a collision between two BoundingRectangles
        /// </summary>
        /// <param name="a">The first rectangle</param>
        /// <param name="b">The second rectangle</param>
        /// <returns>True for collision false for not</returns>
        public static bool Collides(BoundingRectangle a, BoundingRectangle b)
        {
            return !(a.Right < b.Left || a.Left > b.Right
                ||   a.Top > b.Bottom || a.Bottom < b.Top);
        }

        /// <summary>
        /// Detects a collision between a rectangle and a circle
        /// </summary>
        /// <param name="c">The BoundingCircle</param>
        /// <param name="r">the BoundingRectangle</param>
        /// <returns>True for collision else false</returns>
        public static bool Collides(BoundingCircle c, BoundingRectangle r)
        {
            float nearestX = MathHelper.Clamp(c.Center.X, r.Left, r.Right);
            float nearestY = MathHelper.Clamp(c.Center.Y, r.Top, r.Bottom);
            return Math.Pow(c.Radius,2) >= Math.Pow(c.Center.X - nearestX, 2) + Math.Pow(c.Center.Y - nearestY, 2);
        }
    }
}
