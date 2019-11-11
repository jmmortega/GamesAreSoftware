using GamesAreSoftware.Services;
using Microsoft.Xna.Framework;
using System;

namespace GamesAreSoftware.Entity
{
    public class RightPaddle : Paddle
    {
        public RightPaddle(IGameControls gameControls, IPhysicsService physicsService) : base(gameControls, physicsService)
        {
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if(CanMove)
            {
                Position += _gameControls.CheckControlsPaddleRight(gameTime);
            }
            else
            {
                Position = new Vector2(Position.X, Math.Abs(Position.Y - 1));
            }
        }            
    }
}
