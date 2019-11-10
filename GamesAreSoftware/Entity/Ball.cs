using GamesAreSoftware.Base;
using GamesAreSoftware.Services;
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
        public Ball() : base(Locator.Get<IContentManagerService>().GetTexture("ball"), Vector2.Zero, Color.White)
        { }
        
        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
