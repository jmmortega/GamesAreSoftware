using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GamesAreSoftware.Services
{
    public class ContentManagerService : IContentManagerService
    {
        private readonly ContentManager _contentManager;
        private Dictionary<string, Texture2D> resourceDictionary = new Dictionary<string, Texture2D>();

        public ContentManagerService(ContentManager contentManager)
        {
            _contentManager = contentManager;
        }
        
        public Texture2D LoadTexture(string resourceName, Texture2D texture)
        {
            var textureLoaded = GetTexture(resourceName);

            if (textureLoaded == null)
            {
                resourceDictionary[resourceName] = texture;
                textureLoaded = texture;
            }

            return textureLoaded;
        }

        public Texture2D GetTexture(string resourceName)
        {
            if (resourceDictionary.ContainsKey(resourceName))
            {
                return resourceDictionary[resourceName];
            }

            return null;
        }        
    }
}
