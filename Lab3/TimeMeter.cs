using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class TimeMeter
    {
        private Stopwatch stopwatch;

        public TimeMeter()
        {
            stopwatch = new Stopwatch();
        }

        public void Start()
        {
            stopwatch.Restart();
        }

        public TimeSpan Stop()
        {
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
    }
}
