using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

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
        GameObject fin;
        GameObject PinkPoney;
        GameObject deadpool;
        GameObject Background;
        GameObject caca;


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
            this.graphics.ToggleFullScreen();
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
            PinkPoney.position.X = 540;
            PinkPoney.position.Y = 0;
            PinkPoney.vitesse.X = 4;
            PinkPoney.sprite = Content.Load<Texture2D>("PinkPoney.png");

            deadpool = new GameObject();
            deadpool.estVivant = true;
            deadpool.position.X = +1024;
            deadpool.position.Y = +1100;
            deadpool.sprite = Content.Load<Texture2D>("deadpool.png");


            Background = new GameObject();
            Background.sprite = Content.Load<Texture2D>("IMG_209847.png");

            caca = new GameObject();
            caca.estVivant = true;
            caca.position.X = PinkPoney.position.X;
            caca.position.Y = PinkPoney.position.Y;
            caca.vitesse.Y = 15;
            caca.sprite = Content.Load<Texture2D>("Caca.png");

            fin = new GameObject();
            fin.position.X = -200;
            fin.sprite = Content.Load<Texture2D>("fin.jpg");

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
                deadpool.position.X += 7;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                deadpool.position.X -= 7;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                deadpool.position.Y -= 7;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                deadpool.position.Y += 7;
            }

            if (deadpool.position.X < fenetre.Left)
            {
                deadpool.position.X = fenetre.Left;
            }
            if (deadpool.position.X > fenetre.Right - 87)
            {
                deadpool.position.X = fenetre.Right - 87;
            }
            if (deadpool.position.Y < fenetre.Top)
            {
                deadpool.position.Y = fenetre.Top;
            }
            if (deadpool.position.Y > fenetre.Bottom - 200)
            {
                deadpool.position.Y = fenetre.Bottom - 200;
            }



           
            Updatedeapool();
            UpdatePinkPoney();
            Updatecaca();

            base.Update(gameTime);
            
        }

        public void UpdatePinkPoney()
        {
            if (PinkPoney.position.X > fenetre.Right - 230)
            {
                PinkPoney.vitesse.X = -5;
            }
            if (PinkPoney.position.X < fenetre.Left)
            {
                PinkPoney.vitesse.X = +5;
            }

            PinkPoney.position += PinkPoney.vitesse;
        }
        public void Updatedeapool()
        {
            if (deadpool.GetRect().Intersects(caca.GetRect()))
            {
                deadpool.estVivant = false;
                
            }
        }
        public void Updatecaca()
        {
            if (caca.position.Y > fenetre.Bottom)
            {
                caca.position.Y = PinkPoney.position.Y+110;
                caca.position.X = PinkPoney.position.X+60;
            }

            caca.position += caca.vitesse;
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
            spriteBatch.Draw(caca.sprite, caca.position, Color.White);
           

            if (deadpool.estVivant == true)
            {
                spriteBatch.Draw(deadpool.sprite, deadpool.position, Color.White);


            }

            spriteBatch.Draw(caca.sprite, caca.position, Color.White);

            if (deadpool.estVivant == false)
            {
                spriteBatch.Draw(fin.sprite, fin.position, Color.White);

            }


            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}

