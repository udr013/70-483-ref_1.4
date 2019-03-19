using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingEventArgs
{
    class Program
    {

        static void AlarmListener1(object source, AlarmEventArgs args)
        {
            Console.WriteLine("Alarm listener 1 is called");
            Console.WriteLine("Alarm in {0}", args.Location);
        }

        static void AlarmListener2(object source, AlarmEventArgs args)
        {
            Console.WriteLine("Alarm listener 1 is called");
            Console.WriteLine("Alarm in {0}", args.Location);
            throw new Exception("Bang");
        }

        static void AlarmListener3(object source, AlarmEventArgs args)
        {
            Console.WriteLine("Alarm listener 1 is called");
            Console.WriteLine("Alarm in {0}", args.Location);
            throw new Exception("Boom");
        }

        static void Main(string[] args)
        {
            Alarm alarm = new Alarm();

            alarm.OnalarmRaised += AlarmListener1;
            alarm.OnalarmRaised2 += AlarmListener2;
            alarm.OnalarmRaised2 += AlarmListener3;

            alarm.RaiseAlarm("Amsterdam");

            try
            {
                alarm.RaiseAlarmAggregatingExceptions("bla");
                alarm.RaiseAlarmAggregatingExceptions("blabla");
            }
            catch(AggregateException agg)
            {
                foreach(Exception e in agg.InnerExceptions)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine("Alarm Raised");
            Console.ReadKey();
        }
    }
}
