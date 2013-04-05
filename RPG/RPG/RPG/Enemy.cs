using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG
{
    class Enemy
    {
        Texture2D enemy;
        int health = 100;
        int attack = 10;
        //int mana;
        public Vector2 position;
        KeyboardState lastState;
        public Rectangle enemyRectangle;


        public Enemy(Texture2D sprite)
        {
            enemy = sprite;
            position = new Vector2(390 - enemy.Width, 70);
            enemyRectangle = new Rectangle((int)position.X, (int)position.Y, enemy.Width, enemy.Height);
        }

        public void Draw(SpriteBatch playerSprite)
        {
            playerSprite.Draw(enemy, position, Color.White);
        }
    }
}
