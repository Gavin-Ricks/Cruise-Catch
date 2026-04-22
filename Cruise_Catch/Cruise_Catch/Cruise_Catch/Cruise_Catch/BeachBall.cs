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
    class BeachBall
    {
        Texture2D beachBallImage;
        Rectangle beachBallRec;
        int beachBallVelocity;
        public BeachBall(Texture2D i, Rectangle r, int v)
        {
            beachBallImage = i;
            beachBallRec = r;
            beachBallVelocity = v;
        }

        public Texture2D getImage()
        {
            return beachBallImage;
        }

        public Rectangle getRec()
        {
            return beachBallRec;
        }

        public int getVelocity()
        {
            return beachBallVelocity;
        }

        public void updatePos()
        {
            beachBallRec.X += beachBallVelocity;
            beachBallRec.Y += beachBallVelocity;
        }

        public void changeVelocity()
        {
            beachBallVelocity *= -1;
        }
        public void changeVelocity(Rectangle block)
        {
            if (beachBallRec.Intersects(block))
            {
                beachBallVelocity *= -1;
            }
        }

        public Boolean isBroken(Rectangle spike)
        {
            if (beachBallRec.Intersects(spike))
            {
                return true;
            }
            return false;
        }
    }
}
