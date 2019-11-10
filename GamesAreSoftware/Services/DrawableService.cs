using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GamesAreSoftware.Services
{
    public class DrawableService : IDrawableService
    {
        private readonly ISpriteBatchService _spriteBatchService;

        public DrawableService(ISpriteBatchService spriteBatchService)
        {
            _spriteBatchService = spriteBatchService;
        }
        public void Draw(GameTime gameTime, IDrawableEntity drawableEntity)
            => _spriteBatchService.Draw(drawableEntity.Texture, drawableEntity.Position, drawableEntity.Color);
    }
}
