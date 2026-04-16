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
    class Blocks
    {
        Boolean breakable;
        int velocity;
        Rectangle pos;
        Texture2D tex;

        public Blocks(Texture2D tex, Rectangle pos, Boolean breakable)
        {
            this.tex = tex;
            this.pos = pos;
            this.breakable = breakable;
            velocity = 10;
        }
        public Blocks(Texture2D tex, Rectangle pos, Boolean breakable, int velocity)
        {
            this.tex = tex;
            this.pos = pos;
            this.breakable = breakable;
            this.velocity = velocity;
        }

        public Boolean isBreakable()
        {
            return breakable;
        }
        public Rectangle getPos()
        {
            return pos;
        }
        public Texture2D getTex()
        {
            return tex;
        }
    }
}
