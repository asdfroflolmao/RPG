using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG
{
    class Player
    {
        Texture2D player;
        int health = 100;
        int attack = 10;
        //int mana;
        int MOVESPEED = 2;
        public Vector2 position;
        KeyboardState lastState;
        public Rectangle playerRectangle;
        

        public Player(Texture2D sprite)
        {
            player = sprite;
            position = new Vector2(150, 490);
        }
        public void Update(GameTime gametime, GraphicsDevice graphics)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                position.X -= MOVESPEED;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                position.X += MOVESPEED;
            } 
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                position.Y += MOVESPEED;
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                position.Y -= MOVESPEED;
            }
            position.X = MathHelper.Clamp(position.X, 0, graphics.Viewport.Width - player.Width);
            position.Y = MathHelper.Clamp(position.Y, 0, graphics.Viewport.Height - player.Height);
            playerRectangle = new Rectangle((int)position.X, (int)position.Y, player.Width, player.Height);
            lastState = keyboardState;
        }

        public void Draw(SpriteBatch playerSprite)
        {
            playerSprite.Draw(player, position, Color.White);
        }

        public int getHP()
        {
            return health;
        }
        //public int getMANA()
        //{
        //    return mana;
        //}
        public int getAttack()
        {
            return attack;
        }
    }
}
