using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project
{
    class Level
    {
        Blocks[,] blocks;
        Spikes[,] spikes;
        Vector2 startPos;
        Rectangle ending;
        public Level(Blocks[,] blocks, Spikes[,] spikes, Vector2 startPos, Rectangle ending)
        {
            this.blocks = blocks;
            this.spikes = spikes;
            this.startPos = startPos;
            this.ending = ending;
        }
        public Blocks[,] getBlocks()
        {
            return blocks;
        }
        public Spikes[,] getSpikes()
        {
            return spikes;
        }
        public Boolean IsCompleted(Rectangle playerRectangle)
        {
            if(ending.Intersects(playerRectangle))
            {
                return true;
            }
            return false;
        }
    }
}
