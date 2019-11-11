using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAreSoftware.Services
{
    public interface IGameControls
    {
        Vector2 CheckControlsPaddleLeft(GameTime gameTime);

        Vector2 CheckControlsPaddleRight(GameTime gameTime);
        
        bool CheckControlsGame(GameTime gameTime);
    }
}
