using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace AI_Disolution.Code
{
    /// <summary>
    /// Big thanks to Dcrew from discord.gg/MNj28aV (Monogame discord) for a baseline
    /// system that works great with what I wanted to do.
    /// </summary>
    /// <typeparam name="T"> Anything that may be an Entity, E.G. Player, Enemies, Bullet, etc.</typeparam>
    abstract class Entity<T> where T : Entity<T> {

        public Texture2D Texture;

        public Vector2 Origin;
        public Vector2 Position;
        public Vector2 Direction;
        public Vector2 Velocity;
        public Input Input;
        public Collision Collision;

        public float Speed = 4f;
        public float LifeSpan = 0f;
        public bool IsRemoved = false;

        public static readonly List<Entity<T>> Entities = new List<Entity<T>>();
        public static readonly List<Entity<T>> EntitiesToRemove = new List<Entity<T>>();

        /// <summary>
        /// Adds a given entity to the List.
        /// </summary>
        /// <param name="entity"> Anything that may be an Entity.</param>
        public static void Add(T entity) => Entities.Add(entity);
        private static void Remove(T entity) => Entities.Remove(entity);

        public Entity(Texture2D texture)
        {
            Texture = texture;

            // Sets the position of the Origin to the middle of the texture.
            Origin = new Vector2(texture.Width / 2, texture.Height / 2);
            Collision = new Collision(Texture, Position, Velocity);
        }

        // Thanks again to Dcrew for this baseline code.
        public static IEnumerable<T> Get()
        {
            foreach (var s in Entities)
                yield return (T)s;

            // Removes the entity after going through the list, to avoid a null point in the list.
            foreach (var entity in EntitiesToRemove)
                Remove((T)entity);
            yield break;
        }

        public abstract T Clone();

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, 0f, Origin, 1, SpriteEffects.None, 0);
        }

    }
}
