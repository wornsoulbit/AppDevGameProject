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

        public bool IsTouchingLeft(Rectangle otherRect)
        {
            return this.Rectangle.Right + this.Velocity.X > otherRect.Left &&
                this.Rectangle.Left < otherRect.Left &&
                this.Rectangle.Bottom > otherRect.Top &&
                this.Rectangle.Top < otherRect.Bottom;
        }

        public bool IsTouchingRight(Rectangle otherRect)
        {
            return this.Rectangle.Left + this.Velocity.X < otherRect.Right &&
                this.Rectangle.Right > otherRect.Right &&
                this.Rectangle.Bottom > otherRect.Top &&
                this.Rectangle.Top < otherRect.Bottom;
        }

        public bool IsTouchingTop(Rectangle otherRect)
        {
            return this.Rectangle.Bottom + this.Velocity.Y > otherRect.Top &&
                this.Rectangle.Top < otherRect.Top &&
                this.Rectangle.Right > otherRect.Left &&
                this.Rectangle.Left < otherRect.Right;
        }

        public bool IsTouchingBottom(Rectangle otherRect)
        {
            return this.Rectangle.Top + this.Velocity.Y < otherRect.Bottom &&
                this.Rectangle.Bottom > otherRect.Bottom &&
                this.Rectangle.Right > otherRect.Left &&
                this.Rectangle.Left < otherRect.Right;
        }
    }
}
