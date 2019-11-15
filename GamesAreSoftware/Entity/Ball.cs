using GamesAreSoftware.Base;
using GamesAreSoftware.Services;
using GamesAreSoftware.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAreSoftware.Entity
{
    public class Ball : GameEntity
    {
        private readonly IPhysicsService _physicsService;

        public Ball(IPhysicsService physicsService) : base(Locator.Get<IContentManagerService>().GetTexture("ball"), Vector2.Zero, Color.White)
        {
            _physicsService = physicsService;
        }

        private Vector2 _movement = Vector2.Zero;

        public Vector2 Movement
        {
            get => _movement;
            set
            {
                _movement = value;
                RaiseProperty();
            }
        }
        
        public override void Init()
        {
            base.Init();
            Movement = InitMovement();
        }

        private Vector2 InitMovement()
        {
            var rnd = new Random();            
            var prodX = rnd.NextAndExclude(-1, 1, new int[] { 0 });
            var prodY = rnd.NextAndExclude(-1, 1, new int[] { 0 });

            var vector = new Vector2(prodX * _physicsService.BallSpeed, prodY * _physicsService.BallSpeed);
            if(vector == Vector2.Zero)
            {
                return InitMovement();
            }
            else
            {
                return vector;
            }            
        }

        public override void Update(GameTime gameTime)
        {
            this.Position += Movement;               
        }

        public void ChangeMovementFromCollide(Vector2 vector)
        {
            if(vector != Vector2.Zero)
            {                
                Movement = vector;                
            }
        }

        public void FirstStart(Vector2 center)
        {
            Position = center;
            InitMovement();
        }
    }
}
