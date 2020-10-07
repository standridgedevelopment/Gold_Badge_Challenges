using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInsurance
{
    class Driver
    {
        public double HowOftenSpeedLimit;
        public double HowOftenSwerve;
        public double HowOftenRollingStop;
        public double HowOftenFollowClosely;
        public decimal Score;
        public decimal ScoreAsPercentage
        {
            get
            {
                return Score / 40;
            }
        }
    }
}
