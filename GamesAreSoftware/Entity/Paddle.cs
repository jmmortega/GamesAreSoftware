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
    public class Paddle : GameEntity
    {
        public Paddle() : base(Locator.Get<IContentManagerService>().GetTexture("paddleblue"), Vector2.Zero, Color.White)
        { }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
