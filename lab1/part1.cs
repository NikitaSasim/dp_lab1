using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class TimeStampSingleton
    {
        private static readonly TimeStampSingleton instance = new TimeStampSingleton();

        public static TimeStampSingleton GetInstance() => instance;

        private readonly DateTime creationTime;

        private TimeStampSingleton()
        {
            creationTime = DateTime.Now;
        }

        public override string ToString()
        {
            return creationTime.ToString(CultureInfo.InvariantCulture);
        }
    }
}
