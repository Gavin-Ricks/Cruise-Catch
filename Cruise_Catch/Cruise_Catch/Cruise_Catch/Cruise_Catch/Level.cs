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

namespace Project
{
    class Level
    {
        Blocks[,] blocks;
        Spikes[,] spikes;
        Vector2 startPos;
        Rectangle ending;
        public Level(Blocks[,] blocks, Spikes[,] spikes, Vector2 startPos, Rectangle ending)
        {
            this.blocks = blocks;
            this.spikes = spikes;
            this.startPos = startPos;
            this.ending = ending;
        }
        public Blocks[,] getBlocks()
        {
            return blocks;
        }
        public Spikes[,] getSpikes()
        {
            return spikes;
        }
        public Boolean IsCompleted(Rectangle playerRectangle)
        {
            if(ending.Intersects(playerRectangle))
            {
                return true;
            }
            return false;
        }
        //im using texture block and texture spike and others as a placeholder right now, when the game proceedes maybe you can make the textures of the objects public so i can refernce them here
        //using two seperate arrays for the blocks and the spikes, in the future add crabs beachballs etc.
        private void loadLevel(string path,Texture2D block, Texture2D spike)
        {
            try
            {
                using(StreamReader reader = new StreamReader (path))
                {
                    for(int i=0; i<3; i++)
                    {
                        if(i == 0)
                        {
                            string line = reader.ReadLine();
                            string[] parts = line.Split(' ');
                            startPos = new Vector2(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]));
                        }
                        else if(i == 1)
                        {
                            string line = reader.ReadLine();
                            string[] parts = line.Split(' ');
                            minimumX = Convert.ToInt32(parts[0]);
                            minimumY = Convert.ToInt32(parts[1]);
                        }
                        else if(i == 2)
                        {
                            string line = reader.ReadLine();
                            string[] parts = line.Split(' ');
                            maximumX = Convert.ToInt32(parts[0]);
                            maximumX = Convert.ToInt32(parts[1]);
                        }
                    }
                    for(int i=0; !reader.EndOfStream; i++)
                    {
                        string line = reader.ReadLine();
                        for(int j = 0; i<line.Length; i++)
                        {
                            switch(line[j])
                            {
                                case 'a':
                                    blocks[i, j] = null;
                                    break;
                                case 'b':
                                    //TEX WILL BE ASSIGNED TEXTURE WHEN I GAIN ACSESS
                                    Texture2D tex = null;
                                    Boolean breakable = true;
                                    tex = block;
                                    //here to change block size
                                    Rectangle pos = new Rectangle(j*50,i*50,50,50);
                                    blocks[i, j] = new Blocks(tex, pos, breakable);
                                    break;
                                case 's':
                                    Texture2D tex2 = null;
                                    //this will inherintly make the spikes smaller but have the same distance between them as blocks.
                                    Rectangle pos2 = new Rectangle(j * 50, i * 50, 20, 20);
                                    spikes[i, j] = new Spikes(tex2, pos2);
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
    }
}
