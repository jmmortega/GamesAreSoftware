using GamesAreSoftware.Base;
using GamesAreSoftware.Services;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAreSoftware.Entity
{
    public class Court : GameEntity
    {
        private Paddle _leftPaddle;
        private Paddle _rightPaddle;
        private Ball _gameBall;

        public Court() : base(Locator.Get<IContentManagerService>().GetTexture("court"), Vector2.Zero, Color.White)
        {
            _leftPaddle = new Paddle();
            _rightPaddle = new Paddle();
            _gameBall = new Ball();
        }

        public override void Init()
        {
            base.Init();
            _leftPaddle.Position = new Vector2(10, Locator.ScreenBounds.Center.Y);
            _rightPaddle.Position = new Vector2(Locator.ScreenBounds.Right - 50, Locator.ScreenBounds.Center.Y);
            _gameBall.Position = Locator.ScreenBounds.Center.ToVector2();
        }

        public override void Update(GameTime gameTime)
        {
            _leftPaddle?.Update(gameTime);
            _rightPaddle?.Update(gameTime);
            _gameBall?.Update(gameTime);               
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            _leftPaddle?.Draw(gameTime);
            _rightPaddle?.Draw(gameTime);
            _gameBall?.Draw(gameTime);            
        }
    }
}
