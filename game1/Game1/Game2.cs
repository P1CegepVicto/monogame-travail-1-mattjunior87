using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game2 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Rectangle fenetre;
        GameObject heros;
        GameObject PinkPoney;
        GameObject deadpool;
        GameObject Background;


        public Game2()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.graphics.PreferredBackBufferWidth = graphics.GraphicsDevice.DisplayMode.Width;
            this.graphics.PreferredBackBufferHeight = graphics.GraphicsDevice.DisplayMode.Height;
            this.graphics.ApplyChanges();
            fenetre = new Rectangle(0, 0, graphics.GraphicsDevice.DisplayMode.Width, graphics.GraphicsDevice.DisplayMode.Height);
            //ToggleFullScreen = mode plein ecran sans bordure
            //ApplyChange = Mode plein écran avec la barre de titres windows

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            PinkPoney = new GameObject();
            PinkPoney.estVivant = true;
            PinkPoney.position.X = 0;
            PinkPoney.position.Y = 0;
            PinkPoney.sprite = Content.Load<Texture2D>("PinkPoney.png");

            deadpool = new GameObject();
            deadpool.estVivant = true;
            deadpool.position.X = 0;
            deadpool.position.Y = 0;
            deadpool.sprite = Content.Load<Texture2D>("deadpool.png");


            Background = new GameObject();
            Background.sprite = Content.Load<Texture2D>("IMG_209847.png");


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                deadpool.position.X += deadpool.vitesse;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                deadpool.position.X -= deadpool.vitesse;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.w))
            {
                deadpool.position.Y += deadpool.vitesse;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                deadpool.position.Y -= deadpool.vitesse;
            }




            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            spriteBatch.Begin();

            spriteBatch.Draw(Background.sprite, fenetre, Color.White);
            spriteBatch.Draw(deadpool.sprite, deadpool.position, Color.White);
            spriteBatch.Draw(PinkPoney.sprite, PinkPoney.position, Color.White);

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}

