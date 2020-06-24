using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        ScreenManager screenManager;
        GameSettings settings;
        GameStatus gameStatus;
        IResolution _resolution;

        public RallyTheRobots()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            settings = new GameSettings();
            screenManager = new RallyTheRobotsScreenManager();
            gameStatus = new GameStatus();
            graphics.HardwareModeSwitch = true;

            this.Window.IsBorderless = true;
            this.Window.Position = new Point(0, 0);

            // Change Virtual Resolution 
#if DEBUG         
            _resolution = new ResolutionComponent(this, graphics, new Point(1920, 1080), new Point(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height), false, true);
#else
            _resolution = new ResolutionComponent(this, graphics, new Point(1920, 1080), new Point(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height), settings.Fullscreen, true);
#endif

            IsFixedTimeStep = false; // Setting this to true makes it fixed time step, false is variable time step.
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
            screenManager.Initialize();
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
            screenManager.LoadContent(GraphicsDevice);
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
            // TODO: Add your update logic here
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

            // TODO: Add your drawing code here
            screenManager.Draw(gameTime, GraphicsDevice, settings, spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
