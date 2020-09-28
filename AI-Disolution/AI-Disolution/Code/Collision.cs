using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace AI_Disolution.Code {
    public class Collision {

        public Texture2D Texture;
        public Vector2 Position;
        public Vector2 Velocity;
        

        public enum Side { None = 0, Left = 1, Right = 2, Top = 3, Bottom = 4}

        public Collision(Texture2D texture, Vector2 position, Vector2 velocity)
        {
            Texture = texture;
            Position = position;
            Velocity = velocity;
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            }
        }

        /// <summary>
        /// Gets the side of the object intersecting another object.
        /// </summary>
        /// <param name="rectOne">Rectangle one</param>
        /// <param name="rectTwo">Rectangle two</param>
        /// <returns></returns>
        public Enum GetSide(Rectangle rectOne, Rectangle rectTwo)
        {
            if (IsTouchingLeft(rectOne, rectTwo))
                return Side.Left;

            if (IsTouchingRight(rectOne, rectTwo))
                return Side.Right;

            if (IsTouchingTop(rectOne, rectTwo))
                return Side.Top;

            if (IsTouchingBottom(rectOne, rectTwo))
                return Side.Bottom;

            return Side.None;
        }

        private bool IsTouchingLeft(Rectangle rectOne, Rectangle otherRect)
        {
            return rectOne.Right + Velocity.X > otherRect.Left &&
                rectOne.Left < otherRect.Left &&
                rectOne.Bottom > otherRect.Top &&
                rectOne.Top < otherRect.Bottom;
        }

        private bool IsTouchingRight(Rectangle rectOne, Rectangle otherRect)
        {
            return rectOne.Left + Velocity.X < otherRect.Right &&
                rectOne.Right > otherRect.Right &&
                rectOne.Bottom > otherRect.Top &&
                rectOne.Top < otherRect.Bottom;
        }

        private bool IsTouchingTop(Rectangle rectOne, Rectangle otherRect)
        {
            return rectOne.Bottom + Velocity.Y > otherRect.Top &&
                rectOne.Top < otherRect.Top &&
                rectOne.Right > otherRect.Left &&
                rectOne.Left < otherRect.Right;
        }

        private bool IsTouchingBottom(Rectangle rectOne, Rectangle otherRect)
        {
            return rectOne.Top + Velocity.Y < otherRect.Bottom &&
                rectOne.Bottom > otherRect.Bottom &&
                rectOne.Right > otherRect.Left &&
                rectOne.Left < otherRect.Right;
        }
    }
}
