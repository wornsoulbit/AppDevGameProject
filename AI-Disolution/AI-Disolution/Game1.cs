using AI_Disolution.Code;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AI_Disolution {
    public class Game1 : Game {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var playerTexture = Content.Load<Texture2D>("Player");
            var enemyTexture = Content.Load<Texture2D>("Enemy");
            var bulletTexture = Content.Load<Texture2D>("Bullet");

            Entity.Add(new Player(playerTexture)
            {
                Bullet = new Bullet(bulletTexture),
                Position = new Vector2(100, 100),
                Input = new Input
                {
                    Up = Keys.W,
                    Down = Keys.S,
                    Left = Keys.A,
                    Right = Keys.D
                },
            });

            Entity.Add(new Player(playerTexture)
            {
                Bullet = new Bullet(bulletTexture),
                Position = new Vector2(200, 100),
                Input = new Input
                {
                    Up = Keys.Up,
                    Down = Keys.Down,
                    Left = Keys.Left,
                    Right = Keys.Right
                },
            });

            Entity.Add(new Enemy(enemyTexture)
            {
                Bullet = new Bullet(bulletTexture),
                Position = new Vector2(100, 200),
            });

            Entity.Add(new Enemy(enemyTexture)
            {
                Bullet = new Bullet(bulletTexture),
                Position = new Vector2(300, 100),
            });
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (var v in Entity.Get())
            {
                v.Update(gameTime);
                if (v.IsRemoved)
                    Entity.EntitiesToRemove.Add(v);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            foreach (var v in Entity.Get())
                v.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
