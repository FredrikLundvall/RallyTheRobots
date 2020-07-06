﻿using Microsoft.Xna.Framework;
using ResolutionBuddy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots
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
            // Change Virtual Resolution
#if DEBUG
            //resolution = new ResolutionComponent(game, graphics, new Point(1920, 1080), new Point(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height), true, true);
            _resolution = new ResolutionComponent(_game, _graphics, new Point(1920, 1080), new Point(800, 600), settings.GetFullscreen(), true);
#else
            _resolution = new ResolutionComponent(this, graphics, new Point(1920, 1080), new Point(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height), settings.Fullscreen, true);
#endif

        }
        public IResolution GetResolution()
        {
            return _resolution;
        }
    }
}