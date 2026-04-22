using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cruise_Catch
{
    public class Block
    {
        // Block properties
        public bool IsSolid { get; set; }
        public bool IsBreakable { get; set; }
        public float BreakVelocity { get; set; }
        
        // Physics and rendering
        public Rectangle BlockRectangle { get; set; }
        public Texture2D BlockTexture { get; set; }
        
        // Block state
        public bool IsActive { get; set; }
        public Vector2 WorldPosition { get; set; }

        public Block(Vector2 WorldPosition, int width, int height, Texture2D texture, bool isSolid, bool isBreakable, float breakVelocity,bool isActive)
        {
            this.WorldPosition = WorldPosition;
            BlockRectangle = new Rectangle((int)WorldPosition.X, (int)WorldPosition.Y, width, height);
            BlockTexture = texture;
            IsSolid = isSolid;
            IsBreakable = isBreakable;
            BreakVelocity = breakVelocity;
            IsActive = isActive;
        }

        /// Checks if the block should break based on impact velocity
        public bool ShouldBreak(float impactVelocity)
        {
            if (!IsBreakable || !IsActive)
                return false;

            return impactVelocity >= BreakVelocity;
        }

    
        /// Breaks the block and makes it inactive
        public void Break()
        {
            if (IsBreakable)
            {
                IsActive = false;
            }
        }

        /// Updates block position and rectangle

        public void UpdatePosition(Vector2 newWorldPosition)
        {
            WorldPosition = newWorldPosition;
            BlockRectangle = new Rectangle((int)newWorldPosition.X, (int)newWorldPosition.Y, BlockRectangle.Width, BlockRectangle.Height);
        }

        public bool CheckCollision(Rectangle other)
        {
            return IsActive && BlockRectangle.Intersects(other);
        }


        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            if (IsActive && BlockTexture != null)
            {
                var screenRectangle = new Rectangle(
                    BlockRectangle.X - (int)cameraPosition.X,
                    BlockRectangle.Y - (int)cameraPosition.Y,
                    BlockRectangle.Width,
                    BlockRectangle.Height);

                spriteBatch.Draw(BlockTexture, screenRectangle, Color.White);
            }
        }
    }
}
