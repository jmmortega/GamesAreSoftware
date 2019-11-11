using GamesAreSoftware.Base;
using GamesAreSoftware.Services;
using Microsoft.Xna.Framework;

namespace GamesAreSoftware.Entity
{
    public abstract class Paddle : GameEntity
    {
        protected readonly IGameControls _gameControls;
        protected readonly IPhysicsService _physicsService;

        protected bool CanMove
        {
            get;private set;
        }

        public Paddle(IGameControls gameControls, IPhysicsService physicsService) : base(Locator.Get<IContentManagerService>().GetTexture("paddleblue"), Vector2.Zero, Color.White)
        {
            _gameControls = gameControls;
            _physicsService = physicsService;
        }

        public override void Update(GameTime gameTime)
        {
            CanMove = true;
            if (_physicsService.CheckBounds(this))
            {
                CanMove = false;
            }            
        }                    
    }
}
