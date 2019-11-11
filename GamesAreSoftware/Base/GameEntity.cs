using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GamesAreSoftware.Base
{
    public abstract class GameEntity : DrawableEntity
    {
        public GameEntity(Texture2D texture, Vector2 position, Color color) : base(texture, position, color)
        { }

        public virtual void Init()
        { }
        
        public bool Collide(GameEntity collide)
            => this.Rectangle.Intersects(collide.Rectangle);        
    }
}
