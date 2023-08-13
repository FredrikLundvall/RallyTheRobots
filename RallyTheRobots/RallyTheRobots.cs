using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RallyTheRobots.GUI;
using RallyTheRobots.GUI.Common;
using ResolutionBuddy;

namespace RallyTheRobots
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class RallyTheRobots : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ContentManager contentManager;
        ScreenManager screenManager;
        InputChecker inputChecker;
        GameSettings settings;
        GameStatus gameStatus;
        ResolutionFactory resolutionFactory;

        public RallyTheRobots()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.Window.Position = new Point(0, 0);
            //this.Window.IsBorderless = true;
            //graphics.HardwareModeSwitch = true;
            //graphics.IsFullScreen = true;
            //graphics.ApplyChanges();
            //graphics.ToggleFullScreen();
            //IsFixedTimeStep = false; // Setting this to true makes it fixed time step, false is variable time step.
            //IsMouseVisible = true;
            settings = new GameSettings();
            //Check if resolution is supported
            bool resolutionIsSupported = false;
            foreach (DisplayMode displayMode in GraphicsAdapter.DefaultAdapter.SupportedDisplayModes)
            {
                if (settings.GetWidth() == displayMode.Width && settings.GetHeight() == displayMode.Height)
                {
                    resolutionIsSupported = true;
                    break;
                }
            }
            if(!resolutionIsSupported)
            {
                settings.SetWidth(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width);
                settings.SetHeight(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);
                settings.GraphicsChangeApplied();
            }
            gameStatus = new GameStatus();
            resolutionFactory = new ResolutionFactory(this, graphics);
            resolutionFactory.CreateResolution(settings);
            contentManager = new ContentManager();
            inputChecker = new InputChecker();
            screenManager = new RallyTheRobotsScreenManager();
            screenManager.SetContentManager(contentManager);
            screenManager.SetResolution(resolutionFactory);
            screenManager.SetInputChecker(inputChecker);
        }
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            screenManager.Initialize();
            base.Initialize();
        }
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            //Create bitmap finder file
            ImageToStream.WriteImageToFile(GraphicsDevice, "Content\\Test_bitmap.png", "Content\\Test_bitmap.raw");

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            contentManager.LoadContent(GraphicsDevice);
            screenManager.EnterStartScreen(new GameTime(), settings);
        }
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            screenManager.Update(gameTime, settings, gameStatus);
            if (gameStatus.RunningStatus == RunningStatusEnum.Exiting)
                Exit();
            base.Update(gameTime);
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, Resolution.TransformationMatrix());
            GraphicsDevice.Clear(Color.Black);
            screenManager.Draw(gameTime, GraphicsDevice, settings, spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
