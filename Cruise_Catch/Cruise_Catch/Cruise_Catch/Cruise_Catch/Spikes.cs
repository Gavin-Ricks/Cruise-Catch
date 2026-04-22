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

namespace Cruise_Catch
{
    class Spikes
    {
        Texture2D tex;
        Rectangle rec;

        public Spikes(Texture2D tex, Rectangle rec)
        {
            this.tex = tex;
            this.rec = rec;
        }
        public Texture2D getTex()
        {
            return tex;
        }
        public Rectangle getRec()
        {
            return rec;
        }
        public Boolean IsCollidingWith(Rectangle a)
        {
            if(rec.Intersects(a))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
