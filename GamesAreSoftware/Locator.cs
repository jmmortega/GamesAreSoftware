using GamesAreSoftware.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAreSoftware
{
    public static class Locator
    {
        public static Game CurrentGame { get; private set; }
        public static GraphicsDevice CurrentGraphicsDevice { get; private set; }
        public static ContentManager CurrentContentManager { get; private set; }

        public static SpriteFont DefaultFont { get; private set; }

        public static Rectangle ScreenBounds => CurrentGraphicsDevice.Viewport.Bounds;


        public static void Init(Game currentGame, GraphicsDevice graphicsDevice, ContentManager contentManager, SpriteFont defaultFont)
        {
            CurrentGame = currentGame;
            CurrentGraphicsDevice = graphicsDevice;
            CurrentContentManager = contentManager;
            DefaultFont = defaultFont;

            ArrangeServices();
        }

        private static void ArrangeServices()
        {
            var spriteBatchService = new SpriteBatchService(new SpriteBatch(CurrentGraphicsDevice));
            var physicsService = new PhysicsService();
            var settingsService = new SettingsService();

            services = new Dictionary<Type, object>()
            {                
                { typeof(IDrawableService), new DrawableService(spriteBatchService) },
                { typeof(IContentManagerService), new ContentManagerService(CurrentContentManager) },
                { typeof(ISpriteBatchService), spriteBatchService },
                { typeof(IPhysicsService), physicsService },
                { typeof(ISettingsService), settingsService },
                { typeof(IGameControls), new GameControls(physicsService, settingsService) }
                
            };
        }

        //Initialize main services
        private static Dictionary<Type, object> services;

        public static void Register<T>(object implementation) => services[typeof(T)] = implementation;

        public static T Get<T>() => (T)services[typeof(T)];

    }
}
