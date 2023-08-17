using System;

namespace WeddingManagement
{
    internal class Shift
    {
        public string ShiftNo;
        public string ShiftName;
        public TimeSpan Starting;
        public TimeSpan Ending;

        public Shift(string ShiftNo, string ShiftName, TimeSpan Starting, 
            TimeSpan Ending)
        {
            this.ShiftNo = ShiftNo;
            this.ShiftName = ShiftName;
            this.Starting = Starting;
            this.Ending = Ending;
        }

        public Shift()
        {
        }
    }
}
