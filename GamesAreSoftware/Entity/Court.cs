using GamesAreSoftware.Base;
using GamesAreSoftware.Services;
using Microsoft.Xna.Framework;

namespace GamesAreSoftware.Entity
{
    public class Court : GameEntity
    {
        private readonly IGameControls _gameControls;

        private LeftPaddle _leftPaddle;
        private RightPaddle _rightPaddle;
        private Ball _gameBall;

        public Court(IGameControls gameControls, IPhysicsService physicsService) : base(Locator.Get<IContentManagerService>().GetTexture("court"), Vector2.Zero, Color.White)
        {
            _gameControls = gameControls;
            _leftPaddle = new LeftPaddle(gameControls, physicsService);
            _rightPaddle = new RightPaddle(gameControls, physicsService);
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
            if(_gameControls.CheckControlsGame(gameTime))
            {
                Locator.CurrentGame.Exit();
            }
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
