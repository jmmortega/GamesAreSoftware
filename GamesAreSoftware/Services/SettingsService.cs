using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace GamesAreSoftware.Services
{
    public class SettingsService : ISettingsService
    {
        public Keys PaddleLeftUpKey => Keys.W;

        public Keys PaddleLeftDownKey => Keys.S;

        public Keys PaddleRightUpKey => Keys.Up;

        public Keys PaddleRightDownKey => Keys.Down;
    }
}
