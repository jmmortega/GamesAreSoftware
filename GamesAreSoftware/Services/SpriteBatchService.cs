using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GamesAreSoftware.Services
{
    public class SpriteBatchService : ISpriteBatchService
    {
        private readonly SpriteBatch _spriteBatch;

        public SpriteBatchService(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
        }

        public void Draw(Texture2D texture, Vector2 position, Color color)
            => _spriteBatch.Draw(texture, position, color);
    }
}
