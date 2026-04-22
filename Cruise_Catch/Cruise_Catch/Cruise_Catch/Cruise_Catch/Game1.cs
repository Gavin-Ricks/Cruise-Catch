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
    enum currentGameStage
    {
        titleScreen,
        levelOne,
        gameOverScreen
    }
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        currentGameStage currentStage;
        KeyboardState oldKb;
        SpriteFont font;
        int gameSeconds, gameTimer;
        Boolean isPaused;
        Texture2D beachImage;
        Texture2D startImage;
        Texture2D gameOver;






        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 700;
        }

        protected override void Initialize()
        {
            currentStage = currentGameStage.titleScreen;
            gameTimer = 0;
            gameSeconds = 60;
            oldKb = Keyboard.GetState();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("SpriteFont1");
            beachImage = this.Content.Load<Texture2D>("Beach");
            startImage = this.Content.Load<Texture2D>("Start");
            gameOver = this.Content.Load<Texture2D>("Over");
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            KeyboardState kb = Keyboard.GetState();
            if (currentStage == currentGameStage.gameOverScreen && kb.IsKeyDown(Keys.R) && !oldKb.IsKeyDown(Keys.R))
            {
                gameSeconds = 60;
                currentStage = currentGameStage.titleScreen;

            }
            if (kb.IsKeyDown(Keys.Space) && !oldKb.IsKeyDown(Keys.Space))
            {

                currentStage = currentGameStage.levelOne;
            }

            if (kb.IsKeyDown(Keys.P) && !oldKb.IsKeyDown(Keys.P))
            {
                isPaused = !isPaused;
            }
            if (currentStage == currentGameStage.levelOne)
            {
                if (isPaused)
                {
                    gameTimer++;
                    if (gameTimer == 60)
                    {
                        gameTimer = 0;
                        gameSeconds--;
                    }
                }
                if (gameSeconds <= 0)
                {
                    currentStage = currentGameStage.gameOverScreen;
                }
            }
            
            
            if (kb.IsKeyDown(Keys.D) && !oldKb.IsKeyDown(Keys.D))
            {
                currentStage = currentGameStage.gameOverScreen;
            }
            oldKb = kb;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            if (currentStage == currentGameStage.titleScreen)
            {
                spriteBatch.Draw(startImage, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.DrawString(font, "Welcome to 60 Second Cruise Catch", new Vector2(50, 100), Color.Red);
                spriteBatch.DrawString(font, "In this game, Jack has 60 seconds to run through all the levels.", new Vector2(25, 125), Color.Red);
                spriteBatch.DrawString(font, "The cruise leaves in 60 seconds.", new Vector2(50, 150), Color.Red);
                spriteBatch.DrawString(font, "Good luck. Press Space to begin.", new Vector2(50, 175), Color.Red);
            }
            if (currentStage == currentGameStage.levelOne)
            {
                spriteBatch.Draw(beachImage, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.DrawString(font, "Time left: " + gameSeconds, new Vector2(50, 175), Color.White);
            }
            if (currentStage == currentGameStage.gameOverScreen)
            {
                spriteBatch.Draw(gameOver, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
