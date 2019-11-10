using Microsoft.Xna.Framework;

namespace GamesAreSoftware.Services
{
    public interface IDrawableService
    {
        void Draw(GameTime gameTime, IDrawableEntity drawableEntity);
    }
}
