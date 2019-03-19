using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UsingEventArgs
{
    class Alarm
    {
        public event EventHandler<AlarmEventArgs> OnalarmRaised = delegate { };
        public event EventHandler<AlarmEventArgs> OnalarmRaised2 = delegate { };

        public void RaiseAlarm(string location)
        {
            OnalarmRaised(this, new AlarmEventArgs(location));
        }

        public void RaiseAlarmAggregatingExceptions(string location)
        {
            List<Exception> exceptionList = new List<Exception>();

            foreach (Delegate handler in OnalarmRaised2.GetInvocationList())
            {
                try
                {
                    handler.DynamicInvoke(this, new AlarmEventArgs(location));
                }
                catch (TargetInvocationException e)
                {
                    exceptionList.Add(e.InnerException);
                }
            }

            if (exceptionList.Count > 0)
            {
                throw new AggregateException(exceptionList);
            }
        }

    }
}
