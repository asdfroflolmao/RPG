using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG
{
    class Items
    {
        Texture2D item;
        int heal=20;
        int diamondOrPot; //0 for diamond, 1 for pot
        public Vector2 position;
        public Rectangle itemRectangle;

        public Items(Texture2D sprite, Vector2 pos, int type)
        {
            item = sprite;
            position = pos;
            diamondOrPot = type;
        }
    }
}
