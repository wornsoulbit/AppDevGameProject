using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace AI_Disolution.Code {
    class Bullet : Entity {

        private float timer;

        public Bullet(Texture2D texture) : base(texture)
        {

        }

        public override object Clone() => new Bullet(Texture)
        {

        };

        public override void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer > LifeSpan)
                IsRemoved = true;

            Collisions();

            Velocity = Direction * Speed;
            Position += Direction * Speed;
        }

        private void Collisions()
        {
            /*foreach (var entity in EntityDictionary[typeof(Bullet)])
            {

                Enum side = Collision.GetSide(this.Collision.Rectangle, entity.Collision.Rectangle);

                if (Velocity.X > 0 && side.Equals(Collision.Side.Left) || Velocity.X < 0 && side.Equals(Collision.Side.Right))
                    this.IsRemoved = true;

                if (Velocity.Y > 0 && side.Equals(Collision.Side.Top) || Velocity.Y < 0 && side.Equals(Collision.Side.Bottom))
                    this.IsRemoved = true;

            }

            foreach (var entity in EntityDictionary[typeof(Enemy)])
            {
                Enum side = Collision.GetSide(this.Collision.Rectangle, entity.Collision.Rectangle);

                if (Velocity.X > 0 && side.Equals(Collision.Side.Left) || Velocity.X < 0 && side.Equals(Collision.Side.Right))
                    this.IsRemoved = true;

                if (Velocity.Y > 0 && side.Equals(Collision.Side.Top) || Velocity.Y < 0 && side.Equals(Collision.Side.Bottom))
                    this.IsRemoved = true;
            }*/
        }
    }
}
