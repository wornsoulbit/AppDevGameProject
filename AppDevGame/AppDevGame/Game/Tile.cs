using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppDevGame.Game {

    enum TileCollsion {
        
        passable = 0,

        impassable = 1
    }

    struct Tile {
        public Texture2D Texture;
        public TileCollsion Collsion;

        public const int Width = 40;
        public const int Height = 40;

        public Tile(Texture2D texture, TileCollsion collsion)
        {
            Texture = texture;
            Collsion = collsion;
        }
    }
}
