using GamesAreSoftware.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAreSoftware.Services
{
    public interface IJudgeService
    {
        int MatchPoint { get; }

        bool ItsPoint(Court court, Ball ball);

        int PointFor(Court court, Ball ball);

        bool GameEnd(int leftScore, int rightScore);
    }
}
