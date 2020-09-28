using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace AI_Disolution.Code
{
    abstract class Entity {

        public Texture2D Texture;

        public Vector2 Origin;
        public Vector2 Position;
        public Vector2 Direction;
        public Vector2 Velocity;
        public Input Input;
        /*public Collision Collision;*/

        public float Speed = 4f;
        public float LifeSpan = 0f;
        public bool IsRemoved = false;

        public static Dictionary<Type, List<Entity>> EntityDictionary = new Dictionary<Type, List<Entity>>();
        public static readonly List<Entity> Entities = new List<Entity>();
        public static readonly List<Entity> EntitiesToRemove = new List<Entity>();
        public enum Side { None = 0, Left = 1, Right = 2, Top = 3, Bottom = 4 }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            }
        }

        public static void Add(Entity entity)
        {
            Entities.Add(entity);

            if (!EntityDictionary.ContainsKey(entity.GetType()))
                EntityDictionary.Add(entity.GetType(), Entities);
        }

        private static void Remove(Entity entity) => Entities.Remove(entity);

        public static IEnumerable<Entity> Get()
        {
            foreach (var v in Entities.ToArray())
                yield return v;

            foreach (var entity in EntitiesToRemove.ToArray())
                Remove(entity);
            yield break;
        }

        public Entity(Texture2D texture)
        {
            Texture = texture;

            // Sets the position of the Origin to the middle of the texture.
            Origin = new Vector2(texture.Width / 2, texture.Height / 2);
            /*Collision = new Collision(Texture, Position, Velocity);*/
        }

        public virtual void Update(GameTime gameTime) { }

        public abstract object Clone();

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, 0f, Origin, 1, SpriteEffects.None, 0);
        }

        #region Collision
        protected bool IsTouchingLeft(Rectangle otherRect)
        {
            return this.Rectangle.Right + this.Velocity.X > otherRect.Left &&
                this.Rectangle.Left < otherRect.Left &&
                this.Rectangle.Bottom > otherRect.Top &&
                this.Rectangle.Top < otherRect.Bottom;
        }

        protected bool IsTouchingRight(Rectangle otherRect)
        {
            return this.Rectangle.Left + this.Velocity.X < otherRect.Right &&
                this.Rectangle.Right > otherRect.Right &&
                this.Rectangle.Bottom > otherRect.Top &&
                this.Rectangle.Top < otherRect.Bottom;
        }

        protected bool IsTouchingTop(Rectangle otherRect)
        {
            return this.Rectangle.Bottom + this.Velocity.Y > otherRect.Top &&
                this.Rectangle.Top < otherRect.Top &&
                this.Rectangle.Right > otherRect.Left &&
                this.Rectangle.Left < otherRect.Right;
        }

        protected bool IsTouchingBottom(Rectangle otherRect)
        {
            return this.Rectangle.Top + this.Velocity.Y < otherRect.Bottom &&
                this.Rectangle.Bottom > otherRect.Bottom &&
                this.Rectangle.Right > otherRect.Left &&
                this.Rectangle.Left < otherRect.Right;
        }
        #endregion

    }
}
