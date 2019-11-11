using GamesAreSoftware.Services;
using Microsoft.Xna.Framework;
using System;

namespace GamesAreSoftware.Entity
{
    public class LeftPaddle : Paddle
    {
        public LeftPaddle(IGameControls gameControls, IPhysicsService physicsService) : base(gameControls, physicsService)
        {
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if(CanMove)
            {
                Position += _gameControls.CheckControlsPaddleLeft(gameTime);
            }        
            else
            {
                Position = new Vector2(Position.X, Math.Abs(Position.Y - 1));
            }
        }            
    }
}
