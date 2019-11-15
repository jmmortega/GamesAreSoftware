using System;
using GamesAreSoftware.Base;
using GamesAreSoftware.Services;
using Microsoft.Xna.Framework;

namespace GamesAreSoftware.Entity
{
    public class Court : GameEntity
    {
        private readonly IGameControls _gameControls;
        private readonly IPhysicsService _physicsService;
        private readonly IJudgeService _judgeService;

        private LeftPaddle _leftPaddle;
        private RightPaddle _rightPaddle;
        private Ball _gameBall;

        private int _leftScore;
        private int _rightScore;

        public Court(IGameControls gameControls, IPhysicsService physicsService, IJudgeService judgeService) : base(Locator.Get<IContentManagerService>().GetTexture("court"), Vector2.Zero, Color.White)
        {            
            _gameControls = gameControls;
            _physicsService = physicsService;
            _judgeService = judgeService;

            _leftPaddle = new LeftPaddle(gameControls, physicsService);
            _rightPaddle = new RightPaddle(gameControls, physicsService);
            _gameBall = new Ball(physicsService);

            Rectangle = new Rectangle(this.Position.ToPoint(), new Point(Locator.ScreenBounds.Width, Locator.ScreenBounds.Height));
        }

        public override void Init()
        {
            base.Init();
            _leftPaddle.Position = new Vector2(10, Locator.ScreenBounds.Center.Y);
            _rightPaddle.Position = new Vector2(Locator.ScreenBounds.Right - 50, Locator.ScreenBounds.Center.Y);
            _gameBall.Position = Locator.ScreenBounds.Center.ToVector2();
            _gameBall.Init();
        }

        public override void Update(GameTime gameTime)
        {
            if (_gameControls.CheckControlsGame(gameTime))
            {
                Locator.CurrentGame.Exit();
            }
            _leftPaddle?.Update(gameTime);
            _rightPaddle?.Update(gameTime);
            _gameBall?.Update(gameTime);

            CheckCollisionsWithBall();
            CheckTherePoint();
            
            if(_judgeService.GameEnd(_leftScore, _rightScore))
            {
                //GameEnds
                Locator.CurrentGame.Exit();
            }            
        }        

        private void CheckCollisionsWithBall()
        {
            var leftCollide = _physicsService.CheckPaddleCollideWithBall(_leftPaddle, _gameBall);
            var rightCollide = _physicsService.CheckPaddleCollideWithBall(_rightPaddle, _gameBall);
            var courtCollide = _physicsService.CheckBallCollideWithWall(this, _gameBall);

            _gameBall.ChangeMovementFromCollide(leftCollide);
            _gameBall.ChangeMovementFromCollide(rightCollide);
            _gameBall.ChangeMovementFromCollide(courtCollide);
        }

        private void CheckTherePoint()
        {
            if(_judgeService.ItsPoint(this, _gameBall))
            {
                if(_judgeService.PointFor(this, _gameBall) == -1)
                {
                    _leftScore++;
                }
                else
                {
                    _rightScore++;
                }
                RestartBall();
            }            
        }

        private void RestartBall()
        {
            _gameBall.FirstStart(this.Rectangle.Center.ToVector2());
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
