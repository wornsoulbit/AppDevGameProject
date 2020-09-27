using Microsoft.Xna.Framework;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppDevGame.Game {
    class Player {
        private Animation leftAnimation;
        private Animation rightAnimation;
        private Animation frontAnimation;
        private Animation backAnimation;
        private AnimationPlayer sprite;

        public bool IsALive
        {
            get { return isALive; }
        }
        bool isALive;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        Vector2 position;

        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }
        Vector2 velocity;

        private float movement;

        public Rectangle localBounds;
        public Rectangle BoundingRectangle
        {
            get
            {
                int left = (int)Math.Round(Position.X - sprite.Origin.Y) + localBounds.X;
                int top = (int)Math.Round(Position.Y - sprite.Origin.X) + localBounds.Y;

                return new Rectangle(left, top, localBounds.Width, localBounds.Height);
            }
        }
    }
}
