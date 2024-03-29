﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GamesAreSoftware.Services
{
    public interface ISpriteBatchService
    {
        void Begin();
        void End();
        void Draw(Texture2D texture, Vector2 position, Color color);
    }
}
