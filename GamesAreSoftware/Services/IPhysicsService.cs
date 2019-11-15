using GamesAreSoftware.Base;
using GamesAreSoftware.Entity;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAreSoftware.Services
{
    public interface IPhysicsService 
    {
        float PaddleMovement { get; }

        float BallSpeed { get; }

        bool CheckBounds(GameEntity entity);

        Vector2 CheckPaddleCollideWithBall(Paddle paddle, Ball ball);

        Vector2 CheckBallCollideWithWall(Court court, Ball ball);
    }
}
