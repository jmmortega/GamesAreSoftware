using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GamesAreSoftware.Services
{
    public interface IDrawableEntity : IDrawable
    {
        Vector2 Position { get; set; }
        Texture2D Texture { get; }
        Color Color { get; set; }

        Rectangle Rectangle { get; set; }
    }
}
