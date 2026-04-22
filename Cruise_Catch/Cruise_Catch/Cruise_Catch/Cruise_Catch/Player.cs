using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cruise_Catch
{
    public enum PlayerState
    {
        Standing,
        Walking,
        Falling,
        Jumping,
        Dying
    }

    public class Player
    {
        public const float GRAVITY = 0.5f;

        public Rectangle rect { get; set; }
        public Rectangle source { get; set; }
        public Texture2D tex { get; set; }
        public Vector2 vel { get; set; }
        public PlayerState state { get; set; }
        public bool IsAlive { get; set; }

        public Player(Texture2D spritesheet, Rectangle startPosition)
        {
            tex = spritesheet;
            rect = startPosition;
            source = new Rectangle(0, 0, 50, 50);
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

        public void DetermineState()
        {
            if ((int)vel.Y == 0 && (int)vel.X == 0)
            {
                state = PlayerState.Standing;
            }
            if (vel.Y < 0)
            {
                state = PlayerState.Jumping;
            }
            if (vel.Y > 0)
            {
                state = PlayerState.Falling;
            }
            if ((int)vel.Y == 0 && (int)vel.X != 0)
            {
                state = PlayerState.Walking;
            }
        }

        public void AssignSprite()
        {
            switch (state)
            {
                case PlayerState.Standing:
                    source = new Rectangle(0, 0, 50, 50);
                    break;
                case PlayerState.Walking:
                    source = new Rectangle(50, 0, 50, 50);
                    break;
                case PlayerState.Falling:
                    source = new Rectangle(100, 0, 50, 50);
                    break;
                case PlayerState.Jumping:
                    source = new Rectangle(150, 0, 50, 50);
                    break;
                default:
                    source = new Rectangle(200, 0, 50, 50);
                    break;
            }
        }
    }
}
