using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace AI_Disolution.Code {
    class Bullet : Entity<Bullet> {

        private float timer;

        public Bullet(Texture2D texture) : base(texture)
        {

        }

        public override Bullet Clone() => new Bullet(Texture)
        {

        };

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer > LifeSpan)
                IsRemoved = true;


            Velocity = Direction * Speed;
            Position += Direction * Speed;
        }
    }
}
