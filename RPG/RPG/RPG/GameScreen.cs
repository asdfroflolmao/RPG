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
        public Enemy enemy;
        Texture2D enemySprite;

        KeyboardState lastState;

        TileMap myMap = new TileMap();
        int squaresAcross = 25;
        int squaresDown = 19;

        public GameScreen(Game1 game)
        {
            this.game = game;
            texture = game.Content.Load<Texture2D>(@"Scenes\GameScreen");
            playerSprite = game.Content.Load<Texture2D>(@"Sprites\playerSheet");
            player = new Player(playerSprite);
            enemySprite = game.Content.Load<Texture2D>(@"Sprites\playerSheet");
            enemy = new Enemy(playerSprite);
            Tile.TileSetTexture = game.Content.Load<Texture2D>(@"Textures\tileset");

        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (enemy!=null && player.playerRectangle.Intersects(enemy.enemyRectangle))// if player intersects enemy -> CombatScreen
            {
                game.CombatTime();
                enemy = null;
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

            //if (texture != null)
            //    spriteBatch.Draw(texture, Vector2.Zero, Color.White);

            player.Draw(spriteBatch);
            if(enemy!=null)
                enemy.Draw(spriteBatch);

        }
    }
}