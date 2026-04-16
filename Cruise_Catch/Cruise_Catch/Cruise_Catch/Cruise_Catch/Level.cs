using Microsoft.Xna.Framework;

namespace Cruise_Catch
{
	public class Level
	{
		public Block[,] Blocks { get; set; }
		public Spike[,] Spikes { get; set; }
		public Vector2 StartPos { get; set; }
		public Vector2 EndPos { get; set; }
		public float LevelTime { get; set; }

		public Level()
		{
			Blocks = new Block[0, 0];
			Spikes = new Spike[0, 0];
			StartPos = Vector2.Zero;
			EndPos = Vector2.Zero;
			LevelTime = 0f;
		}

		public Level(Block[,] blocks, Spike[,] spikes, Vector2 startPos, Vector2 endPos)
		{
			Blocks = blocks;
			Spikes = spikes;
			StartPos = startPos;
			EndPos = endPos;
			LevelTime = 0f;
		}

		public void LoadLevel(Block[,] blocks, Spike[,] spikes, Vector2 startPos, Vector2 endPos)
		{
			Blocks = blocks;
			Spikes = spikes;
			StartPos = startPos;
			EndPos = endPos;
			LevelTime = 0f;
		}

		public void Update(GameTime gameTime)
		{
			LevelTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
		}
	}
}
