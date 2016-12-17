using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Gamenumero2
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
        GameObject Background;
        GameObject[] ennemi = new GameObject[8] ;
        GameObject finBackground;
        Random random = new Random();
        
        int typeEnnemi;
        int nombreEnnemis = 8;
        int presentNombreEnnemis = 0;
        

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
            hero.sprite = Content.Load<Texture2D>("héro.png");

            for (int i = 0; i < nombreEnnemis; i++)
            {
                
                ennemi[i] = new GameObject();
                ennemi[i].estVivant = true;
                ennemi[i].position.X = 540;
                ennemi[i].position.Y = 0;
                ennemi[i].vitesse.X = random.Next(-4, 4);
                ennemi[i].vitesse.Y = random.Next(-4, 4);
                typeEnnemi = random.Next(1, 5);
                if (typeEnnemi == 1)
                {
                    ennemi[i].sprite = Content.Load<Texture2D>("ennemi 1.png");
                }
                else if (typeEnnemi == 2)
                {
                    ennemi[i].sprite = Content.Load<Texture2D>("ennemi 2.png");
                }
                else if (typeEnnemi == 3)
                {
                    ennemi[i].sprite = Content.Load<Texture2D>("ennemi 3.png");
                }
                else if (typeEnnemi == 4)
                {
                    ennemi[i].sprite = Content.Load<Texture2D>("ennemi 4.png");
                }
            }

            Background = new GameObject();
            Background.sprite = Content.Load<Texture2D>("background.jpg");

            finBackground = new GameObject();
            finBackground.sprite = Content.Load<Texture2D>("fin2.jpg");

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
            if (hero.position.X > fenetre.Right - 87)
            {
                hero.position.X = fenetre.Right - 87;
            }
            if (hero.position.Y < fenetre.Top)
            {
                hero.position.Y = fenetre.Top;
            }
            if (hero.position.Y > fenetre.Bottom - 200)
            {
                hero.position.Y = fenetre.Bottom - 200;
            }

            UpdateEnnemi(gameTime);
            Updatehero();
            base.Update(gameTime);


        }

        public void UpdateEnnemi(GameTime gameTime)
        {

            if (presentNombreEnnemis * 2 < gameTime.TotalGameTime.Seconds && presentNombreEnnemis < nombreEnnemis)
            {
                ennemi[presentNombreEnnemis].estVivant = true;

                presentNombreEnnemis++;
                

            }

            for (int a = 0; a < nombreEnnemis; a++)
            {


                if (ennemi[a].position.X < fenetre.Right - 141)
                {
                    ennemi[a].vitesse.X = random.Next(-5, -1);
                }
                if (ennemi[a].position.X > fenetre.Left)
                {
                    ennemi[a].vitesse.X = random.Next(1, 5);
                }
                if (ennemi[a].position.Y < fenetre.Top)
                {
                    ennemi[a].vitesse.Y = random.Next(1, 5);
                }
                if (ennemi[a].position.Y > fenetre.Bottom - 129)
                {
                    ennemi[a].vitesse.Y = random.Next(-5, -1);
                }
              

                ennemi[a].position.X += ennemi[a].vitesse.X;
                ennemi[a].position.Y += ennemi[a].vitesse.Y;
                
            }
        }
        

        public void Updatehero()
        {
            for (int j = 0; j < nombreEnnemis; j++)
            {
                if (hero.GetRect().Intersects(ennemi[j].GetRect()) && ennemi[j].estVivant == true)
                {
                    hero.estVivant = false;
                }         
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            // TODO: Add your drawing code here
            spriteBatch.Draw(Background.sprite, fenetre, Color.White);
            spriteBatch.Draw(hero.sprite, hero.position, Color.White);
            
          for (int e = 0; e < nombreEnnemis; e++)
         {
                if (ennemi[e].estVivant == true)
                {
                    spriteBatch.Draw(ennemi[e].sprite, ennemi[e].position, Color.White);
                }
                
         }

             

        if (hero.estVivant == false)
        {
            spriteBatch.Draw(finBackground.sprite, finBackground.position, Color.White);
        }


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
