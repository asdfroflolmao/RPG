using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

//MAIN GAME CODE

namespace RPG
{
    class GameScreen
    {
        private Game1 game;

        Player player;
        Texture2D playerSprite;

        KeyboardState lastState;

        public GameScreen(Game1 game)
        {
            this.game = game;
            playerSprite = game.Content.Load<Texture2D>(@"Sprites\player");
            player = new Player(playerSprite);
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Enter) && lastState.IsKeyUp(Keys.Enter))
            {
                
            }

            lastState = keyboardState;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
        }
    }
}