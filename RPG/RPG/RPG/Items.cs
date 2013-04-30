using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG
{
    enum itemType
    {
        Diamond = 1,
        HealthPot = 2
    }

    class Items
    {
        itemType type;
        Texture2D item;
        public int heal = 100;
        public Vector2 position;
        public Rectangle itemRectangle;

        public Items(Texture2D sprite, Vector2 pos, itemType newType)
        {
            item = sprite;
            position = pos;
            type = newType;
            itemRectangle = new Rectangle((int)position.X, (int)position.Y, item.Width, item.Height);
        }
        public void Draw(SpriteBatch enemySprite)
        {
            enemySprite.Draw(item, position, Color.White);
        }

    }
}
