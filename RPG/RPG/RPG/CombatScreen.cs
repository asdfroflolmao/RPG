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
        private Game1 game;
        private Texture2D playerSprite;
        private Texture2D enemySprite;
        private Texture2D texture;
        private Texture2D combatWin;
        private Texture2D combatLost;
        private KeyboardState lastState;
        SpriteFont menufont;
        int activeItem = 0;
        Player player;
        Enemy enemy;
        private bool playerWon = false;
        private bool playerLost = false;
        private bool messageShown = false;
        
        //Health Bars
        private Texture2D healthTexture;
        private Rectangle playerHealthRectangle;
        private Rectangle playerHealthBackgroundRectangle;
        private Rectangle enemyHealthRectangle;
        private Rectangle enemyHealthBackgroundRectangle;
        private int playerStartHp;
        private int enemyStartHp;

        Random rand;
        //lock 0 for player, 1 for enemy.
        int turn;
        double time = 0;
        double elapsedTime;
        double timeToWait = 1000;

        public CombatScreen(Game1 game, Player igplayer, Enemy igenemy, Random _rand)
        {
            this.game = game;
            rand = _rand;
            
            turn = rand.Next(0, 2);// randomized first turn choosing.

            texture = game.Content.Load<Texture2D>(@"Scenes\CombatScreen");
            menufont = game.Content.Load<SpriteFont>(@"CombatScreen\menuFont");
            healthTexture = game.Content.Load<Texture2D>(@"Sprites\Bar");
            combatWin = game.Content.Load<Texture2D>(@"CombatScreen\CombatWin");
            combatLost = game.Content.Load<Texture2D>(@"CombatScreen\CombatLost");
            playerSprite = game.Content.Load<Texture2D>(@"Sprites\Player");

            if (igenemy.IsBoss())
                enemySprite = game.Content.Load<Texture2D>(@"Sprites\EnemyBoss");
            else
                enemySprite = game.Content.Load<Texture2D>(@"Sprites\Enemy");

            lastState = Keyboard.GetState();
            
            player = igplayer;
            playerStartHp = player.GetHealth();
            playerHealthBackgroundRectangle = new Rectangle(50, 145 - Constants.hpBarHeight, Constants.hpBarWidth, 20);
            enemyHealthBackgroundRectangle = new Rectangle(450, 145 - Constants.hpBarHeight, Constants.hpBarWidth, 20);

            enemy = igenemy;
            enemyStartHp = enemy.GetHealth();
        }

        public void Update(GameTime gameTime)
        {
            elapsedTime = gameTime.ElapsedGameTime.Milliseconds;
            time += elapsedTime;

            int playerHpBarWidth = (player.GetHealth() * Constants.hpBarWidth / playerStartHp);
            int enemyHpBarWidth = (enemy.GetHealth() * Constants.hpBarWidth / enemyStartHp);

            playerHealthRectangle = new Rectangle(50, 145 - Constants.hpBarHeight, playerHpBarWidth, 20);
            enemyHealthRectangle = new Rectangle(450, 145 - Constants.hpBarHeight, enemyHpBarWidth, 20);

            KeyboardState keyboardState = Keyboard.GetState();

            /*BATTLE SEQUENCE*/
            if ((playerWon != true) && (playerLost != true))
            {
                if (turn == 0) //player's turn
                {
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
                            enemy.SetHealth(player.GetAttack());//decrease enemy health by player.attack
                        if (activeItem == 1)
                            enemy.SetHealth(player.GetMagicAttack());//decrease enemy health by player.magic
                        //if (activeItem == 2)
                        //    ;//pop item selection
                        //if (activeItem == 3)
                        //    ;//do nothing. "defend"
                        turn = 1;
                        time = 0;
                    }
                }
                else if (turn == 1)
                {
                    if (!messageShown)
                    {
                        Convert.ToBoolean(Game1.MessageBox(new IntPtr(0), String.Format("{0} just attacked you for {1} damage!", enemy.GetName(), enemy.GetAttack()), "Enemy Attack!", 0));
                        messageShown = true;
                    }
                    

                    if (time >= timeToWait)
                    {
                        enemy.AI(player);
                        turn = 0;
                        time = 0;
                        messageShown = false;
                    }
                }
            }

            if (enemy.GetHealth() <= 0)
            {
                playerWon = true;
                if (keyboardState.IsKeyDown(Keys.Escape) && lastState.IsKeyUp(Keys.Escape))
                {
                    game.CombatEnd(); //Battle WIN
                }
            }

            else if (player.GetHealth() <= 0)
            {
                //Game over?
                playerLost = true;
                if (keyboardState.IsKeyDown(Keys.Escape) && lastState.IsKeyUp(Keys.Escape))
                {
                    game.Reset(); //Battle LOST
                }
            }

            lastState = keyboardState;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (playerWon)
            {
                spriteBatch.Draw(combatWin, Vector2.Zero, Color.White);
            }

            else if (playerLost)
            {
                spriteBatch.Draw(combatLost, Vector2.Zero, Color.White);
            }

            else
            {
                if (texture != null)
                {
                    spriteBatch.Draw(texture, new Vector2(0f, 0f), Color.White);
                }
                
                drawMenu(spriteBatch);

                //*****ENEMY STATS*****//
                spriteBatch.Draw(healthTexture, enemyHealthBackgroundRectangle, Color.White);
                spriteBatch.Draw(healthTexture, enemyHealthRectangle, Color.Red);
                spriteBatch.DrawString(menufont, "Enemy: " + enemy.GetName(), new Vector2(450, 150), Color.White);
                spriteBatch.DrawString(menufont, "HP: " + enemy.GetHealth(), new Vector2(450, 175), Color.White);
                //spriteBatch.DrawString(menufont, "MP: " + enemy.getMANA(), new Vector2(game.GraphicsDevice.Viewport.Width / 2-50, game.GraphicsDevice.Viewport.Height / 2-300), Color.White);

                if (!enemy.IsBoss())
                    spriteBatch.Draw(enemySprite, new Rectangle(460, 250, 105, 155), Color.White);
                else
                    spriteBatch.Draw(enemySprite, new Rectangle(400, 220, 288, 288), Color.White);
                

                //*****PLAYER STATS*****//
                spriteBatch.Draw(healthTexture, playerHealthBackgroundRectangle, Color.White);
                spriteBatch.Draw(healthTexture, playerHealthRectangle, Color.Red);
                spriteBatch.DrawString(menufont, "You: " + player.GetName(), new Vector2(50, 150), Color.White);
                spriteBatch.DrawString(menufont, "HP: " + player.GetHealth(), new Vector2(50, 175), Color.White);
                spriteBatch.Draw(playerSprite, new Rectangle(60, 250, 105, 155), Color.White);
                
            }
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
