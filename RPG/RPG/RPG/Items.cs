﻿using System;
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
        enum itemType
        {
            Diamond = 1,
            HealthPot = 2
        }

        itemType type;
        Texture2D item;
        int heal=20;
        public Vector2 position;
        public Rectangle itemRectangle;

        public Items(Texture2D sprite, Vector2 pos, itemType newType)
        {
            item = sprite;
            position = pos;
            type = newType;
        }
    }
}
