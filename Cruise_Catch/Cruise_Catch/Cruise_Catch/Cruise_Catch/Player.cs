using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cruise_Catch
{
    public enum PlayerState
    {
        Falling,
        Standing,
        Dying
    }

    public class Player
    {
        public const float GRAVITY = 0.5f;

        public Rectangle rect { get; set; }
        public Texture2D tex { get; set; }
        public Vector2 vel { get; set; }
        public PlayerState state { get; set; }
        public bool IsAlive { get; set; }

        public Player(Texture2D spritesheet, Rectangle startPosition)
        {
            tex = spritesheet;
            rect = startPosition;
            vel = Vector2.Zero;
            state = PlayerState.Standing;
            IsAlive = true;
        }

        public void UpdatePosition()
        {
            rect = new Rectangle(
                rect.X + (int)vel.X,
                rect.Y + (int)vel.Y,
                rect.Width,
                rect.Height
            );
        }

        public void UpdateVelocity()
        {
            if (vel.Y != 0 || state == PlayerState.Falling)
            {
                vel = new Vector2(vel.X, vel.Y + GRAVITY);
            }
        }
    }
}
