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
        Player player;
        Enemy enemy;

        //Health Bars
        private Texture2D healthTexture;
        private Rectangle playerHealthRectangle;
        private Rectangle playerHealthBackgroundRectangle;
        private Rectangle enemyHealthRectangle;
        private Rectangle enemyHealthBackgroundRectangle;
        private int playerStartHp;
        private int enemyStartHp;      

        public CombatScreen(Game1 game, Player igplayer, Enemy igenemy)
        {
            this.game = game;
            texture = game.Content.Load<Texture2D>(@"Scenes\CombatScreen");
            menufont = game.Content.Load<SpriteFont>(@"CombatMenu\menuFont");
            healthTexture = game.Content.Load<Texture2D>(@"Sprites\Bar");
            lastState = Keyboard.GetState();
            
            player = igplayer;
            playerStartHp = player.getHP();
            playerHealthBackgroundRectangle = new Rectangle(game.GraphicsDevice.Viewport.Width / 2 - 50, game.GraphicsDevice.Viewport.Height / 2 - 55 - 20, 100, 20);
            enemyHealthBackgroundRectangle = new Rectangle(game.GraphicsDevice.Viewport.Width / 2 - 50, game.GraphicsDevice.Viewport.Height / 2 - 255 - 20, 100, 20);

            enemy = igenemy;
            enemyStartHp = enemy.getHP();
        }

        public void Update()
        {
            int playerHpBarWidth = (player.getHP() * 100 / playerStartHp);
            int enemyHpBarWidth = (enemy.getHP() * 100 / enemyStartHp);

            playerHealthRectangle = new Rectangle(game.GraphicsDevice.Viewport.Width / 2 - 50, game.GraphicsDevice.Viewport.Height / 2 - 55 - 20, playerHpBarWidth, 20);
            enemyHealthRectangle = new Rectangle(game.GraphicsDevice.Viewport.Width / 2 - 50, game.GraphicsDevice.Viewport.Height / 2 - 255 - 20, enemyHpBarWidth, 20);

            KeyboardState keyboardState = Keyboard.GetState();

            if (enemy.getHP() <= 0)
                //Display Battle Won screen
                if(keyboardState.IsKeyDown(Keys.Enter))
                {
                    game.CombatEnd(); //Battle WIN
                }
            if (player.getHP() <= 0)
                //Display Battle Won screen
                if(keyboardState.IsKeyDown(Keys.Enter))
                {
                    game.CombatEnd(); //Battle LOST
                }

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
                if (activeItem == 0)
                    enemy.setHP(player.getAttack());//decrease enemy health by player.attack
                if (activeItem == 1)
                    enemy.setHP(player.getAttack());//decrease enemy health by player.magic
                //if (activeItem == 2)
                //    ;//pop item selection
                if (activeItem == 3)
                    ;//do nothing. "defend"
            }

            lastState = keyboardState;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (texture != null)
                spriteBatch.Draw(texture, new Vector2(0f, 0f), Color.White);
            drawMenu(spriteBatch);

            //*****ENEMY STATS*****//
            spriteBatch.Draw(healthTexture, enemyHealthBackgroundRectangle, Color.White);
            spriteBatch.Draw(healthTexture, enemyHealthRectangle, Color.Red);
            spriteBatch.DrawString(menufont, "Enemy: " /*+ enemy.getNAME()*/, new Vector2(game.GraphicsDevice.Viewport.Width / 2 - 50, game.GraphicsDevice.Viewport.Height / 2 - 250), Color.White);
            spriteBatch.DrawString(menufont, "HP: " + enemy.getHP(), new Vector2(game.GraphicsDevice.Viewport.Width / 2-50, game.GraphicsDevice.Viewport.Height / 2-225), Color.White);
            //spriteBatch.DrawString(menufont, "MP: " + enemy.getMANA(), new Vector2(game.GraphicsDevice.Viewport.Width / 2-50, game.GraphicsDevice.Viewport.Height / 2-300), Color.White);

            //*****PLAYER STATS*****//
            spriteBatch.Draw(healthTexture, playerHealthBackgroundRectangle, Color.White);
            spriteBatch.Draw(healthTexture, playerHealthRectangle, Color.Red);
            spriteBatch.DrawString(menufont, "CHARACTER NAME" /*+ player.getNAME()*/, new Vector2(game.GraphicsDevice.Viewport.Width / 2 - 50, game.GraphicsDevice.Viewport.Height / 2 - 50), Color.White);
            spriteBatch.DrawString(menufont, "HP: " + player.getHP(), new Vector2(game.GraphicsDevice.Viewport.Width / 2-50, game.GraphicsDevice.Viewport.Height / 2 - 25), Color.White);

        }

        public void drawMenu(SpriteBatch spriteBatch)
        {
            if (activeItem == 0) spriteBatch.DrawString(menufont, "Attack", new Vector2(30, 445), Color.Black);
            else spriteBatch.DrawString(menufont, "Attack", new Vector2(25, 445), Color.White);
            if (activeItem == 1) spriteBatch.DrawString(menufont, "Magic", new Vector2(30, 470), Color.Black);
            else spriteBatch.DrawString(menufont, "Magic", new Vector2(25, 470), Color.White);
            if (activeItem == 2) spriteBatch.DrawString(menufont, "Item", new Vector2(30, 495), Color.Black);
            else spriteBatch.DrawString(menufont, "Item", new Vector2(25, 495), Color.White);
            if (activeItem == 3) spriteBatch.DrawString(menufont, "Defend", new Vector2(30, 520), Color.Black);
            else spriteBatch.DrawString(menufont, "Defend", new Vector2(25, 520), Color.White);
            
            
        }
    }
}
