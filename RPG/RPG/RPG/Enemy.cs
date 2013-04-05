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

        int turnCounter = 0;
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

        public void AI()
        {
            //if(turnCounter==0)
            //    //enemy.attack
            //if(turnCounter==1)
            //    //enemy.attack
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
