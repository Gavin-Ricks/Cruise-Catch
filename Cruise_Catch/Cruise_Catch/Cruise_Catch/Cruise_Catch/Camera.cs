using Microsoft.Xna.Framework;

namespace Cruise_Catch
{
	public class Camera
	{
		public Vector2 Position { get; set; }

		public Camera()
		{
			Position = Vector2.Zero;
		}

		public Camera(Vector2 startPosition)
		{
			Position = startPosition;
		}

		public void Follow(Rectangle target, int viewportWidth, int viewportHeight)
		{
			Position = new Vector2(
				target.Center.X - (viewportWidth / 2),
				target.Center.Y - (viewportHeight / 2));
		}
	}
}
