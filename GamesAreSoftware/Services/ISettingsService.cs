using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAreSoftware.Services
{
    public interface ISettingsService
    {
        Keys PaddleLeftUpKey { get; }
        Keys PaddleLeftDownKey { get; }

        Keys PaddleRightUpKey { get; }

        Keys PaddleRightDownKey { get; }
    }
}
