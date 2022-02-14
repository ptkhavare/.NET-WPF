using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceCalculator
{
    internal class DistanceLogicManager
    {
        #region Properties

        private int speed;

        private int time;

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public int Time
        {
            get { return time; }
            set { time = value; }
        }
        #endregion

    }
}
