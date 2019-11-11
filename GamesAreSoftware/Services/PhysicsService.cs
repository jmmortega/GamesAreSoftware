using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamesAreSoftware.Base;
using Microsoft.Xna.Framework;

namespace GamesAreSoftware.Services
{
    public class PhysicsService : IPhysicsService
    {
        public float PaddleMovement => 5;

        public Vector2 BallMovement => new Vector2(5, 5);

        public bool CheckBounds(GameEntity entity)
        {
            if (entity.Position.Y <= 0 || (entity.Position.Y + entity.Texture.Height) >= Locator.ScreenBounds.Height)
            {
                return true;
            }
            
            return false;                
        }
    }
}
