using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace AI_Disolution.Code {
    class Enemy : Entity {

        public Bullet Bullet;

        public float timer;
        public float BulletTimer = 2f;

        public Enemy(Texture2D texture) : base(texture) { }

        public override void Update(GameTime gameTime)
        {

            Direction = new Vector2(EntityDictionary[typeof(Player)][0].Position.X - this.Position.X, EntityDictionary[typeof(Player)][0].Position.Y - this.Position.Y);
            if (Direction != Vector2.Zero)
                Direction.Normalize();

            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer > BulletTimer)
            {
                /*AddBullet();*/
                timer = 0f;
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

        public override object Clone() => new Enemy(Texture);
    }
}
