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


        public GameScreen(Game1 game)
        {
            this.game = game;
            texture = game.Content.Load<Texture2D>(@"Scenes\GameScreen");
            playerSprite = game.Content.Load<Texture2D>(@"Sprites\playerSheet");
            player = new Player(playerSprite);
            enemySprite = game.Content.Load<Texture2D>(@"Sprites\playerSheet");
            enemy = new Enemy(playerSprite);
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
            if (texture != null)
                spriteBatch.Draw(texture, Vector2.Zero, Color.White);

            player.Draw(spriteBatch);
            if(enemy!=null)
                enemy.Draw(spriteBatch);
        }
    }
}