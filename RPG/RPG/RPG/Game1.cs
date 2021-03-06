using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace RPG
{
    enum Screen
    {
        StartScreen,
        NameInputScreen,
        GameScreen,
        GameOverScreen,
        CombatScreen
    }
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern uint MessageBox(IntPtr hWnd, String text, String caption, uint type);

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        StartScreen startScreen;
        GameScreen gameScreen;
        CombatScreen combatScreen;

        Screen currentScreen;
        Random rand = new Random();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = Constants.gameWindowWidth;
            graphics.PreferredBackBufferHeight = Constants.gameWindowHeight;
            Window.Title = "Artemis' Diamond";
       
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //MessageBox(new IntPtr(0), "Text!", "Caption!", 0);
            // TODO: Add your initialization logic here

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

            // TODO: use this.Content to load your game content here

            startScreen = new StartScreen(this);
            currentScreen = Screen.StartScreen;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            switch (currentScreen)
            {
                case Screen.StartScreen:
                    if (startScreen != null)
                        startScreen.Update();
                    break;
                case Screen.GameScreen:
                    if (gameScreen != null)
                        gameScreen.Update(gameTime);
                    break;
                case Screen.GameOverScreen:
                    break;
                case Screen.CombatScreen:
                    if (combatScreen != null)
                        combatScreen.Update(gameTime);
                    break;
            }
            base.Update(gameTime);
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
            switch (currentScreen)
            {
                case Screen.StartScreen:
                    if (startScreen != null)
                        startScreen.Draw(spriteBatch);
                    break;
                case Screen.GameScreen:
                    if (gameScreen != null)
                        gameScreen.Draw(spriteBatch);
                    break;
                case Screen.CombatScreen:
                    if (combatScreen != null)
                        combatScreen.Draw(spriteBatch);
                    break;
                case Screen.GameOverScreen:
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void StartGame()
        {
            gameScreen = new GameScreen(this);
            currentScreen = Screen.GameScreen;

            startScreen = null;
        }

        public void CombatTime(int j)
        {
            combatScreen = new CombatScreen(this, gameScreen.player, gameScreen.enemyArray[j], rand);
            currentScreen = Screen.CombatScreen;

            startScreen = null;
        }

        public void CombatEnd()
        {
            currentScreen = Screen.GameScreen;
            startScreen = null;
        }

        public void Reset()
        {
            startScreen = new StartScreen(this);
            currentScreen = Screen.StartScreen;
        }
    }
}
