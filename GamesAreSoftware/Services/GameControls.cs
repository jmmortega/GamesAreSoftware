using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GamesAreSoftware.Services
{
    public class GameControls : IGameControls
    {
        private readonly IPhysicsService _physicsService;
        private readonly ISettingsService _settingsService;

        public GameControls(IPhysicsService physicsService, ISettingsService settingsService)
        {
            _physicsService = physicsService;
            _settingsService = settingsService;            
        }

        public Vector2 CheckControlsPaddleLeft(GameTime gameTime)
            => CheckControl(_settingsService.PaddleLeftUpKey, _settingsService.PaddleLeftDownKey, _physicsService.PaddleMovement);

        public Vector2 CheckControlsPaddleRight(GameTime gameTime)
            => CheckControl(_settingsService.PaddleRightUpKey, _settingsService.PaddleRightDownKey, _physicsService.PaddleMovement);
        
        private Vector2 CheckControl(Keys upKey, Keys downKey, float paddleMov)
        {
            var paddleMovement = new Vector2(0, paddleMov);

            if (Keyboard.GetState().IsKeyDown(upKey))
            {
                return -paddleMovement;
            }

            if (Keyboard.GetState().IsKeyDown(downKey))
            {
                return paddleMovement;
            }

            return Vector2.Zero;
        }

        public bool CheckControlsGame(GameTime gameTime)
            => GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || 
               Keyboard.GetState().IsKeyDown(Keys.Escape);        
    }
}
