using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace AI_Disolution.Code {
    class Player : Entity<Player> {

        private MouseState currentMouseState;
        private MouseState previousMouseState;
        private KeyboardState currentKey;

        public Bullet Bullet;

        public Player(Texture2D texture) : base(texture) { }

        public void Update(GameTime gameTime)
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

            Entity<Bullet>.Add(bullet);
        }

        private void EntityCollision()
        {

            Collision.Position = this.Position;
            Collision.Velocity = this.Velocity;
            Collision.Texture = this.Texture;

            foreach (var entity in Entities)
            {
                if (entity == this)
                    continue;

                Enum side = Collision.GetSide(this.Collision.Rectangle, entity.Collision.Rectangle);

                if (Velocity.X > 0 && side.Equals(Collision.Side.Left) || Velocity.X < 0 && side.Equals(Collision.Side.Right))
                    Velocity.X = 0;

                if (Velocity.Y > 0 && side.Equals(Collision.Side.Top) || Velocity.Y < 0 && side.Equals(Collision.Side.Bottom))
                    Velocity.Y = 0;

            }
        }

        public override Player Clone() => new Player(Texture)
        {

        };
    }
}
