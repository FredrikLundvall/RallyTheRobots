using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ResolutionBuddy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots.GUI.Common
{
    public class ResolutionFactory
    {
        protected ResolutionComponent _resolution;
        protected GraphicsDeviceManager _graphics;
        protected Game _game;
        public ResolutionFactory(Game game, GraphicsDeviceManager graphics)
        {
            _graphics = graphics;
            _game = game;
        }
        public void CreateResolution(GameSettings settings)
        {
            //Recreation of the resolution
            if (_resolution != null)
            {
                _game.Components.Remove(_resolution);
                _game.Services.RemoveService(typeof(IResolution));
            }
            _game.Window.IsBorderless = true;
            _graphics.HardwareModeSwitch = true;
            _game.IsFixedTimeStep = false; // Setting this to true makes it fixed time step, false is variable time step.
            _game.IsMouseVisible = true;
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
            // Change Virtual Resolution
#if DEBUG
            if (resolutionIsSupported)
                _resolution = new ResolutionComponent(_game, _graphics, new Point(1920, 1080), new Point(settings.GetWidth(), settings.GetHeight()), settings.GetFullscreen(), true);
            else
                _resolution = new ResolutionComponent(_game, _graphics, new Point(1920, 1080), new Point(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height), settings.GetFullscreen(), true);
#else
            if(resolutionIsSupported)
                _resolution = new ResolutionComponent(_game, _graphics, new Point(1920, 1080), new Point(settings.GetWidth(), settings.GetHeight()), settings.GetFullscreen(), true);
            else
                _resolution = new ResolutionComponent(_game, _graphics, new Point(1920, 1080), new Point(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height), settings.GetFullscreen(), true);
#endif

        }
        public IResolution GetResolution()
        {
            return _resolution;
        }
    }
}
