using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;

namespace Cruise_Catch
{
	public class Level
	{
		public Block[,] Blocks { get; set; }
		public Spike[,] Spikes { get; set; }
		public Vector2 StartPos { get; set; }
		public Vector2 EndPos { get; set; }
		public float LevelTime { get; set; }

        int minimumX;

        int maximumX;

        int minimumY;

        int maximumY;

        public Level()
		{
            minimumX = 0;
            maximumX = 0;
            minimumY = 0;
            maximumY = 0;
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
			this.LevelTime = 0f;
		}


		public void Update(GameTime gameTime)
		{
			LevelTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
		}
        private void loadLevel(string path, Texture2D block, Texture2D spike)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (i == 0)
                        {
                            string line = reader.ReadLine();
                            string[] parts = line.Split(' ');
                            StartPos = new Vector2(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]));
                        }
                        else if (i == 1)
                        {
                            string line = reader.ReadLine();
                            string[] parts = line.Split(' ');
                            minimumX = Convert.ToInt32(parts[0]);
                            minimumY = Convert.ToInt32(parts[1]);
                        }
                        else if (i == 2)
                        {
                            string line = reader.ReadLine();
                            string[] parts = line.Split(' ');
                            maximumX = Convert.ToInt32(parts[0]);
                            maximumX = Convert.ToInt32(parts[1]);
                        }
                    }
                    for (int i = 0; !reader.EndOfStream; i++)
                    {
                        string line = reader.ReadLine();
                        for (int j = 0; i < line.Length; i++)
                        {
                            switch (line[j])
                            {
                                case 'a':
                                    Blocks[i, j] = null;
                                    break;
                                case 'b':
                                    //todo: put tex



                                    Texture2D tex = null;
                                    Boolean breakable = true;
                                    Boolean isSolid = true;
                                    float BreakVelocity = 30;
                                    Boolean isActive = true;
                                    int width = 50;
                                    int height = 50;
                                    tex = block;
                                    Vector2 worldPos = new Vector2(j * 50, i * 50);







                                    Blocks[i, j] = new Block(worldPos, width, height, tex, isSolid, breakable, BreakVelocity, isActive);
                                    break;
                                case 's':

                                    Texture2D tex2 = null;
                                    tex = spike;
                                     worldPos = new Vector2(j * 50, i * 50);
                                     width = 50;
                                     height = 20;
                                    Spikes[i, j] = new Spike(worldPos, width, height, tex2);
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
