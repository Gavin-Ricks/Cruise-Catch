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

namespace Project_60_Second_Cruise_Run
{
    enum currentGameStage
    {
        titleScreen,
        levelOne,
        gameOverScreen
    }
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        currentGameStage currentStage;
        KeyboardState oldKb;
        SpriteFont font;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            currentStage = currentGameStage.titleScreen;
            oldKb = Keyboard.GetState();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            font = Content.Load<SpriteFont>("SpriteFont1");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            KeyboardState kb = Keyboard.GetState();
            
            //R is restart
            if (currentStage == currentGameStage.gameOverScreen && kb.IsKeyDown(Keys.R) && !oldKb.IsKeyDown(Keys.R))
            {
                currentStage = currentGameStage.titleScreen;
            }
            //Space is to change the state to the level
            if (kb.IsKeyDown(Keys.Space) && !oldKb.IsKeyDown(Keys.Space))
            {
                currentStage = currentGameStage.levelOne;
            }
            //If someone is defeated, we'll adjust this code but for now press D for defeat
            if (kb.IsKeyDown(Keys.D) && !oldKb.IsKeyDown(Keys.D))
            {
                currentStage = currentGameStage.gameOverScreen;
            }
            oldKb = kb;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            if (currentStage == currentGameStage.titleScreen)
            {
                spriteBatch.DrawString(font, "Welcome to 60 Second Cruise Catch", new Vector2(50, 100), Color.White);
                spriteBatch.DrawString(font, "In this game, Jack has 60 seconds to run through all the levels.", new Vector2(25, 125), Color.White);
                spriteBatch.DrawString(font, "The cruise leaves in 60 seconds.", new Vector2(50, 150), Color.White);
                spriteBatch.DrawString(font, "Good luck. Press Space to begin.", new Vector2(50, 175), Color.White);
            }
            if (currentStage == currentGameStage.levelOne)
            {
                //Do this
            }
            if (currentStage == currentGameStage.gameOverScreen)
            {
                spriteBatch.DrawString(font, "Oh. You've been defeated. Press R to restart", new Vector2(50, 100), Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
