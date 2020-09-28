using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace AI_Disolution.Code {
    class Player : Entity {

        private MouseState currentMouseState;
        private MouseState previousMouseState;
        private KeyboardState currentKey;

        public Bullet Bullet;

        public Player(Texture2D texture) : base(texture) { }

        public override void Update(GameTime gameTime)
        {
            PlayerControls();
            EntityCollision();

            Position += Velocity;
            Velocity = Vector2.Zero;
        }

        private void PlayerControls()
        {
            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
            currentKey = Keyboard.GetState();

            //Calculates the position of the mouse relative to the player.
            Direction = new Vector2(currentMouseState.Position.X - this.Position.X, currentMouseState.Position.Y - this.Position.Y);
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

            if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
            {
                AddBullet();
            }
        }

        private void AddBullet()
        {
            var bullet = Bullet.Clone() as Bullet;
            bullet.Direction = this.Direction;
            bullet.Position = this.Position;
            bullet.Speed = this.Speed;

            if (this.LifeSpan == 0f)
                bullet.LifeSpan = 2f;
            else
                bullet.LifeSpan = this.LifeSpan;

            Add(bullet);
        }

        private void EntityCollision()
        {

            foreach (var entity in Entities)
            {

                if (entity == this)
                    continue;

                if (Velocity.X > 0 && IsTouchingLeft(entity.Rectangle) ||
                    Velocity.X < 0 && IsTouchingRight(entity.Rectangle))
                    Velocity.X = 0;

                if (Velocity.Y > 0 && IsTouchingTop(entity.Rectangle) ||
                    Velocity.Y < 0 && IsTouchingBottom(entity.Rectangle))
                    Velocity.Y = 0;
            }

            /*foreach (var entity in EntityDictionary[typeof(Enemy)])
            {

                if (Velocity.X > 0 && IsTouchingLeft(entity.Rectangle) ||
                    Velocity.X < 0 && IsTouchingRight(entity.Rectangle))
                    Velocity.X = 0;

                if (Velocity.Y > 0 && IsTouchingTop(entity.Rectangle) ||
                    Velocity.Y < 0 && IsTouchingBottom(entity.Rectangle))
                    Velocity.Y = 0;
            }*/
        }

        public override object Clone() => new Player(Texture)
        {

        };
    }
}
