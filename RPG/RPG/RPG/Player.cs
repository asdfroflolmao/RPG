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

        public Player(Texture2D sprite)
        {
            player = sprite;
        }
        public void Update(GameTime gametime)
        {

        }

        public void Draw(SpriteBatch playerSprite)
        {
            playerSprite.Draw(player, Vector2.Zero, Color.White);
        }
    }
}
