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

        KeyboardState lastState;

        TileMap myMap;
        int squaresAcross = 25;
        int squaresDown = 19;

        int level;
        bool allDead=false;

        public GameScreen(Game1 game)
        {
            this.game = game;
            level = 1;
            texture = game.Content.Load<Texture2D>(@"Scenes\GameScreen");
            playerSprite = game.Content.Load<Texture2D>(@"Sprites\playerSheet");
            player = new Player(playerSprite);
            enemySprite = game.Content.Load<Texture2D>(@"Sprites\player");
            enemy = new Enemy(enemySprite, new Vector2(390 - enemySprite.Width, 70));
            enemyArray = new Enemy[1]{enemy};
            Tile.TileSetTexture = game.Content.Load<Texture2D>(@"Textures\tileset");
            myMap = new TileMap(level);

        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();


            if (level == 1)
            {
                if (enemyArray[0] == null)
                {
                    allDead = true;
                    level = 2;
                    myMap = new TileMap(level);
                    player.position = player.startPosition;//go back to start position
                    player.setHP(-100);//////////DEBUG PURPOSES ONLY
                    enemyArray = new Enemy[2];
                    //insert 2 enemies diff positions{enemy};

                    enemyArray[0] = new Enemy(enemySprite, new Vector2(500 - enemySprite.Width, 300));
                    enemyArray[1] = new Enemy(enemySprite, new Vector2(200 - enemySprite.Width, 70));

                    allDead = false;
                }

            }
            if (level == 2)
            {
                if (enemyArray[0] == null && enemyArray[1] == null)
                {
                    allDead = true;
                    level = 3;
                    myMap = new TileMap(level);
                    player.position = player.startPosition;//go back to start position
                    player.setHP(-100);//////////DEBUG PURPOSES ONLY
                    enemyArray = new Enemy[3];
                    //insert 3 enemies diff positions{enemy};

                    enemyArray[0] = new Enemy(enemySprite, new Vector2(230 - enemySprite.Width, 200));
                    enemyArray[1] = new Enemy(enemySprite, new Vector2(230 - enemySprite.Width, 30));
                    enemyArray[2] = new Enemy(enemySprite, new Vector2(600 - enemySprite.Width, 30));

                    allDead = false;
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