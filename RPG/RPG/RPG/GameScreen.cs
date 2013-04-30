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

        Texture2D texture;
        public Player player;
        Texture2D playerSprite;
        public Enemy[] enemyArray;
        public Enemy enemy;
        Texture2D enemySprite;
        Texture2D enemyBOSSSprite;
        Texture2D diamondSprite;
        Texture2D healthSprite;
        Texture2D levelOneTut;
        Texture2D levelTwoTut;
        public Items healthPot;
        public Items diamondDrop;
        int diamondCounter = 0; ////////////////// 10 DIAMONDS NEEDED TO BOSS BATTLE.
        KeyboardState lastState;

        TileMap myMap;
        int squaresAcross = 25;
        int squaresDown = 19;

        int level;
        bool allDead = false;

        public GameScreen(Game1 game)
        {
            this.game = game;
            level = 1;
            texture = game.Content.Load<Texture2D>(@"Scenes\GameScreen");
            playerSprite = game.Content.Load<Texture2D>(@"Sprites\PlayerSheet");
            player = new Player(playerSprite);
            enemySprite = game.Content.Load<Texture2D>(@"Sprites\Enemy");
            enemyBOSSSprite = game.Content.Load<Texture2D>(@"Sprites\EnemyBoss");
            enemy = new Enemy(enemySprite, new Vector2(390 - enemySprite.Width, 70), "Tinky Winky");
            enemyArray = new Enemy[1] { enemy };
            Tile.TileSetTexture = game.Content.Load<Texture2D>(@"Textures\tileset");
            myMap = new TileMap(level);
            levelOneTut = game.Content.Load<Texture2D>(@"GameScreen\LevelOneTut");
            levelTwoTut = game.Content.Load<Texture2D>(@"GameScreen\LevelTwoTut");
            diamondSprite = game.Content.Load<Texture2D>(@"Sprites\Diamond32");
            healthSprite = game.Content.Load<Texture2D>(@"Sprites\HealthPot32");

            Game1.MessageBox(new IntPtr(0), "This is a sample message box! Go fuck yourself Albert. :D", "Sample", 0);
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();


            if (level == 1) //exists 1 enemy on map. 1 diamond drop.
            {
                if (enemyArray[0] == null)
                {
                    allDead = true;
                    level = 2;
                    myMap = new TileMap(level);
                    player.position = player.startPosition;//go back to start position
                    //player.setHP(-100);//////////DEBUG PURPOSES ONLY
                    enemyArray = new Enemy[2];
                    //insert 2 enemies diff positions{enemy};

                    enemyArray[0] = new Enemy(enemySprite, new Vector2(500 - enemySprite.Width, 300), "Ahnold Schwartzgenheimer");
                    enemyArray[1] = new Enemy(enemySprite, new Vector2(200 - enemySprite.Width, 70), "Rocky Balboa");
                    healthPot = new Items(healthSprite, new Vector2(400, 400), itemType.HealthPot);
                    allDead = false;
                }

            }
            if (level == 2) //exists 1 health pot on map. 2 enemies, 2 diamond drop
            {
                if (healthPot != null && player.playerRectangle.Intersects(healthPot.itemRectangle))
                {
                    player.healHP(healthPot.heal);
                    Game1.MessageBox(new IntPtr(0), String.Format("You just healed for {0} health!", healthPot.heal), "Health Pot", 0);
                    healthPot = null;
                }

                if (enemyArray[0] == null && enemyArray[1] == null)
                {
                    allDead = true;
                    level = 3;
                    myMap = new TileMap(level);
                    player.position = player.startPosition;//go back to start position
                    //player.setHP(-100);//////////DEBUG PURPOSES ONLY
                    enemyArray = new Enemy[3];
                    //insert 3 enemies diff positions{enemy};

                    enemyArray[0] = new Enemy(enemySprite, new Vector2(230 - enemySprite.Width, 200), "Christian Bale");
                    enemyArray[1] = new Enemy(enemySprite, new Vector2(230 - enemySprite.Width, 30), "Samuel L. Jackson");
                    enemyArray[2] = new Enemy(enemySprite, new Vector2(600 - enemySprite.Width, 30), "Spiderman");

                    allDead = false;
                }

            }
            if (level == 3) //exists 1 health pot on map. 3 enemies, 3 diamond drop
            {
                if (enemyArray[0] == null && enemyArray[1] == null && enemyArray[2] == null)
                {
                    allDead = true;
                    level = 4;
                    myMap = new TileMap(level);
                    player.position = player.startPosition;//go back to start position
                    //player.setHP(-100);//////////DEBUG PURPOSES ONLY
                    enemyArray = new Enemy[4];
                    ////////////////////////////////////////////////////////////////////////////////////EDIT THESES NAMES
                    enemyArray[0] = new Enemy(enemyBOSSSprite, new Vector2(230 - enemySprite.Width, 200), "Christian Bale");
                    enemyArray[1] = new Enemy(enemySprite, new Vector2(230 - enemySprite.Width, 30), "Samuel L. Jackson");
                    enemyArray[2] = new Enemy(enemySprite, new Vector2(600 - enemySprite.Width, 30), "Spiderman");
                    enemyArray[3] = new Enemy(enemySprite, new Vector2(600 - enemySprite.Width, 30), "Superman");

                    allDead = false;
                }

            }
            if (level == 4) //exists 1 health pot on map. 4 enemies, 4 diamond drop
            {
                if (enemyArray[0] == null && enemyArray[1] == null)
                {
                    allDead = true;
                    level = 5;
                    myMap = new TileMap(level);
                    player.position.X = Constants.gameWindowWidth / 2 - playerSprite.Width / 2;//go back to start position
                    player.position.Y = (float)(Constants.gameWindowHeight * 0.75) - playerSprite.Height / 2;
                    //player.setHP(-100);//////////DEBUG PURPOSES ONLY
                    enemyArray = new Enemy[1];
                    ////////////////////////////////////////////////////////////////////////////////////EDIT THESES NAMES
                    enemyArray[0] = new Enemy(enemyBOSSSprite, new Vector2(Constants.gameWindowWidth / 2 - enemySprite.Width, 300), "BOSSMAN");

                    allDead = false;
                }

            }
            if (level == 5)
            {
                if (enemyArray[0] == null)
                {
                    ;// diamond drop
                }
            }
            for (int j = 0; j < enemyArray.Length; j++)
            {

                if (enemyArray[j] != null && player.playerRectangle.Intersects(enemyArray[j].enemyRectangle))// if player intersects enemy -> CombatScreen
                {
                    game.CombatTime(j);
                    enemyArray[j] = null;
                }
            }

            lastState = keyboardState;
            player.Update(gameTime, game.GraphicsDevice);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < squaresDown; y++)
            {
                for (int x = 0; x < squaresAcross; x++)
                {
                    spriteBatch.Draw(
                        Tile.TileSetTexture,
                        new Rectangle((x * 32), (y * 32), 32, 32),
                        Tile.GetSourceRectangle(myMap.Rows[y].Columns[x].TileID),
                        Color.White);
                }
            }

            if (level == 1)
            {
                spriteBatch.Draw(levelOneTut, Vector2.Zero, Color.White);
            }
            if (level == 2 && healthPot != null)
            {
                spriteBatch.Draw(levelTwoTut, Vector2.Zero, Color.White);
                healthPot.Draw(spriteBatch);
            }

            //draw player
            player.Draw(spriteBatch);

            //draw enemies
            for (int i = 0; i < enemyArray.Length; i++)
            {
                if (enemyArray[i] != null)
                    enemyArray[i].Draw(spriteBatch);
            }
        }
    }
}