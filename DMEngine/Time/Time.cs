using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMEngine.Time
{
    public class Time
    {
        DateTime LastTime;

        public Time()
        {
            SetLastTime();
        }

        public void SetLastTime()
        {
            LastTime = DateTime.Now;
        }

        public double GetDeltaTime()
        {
            return (DateTime.Now - LastTime).TotalSeconds;
        }
    }
}
