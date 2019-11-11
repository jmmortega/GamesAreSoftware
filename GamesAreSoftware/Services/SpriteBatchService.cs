using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GamesAreSoftware.Services
{
    public class SpriteBatchService : ISpriteBatchService
    {
        private readonly SpriteBatch _spriteBatch;
        private bool _beginStarted;

        public SpriteBatchService(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
        }

        public void Begin()
        {
            _spriteBatch.Begin();
            _beginStarted = true;
        }

        public void End()
        {
            _spriteBatch.End();
            _beginStarted = false;
        }

        public void Draw(Texture2D texture, Vector2 position, Color color)
        {
            if(_beginStarted)
            {
                _spriteBatch.Draw(texture, position, color);
            }            
        }
            

        
    }
}
