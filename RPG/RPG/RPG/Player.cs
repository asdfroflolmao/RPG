﻿using System;
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
        int MOVESPEED = 5;
        public Vector2 position;
        KeyboardState lastState;
        public Rectangle playerRectangle;

        Point frameSize = new Point(32, 32);
        Point currentFrame = new Point(0, 0);
        Point sheetSize = new Point(3, 4);
        int frame = 0;
        int fps = 30;

        public Player(Texture2D sprite)
        {
            player = sprite;
            position = new Vector2(150, 490);
        }
        public void Update(GameTime gametime, GraphicsDevice graphics)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            frame += gametime.ElapsedGameTime.Milliseconds;
            if (frame > fps)
            {
                frame -= fps;
                if(lastState.IsKeyDown(Keys.Left)&&keyboardState.IsKeyUp(Keys.Left))//idle @ left
                {
                    currentFrame.Y = 3;
                    currentFrame.X = 0;
                }

                if (keyboardState.IsKeyDown(Keys.Left))//moving left
                {
                    currentFrame.Y = 3;
                    ++currentFrame.X;
                    position.X -= MOVESPEED;
                    if (currentFrame.X >= sheetSize.X)
                    {
                        currentFrame.X = 0;
                    }
                }
                if(lastState.IsKeyDown(Keys.Right)&&keyboardState.IsKeyUp(Keys.Right))//idle @ right
                {
                    currentFrame.Y = 2;
                    currentFrame.X = 0;
                }

                if (keyboardState.IsKeyDown(Keys.Right))//moving right
                {
                    currentFrame.Y = 2;
                    ++currentFrame.X;
                    position.X += MOVESPEED;
                    if (currentFrame.X >= sheetSize.X)
                    {
                        currentFrame.X = 0;
                    }
                }
                if(lastState.IsKeyDown(Keys.Down)&&keyboardState.IsKeyUp(Keys.Down))//idle @ down
                {
                    currentFrame.Y = 0;
                    currentFrame.X = 0;
                }

                if (keyboardState.IsKeyDown(Keys.Down))//moving down
                {
                    currentFrame.Y = 0;
                    ++currentFrame.X;
                    position.Y += MOVESPEED;
                    if (currentFrame.X >= sheetSize.X)
                    {
                        currentFrame.X = 0; 
                    }
                }
                if(lastState.IsKeyDown(Keys.Up)&&keyboardState.IsKeyUp(Keys.Up))//idle @ up
                {
                    currentFrame.Y = 1;
                    currentFrame.X = 0;
                }

                if (keyboardState.IsKeyDown(Keys.Up))//moving up
                {
                    currentFrame.Y = 1;
                    ++currentFrame.X;
                    position.Y -= MOVESPEED;
                    if (currentFrame.X >= sheetSize.X)
                    {
                        currentFrame.X = 0;
                    }
                }
                position.X = MathHelper.Clamp(position.X, 0, graphics.Viewport.Width - player.Width);
                position.Y = MathHelper.Clamp(position.Y, 0, graphics.Viewport.Height - player.Height);
                playerRectangle = new Rectangle((int)position.X, (int)position.Y, player.Width, player.Height);
                lastState = keyboardState;
            }
        }

        public void Draw(SpriteBatch playerSprite)
        {
            playerSprite.Draw(player, position, new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
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
