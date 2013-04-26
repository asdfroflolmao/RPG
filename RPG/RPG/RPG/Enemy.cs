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
        
        /// <summary>
        /// animations
        Point frameSize = new Point(32, 32);
        Point currentFrame = new Point(0, 0);
        Point sheetSize = new Point(3, 4);
        int frame = 0;
        int fps = 30;
        /// </summary>

        int turnCounter = 0;

        public Enemy(Texture2D sprite)
        {
            enemy = sprite;
            position = new Vector2(390 - enemy.Width, 70);
            enemyRectangle = new Rectangle((int)position.X, (int)position.Y, enemy.Width, enemy.Height);
        }

        public void Draw(SpriteBatch enemySprite)
        {
            enemySprite.Draw(enemy,position,Color.White);
            //enemySprite.Draw(enemy, position, new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
        }

        public void AI(Player player)
        {
            if(turnCounter==0)
                player.setHP(attack);
            if (turnCounter == 1)
                player.setHP(attack);
            else
                player.setHP(attack);
            turnCounter++;
        }
        public int getHP()
        {
            return health;
        }
        //public int getMANA()
        //{
        //    return mana;
        //}
        public void setHP(int damageValue)
        {
            health -= damageValue;
        }
        public int getAttack()
        {
            return attack;
        }
    }
}
