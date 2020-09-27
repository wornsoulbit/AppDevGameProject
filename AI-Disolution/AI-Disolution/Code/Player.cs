using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace AI_Disolution.Code {
    class Player : Entity<Player> {

        private MouseState prevMouseState;
        private MouseState currMouseState;
        private KeyboardState currentKey;

        public Player(Texture2D texture) : base(texture) { }
        public override Player Clone() => new Player(Texture) { };

        public void Update(GameTime gameTime)
        {
            EntityCollision();
            PlayerControls();

            Position += Velocity;
            Velocity = Vector2.Zero;
        }

        private void PlayerControls()
        {
            prevMouseState = currMouseState;
            currMouseState = Mouse.GetState();
            currentKey = Keyboard.GetState();

            //Calculates the position of the mouse relative to the player.
            Direction = new Vector2(currMouseState.Position.X - this.Position.X, currMouseState.Position.Y - this.Position.Y);
            if (Direction != Vector2.Zero)
                Direction.Normalize();

            if (currentKey.IsKeyDown(Input.Up))
                Velocity.Y = -Speed;
            if (currentKey.IsKeyDown(Input.Down))
                Velocity.Y = Speed;
            if (currentKey.IsKeyDown(Input.Left))
                Velocity.X = -Speed;
            if (currentKey.IsKeyDown(Input.Right))
                Velocity.X = Speed;
        }

        private void EntityCollision()
        {
            foreach (var entity in Entities)
            {
                if (this.Velocity.X > 0 && this.Collision.IsTouchingLeft(entity.Collision.Rectangle) ||
                    this.Velocity.X < 0 && this.Collision.IsTouchingRight(entity.Collision.Rectangle))
                    this.Velocity.X = 0;

                if (this.Velocity.Y > 0 && this.Collision.IsTouchingTop(entity.Collision.Rectangle) ||
                    this.Velocity.Y < 0 && this.Collision.IsTouchingBottom(entity.Collision.Rectangle))
                    this.Velocity.Y = 0;
            }
        }
    }
}
