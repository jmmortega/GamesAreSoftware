using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamesAreSoftware.Base;
using GamesAreSoftware.Entity;
using Microsoft.Xna.Framework;

namespace GamesAreSoftware.Services
{
    public class PhysicsService : IPhysicsService
    {
        public float PaddleMovement => 5;

        public float BallSpeed => 3;

        public bool CheckBounds(GameEntity entity)
        {
            if (entity.Position.Y <= 0 || (entity.Position.Y + entity.Texture.Height) >= Locator.ScreenBounds.Height)
            {
                return true;
            }
            
            return false;                
        }

        public Vector2 CheckPaddleCollideWithBall(Paddle paddle, Ball ball)
        {
            if(paddle.Rectangle.Intersects(ball.Rectangle))
            {
                return CalculateVelocity(paddle, ball);
            }
            else
            {
                return Vector2.Zero;
            }
        }

        private Vector2 CalculateVelocity(Paddle paddle, Ball ball)
        {
            int productY = DetectProductInYFromPaddleInBall(paddle, ball);
            int productX = DetectProductInXFromPaddleInBall(paddle);

            return new Vector2(productX * BallSpeed, productY * BallSpeed);
        }

        private int DetectProductInYFromPaddleInBall(Paddle paddle, Ball ball)
        {
            var collidePositionInPaddle = (paddle.Position.Y + paddle.Texture.Height) - ball.Position.Y;

            if ((paddle.Texture.Height / 2) > collidePositionInPaddle)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        private int DetectProductInXFromPaddleInBall(Paddle paddle)
        {
            if(paddle.GetType() == typeof(LeftPaddle))
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public Vector2 CheckBallCollideWithWall(Court court, Ball ball)
        {
            if(court.Position.Y > ball.Position.Y ||                
                court.Position.Y + court.Rectangle.Height < ball.Position.Y)
            {
                return CalculateVelocity(ball, court);
            }
            return Vector2.Zero;
        }

        private Vector2 CalculateVelocity(Ball ball, Court court)
        {            
            int prodY = DetectProductInYFromCourtInBall(ball, court);

            return new Vector2(ball.Movement.X, prodY * BallSpeed);
        }
                
        private int DetectProductInYFromCourtInBall(Ball ball, Court court)
        {
            if(ball.Position.Y < court.Position.Y)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
