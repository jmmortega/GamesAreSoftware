using Microsoft.Xna.Framework.Graphics;

namespace GamesAreSoftware.Services
{
    public interface IContentManagerService
    {
        Texture2D LoadTexture(string resourceName, Texture2D texture);
        Texture2D GetTexture(string resourceName);
    }
}
