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

namespace RPG
{
    class CombatScreen
    {
        private Texture2D texture;
        private Game1 game;
        private KeyboardState lastState;
        SpriteFont menufont;
        int activeItem = 0;

        public CombatScreen(Game1 game)
        {
            this.game = game;
            texture = game.Content.Load<Texture2D>(@"Scenes\CombatScreen");
            menufont = game.Content.Load<SpriteFont>(@"CombatMenu\menuFont");
            lastState = Keyboard.GetState();
        }

        public void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Up) && lastState.IsKeyUp(Keys.Up))
            {
                if (activeItem != 0)
                    activeItem--;
            }
            if (keyboardState.IsKeyDown(Keys.Down) && lastState.IsKeyUp(Keys.Down))
            {
                if (activeItem != 3)
                    activeItem++;
            }

            if (keyboardState.IsKeyDown(Keys.Enter) && lastState.IsKeyUp(Keys.Enter))
            {
                game.CombatEnd();
            }

            lastState = keyboardState;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (texture != null)
                spriteBatch.Draw(texture, new Vector2(0f, 0f), Color.White);
            drawMenu(spriteBatch);
        }

        public void drawMenu(SpriteBatch spriteBatch)
        {
            if (activeItem == 0) spriteBatch.DrawString(menufont, "Attack", new Vector2(30, 45), Color.Black);
            else spriteBatch.DrawString(menufont, "Attack", new Vector2(25, 45), Color.White);
            if (activeItem == 1) spriteBatch.DrawString(menufont, "Magic", new Vector2(30, 80), Color.Black);
            else spriteBatch.DrawString(menufont, "Magic", new Vector2(25, 80), Color.White);
            if (activeItem == 2) spriteBatch.DrawString(menufont, "Item", new Vector2(30, 125), Color.Black);
            else spriteBatch.DrawString(menufont, "Attack", new Vector2(25, 125), Color.White);
            if (activeItem == 3) spriteBatch.DrawString(menufont, "Defend", new Vector2(30, 170), Color.Black);
            else spriteBatch.DrawString(menufont, "Magic", new Vector2(25, 170), Color.White);
        }
    }
}
