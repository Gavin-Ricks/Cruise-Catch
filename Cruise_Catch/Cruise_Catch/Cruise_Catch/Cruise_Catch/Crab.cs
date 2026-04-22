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
    class Crab
    {
        Texture2D crabImage;
        Rectangle crabRectangle;
        Vector2 crabPosition;
        int crabVelocity;
        public Crab(Texture2D cI, Rectangle cR, Vector2 cP, int cV)
        {
            crabImage = cI;
            crabRectangle = cR;
            crabPosition = cP;
            crabVelocity = cV;
        }

        public void setSlowVelocity(int pV)
        {
            if (crabVelocity > pV)
            {
                crabVelocity = pV;
            }
        }

        public void detectCollision(Rectangle wall)
        {
            if (crabRectangle.Intersects(wall))
            {
                crabVelocity *= -1;
            }
            if (crabRectangle.X + crabRectangle.Width >= 800 || crabRectangle.X - crabRectangle.Width <= 0)
            {
                crabVelocity *= -1;
            }
        }

        public void updateMovement()
        {
            crabRectangle.X += crabVelocity;
        }

        public Boolean didCollide(Rectangle player)
        {
            return crabRectangle.Intersects(player);
        }
    }
}
