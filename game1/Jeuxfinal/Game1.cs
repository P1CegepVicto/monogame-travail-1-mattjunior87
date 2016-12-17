using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;

namespace Jeuxfinal
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Rectangle fenetre;
        GameObject hero;
        GameObject[] console = new GameObject[8];
        GameObject[] projectiles = new GameObject[10];
        GameObject background1;
        GameObject background2;
        GameObject backgroundwin;
        GameObject backgroundloose;
        Random de = new Random();
        SoundEffect son;
        SoundEffectInstance airhorn;



        int typeconsole = 0;
        int typeprojectiles = 0;
        int nbprojectiles = 10;
        int projectilevivant = 0;
        int compteur = 0;
        



        public Game1()
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
           

            hero = new GameObject();
            hero.estVivant = true;
            hero.position.X = 820;
            hero.position.Y = 800;
            hero.vitesse.X = 4;
            hero.sprite = Content.Load<Texture2D>("masterrace.png");

            background1 = new GameObject();
            background1.estVivant = true;
            background1.position.X = 0;
            background1.position.Y = 0;
            background1.sprite = Content.Load<Texture2D>("background.jpg");

            background2 = new GameObject();
            background2.estVivant = true;
            background2.position.X = 0;
            background2.position.Y = 0;
            background2.sprite = Content.Load<Texture2D>("background.jpg");

            backgroundwin = new GameObject();
            backgroundwin.estVivant = true;
            backgroundwin.position.X = 0;
            backgroundwin.position.Y = 0;
            backgroundwin.sprite = Content.Load<Texture2D>("win.jpg");

            backgroundloose = new GameObject();
            backgroundloose.estVivant = true;
            backgroundloose.position.X = 0;
            backgroundloose.position.Y = 0;
            backgroundloose.sprite = Content.Load<Texture2D>("loose.jpg");

            for (int i = 0; i < console.Length; i++)
            {
                console[i] = new GameObject();
                console[i].estVivant = true;
                console[i].position.X = 0;
                console[i].position.Y = de.Next(2,400);
                console[i].direction.X = de.Next(8,15);
                typeconsole = de.Next(1, 4);
                if (typeconsole == 1)
                {
                    console[i].sprite = Content.Load<Texture2D>("wiiU.png");
                }
                else if (typeconsole == 2)
                {
                    console[i].sprite = Content.Load<Texture2D>("ps4.png");
                }
                else if (typeconsole == 3)
                {
                    console[i].sprite = Content.Load<Texture2D>("xbox.png");
                }
            }
            for (int i = 0; i < projectiles.Length; i++)
            {
                projectiles[i] = new GameObject();
                projectiles[i].estVivant = false;
                projectiles[i].position.X = hero.position.X;
                projectiles[i].position.Y = hero.position.Y;
                typeprojectiles = de.Next(1, 5);
                if (typeprojectiles == 1)
                {
                    projectiles[i].sprite = Content.Load<Texture2D>("nvidia1080.png");
                }
                else if (typeprojectiles == 2)
                {
                    projectiles[i].sprite = Content.Load<Texture2D>("4klogo.png");
                }
                else if (typeprojectiles == 3)
                {
                    projectiles[i].sprite = Content.Load<Texture2D>("titanx.png");
                }
                else if (typeprojectiles == 4)
                {
                    projectiles[i].sprite = Content.Load<Texture2D>("steam.png");
                }

            }
            Song song = Content.Load<Song>("Sounds\\Puzzle-Game_Looping");
            MediaPlayer.Play(song);

            son = Content.Load<SoundEffect>("Sounds\\AIRPORN");
            airhorn = son.CreateInstance();

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
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                hero.position.X += 7;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                hero.position.X -= 7;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                hero.position.Y -= 7;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                hero.position.Y += 7;
            }

            if (hero.position.X < fenetre.Left)
            {
                hero.position.X = fenetre.Left;
            }
            if (hero.position.X > fenetre.Right-270)
            {
                hero.position.X = fenetre.Right - 270;
            }
            if (hero.position.Y < fenetre.Top)
            {
                hero.position.Y = fenetre.Top;
            }
            if (hero.position.Y > fenetre.Bottom-400)
            {
                hero.position.Y = fenetre.Bottom - 400;
            }
            
                // TODO: Add your update logic here
            updateconsole();
            background();
            updateprojectiles(gameTime);
             
            base.Update(gameTime);
        }
        public void updateconsole()
        {
            for (int i = 0; i < console.Length; i++)
            {
                if (console[i].position.X > fenetre.Right-200)
                {
                    console[i].direction.X = de.Next(-14, -7);
                }
                if (console[i].position.X < fenetre.Left)
                {
                    console[i].direction.X = de.Next(8, 15);
                }
                if (console[i].GetRect().Intersects(hero.GetRect()))
                {
                    hero.estVivant = false;
                }
                for (int y = 0; y < projectiles.Length; y++)
                {
                    if (console[i].estVivant == true)
                    {
                        if (projectiles[y].estVivant == true)
                        {
                            if (console[i].GetRect().Intersects(projectiles[y].GetRect()))
                            {
                                console[i].estVivant = false;
                                projectiles[y].estVivant = false;
                            }
                        }
                    }
                   
                }


                console[i].position.X += (int)console[i].direction.X;
                
            }
        }
        public void updateprojectiles(GameTime gameTime)
        {
            compteur++;
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                if (projectilevivant < projectiles.Length)
                {
                    if (compteur >= 15)
                    {
                        projectiles[projectilevivant].estVivant = true;
                        projectiles[projectilevivant].vitesse.Y = -25;
                        airhorn.Play();
                        if (projectiles[projectilevivant].position.Y < fenetre.Top)
                        {
                            projectiles[projectilevivant].estVivant = false;
                            
                        }
                        projectilevivant++;
                        nbprojectiles--;
                        compteur = 0;
                        
                    }
                }

            }
        }
        public void background()
        {
            background1.position.X -= 3;
            if (background1.position.X < 0)
            {
                background2.position.X = background1.position.X + background1.sprite.Width;
            }
            if (background1.position.X >= 0)
            {
                background2.position.X = background1.position.X - background1.sprite.Width;
            }

            if (background2.position.X < 0)
            {
                background1.position.X = background2.position.X + background2.sprite.Width;
            }
            if (background2.position.X >= 0)
            {
                background1.position.X = background2.position.X - background2.sprite.Width;
            }

        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            
            spriteBatch.Draw(background1.sprite, background1.position);
            spriteBatch.Draw(background2.sprite, background2.position, effects: SpriteEffects.FlipHorizontally);
            if (hero.estVivant == true)
            {
                spriteBatch.Draw(hero.sprite, hero.position, Color.White);
            }
            for (int i = 0; i < console.Length; i++)
            {
                if (console[i].estVivant == true)
                {
                    spriteBatch.Draw(console[i].sprite, console[i].position, Color.White);
                }
            }

         
            for (int i = 0; i < projectiles.Length; i++)
            {
                if (projectiles[i].estVivant == true)
                {
                    spriteBatch.Draw(projectiles[i].sprite, projectiles[i].position += projectiles[i].vitesse, Color.White);
                }
            }
            if (console[0].estVivant == false)
            {
                if (console[1].estVivant == false)
                {
                    if (console[2].estVivant == false)
                    {
                        if (console[3].estVivant == false)
                        {
                            if (console[4].estVivant == false)
                            {
                                if (console[5].estVivant == false)
                                {
                                    if (console[6].estVivant == false)
                                    {
                                        if (console[7].estVivant == false)
                                        {
                                            spriteBatch.Draw(backgroundwin.sprite, backgroundwin.position);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            } 
            if (hero.estVivant == false)
            {
                spriteBatch.Draw(backgroundloose.sprite, backgroundloose.position);
            }
          
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
