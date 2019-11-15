using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamesAreSoftware.Entity;

namespace GamesAreSoftware.Services
{
    public class JudgeService : IJudgeService
    {
        public int MatchPoint => 5;        

        public bool ItsPoint(Court court, Ball ball)
        {
            return ball.Position.X < court.Position.X ||
               ball.Position.X > court.Rectangle.Width;
        }

        public int PointFor(Court court, Ball ball)
        {
            if(ball.Position.X < court.Position.X)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        public bool GameEnd(int leftScore, int rightScore)
        {
            return leftScore == MatchPoint || rightScore == MatchPoint;
        }
    }
}
