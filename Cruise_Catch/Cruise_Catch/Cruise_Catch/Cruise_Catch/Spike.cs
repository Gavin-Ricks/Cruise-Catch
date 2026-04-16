using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cruise_Catch
{
    public class Spike
    {
        public Rectangle SpikeRectangle { get; set; }
        public Texture2D SpikeTexture { get; set; }
        public bool IsActive { get; set; }
        public Vector2 WorldPosition { get; set; }

        public Spike(Vector2 worldPosition, int width, int height, Texture2D texture)
        {
            WorldPosition = worldPosition;
            SpikeRectangle = new Rectangle((int)worldPosition.X, (int)worldPosition.Y, width, height);
            SpikeTexture = texture;
            IsActive = true;
        }

        public bool CheckCollision(Rectangle other)
        {
            return IsActive && SpikeRectangle.Intersects(other);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            if (IsActive && SpikeTexture != null)
            {
                var screenRectangle = new Rectangle(
                    SpikeRectangle.X - (int)cameraPosition.X,
                    SpikeRectangle.Y - (int)cameraPosition.Y,
                    SpikeRectangle.Width,
                    SpikeRectangle.Height);

                spriteBatch.Draw(SpikeTexture, screenRectangle, Color.White);
            }
        }
    }
}
