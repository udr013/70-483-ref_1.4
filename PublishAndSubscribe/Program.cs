using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishAndSubscribe
{
    class Alarm
    {
        ///Delegate for the alarm event (Action is the simplest delegate) thou in this way not secure OnAlarm raised is public and can even be overriden
        public Action OnAlarmRaised { get; set; }

        ///Called to raise an alarm
        public void Raisealarm()
        {
            ///Only raise the alarm if someone has subscribed
            //if(OnAlarmRaised != null)
            //{
            //    OnAlarmRaised();
            //}
            //this if statement can be shortend to:
            OnAlarmRaised?.Invoke();
        }
    }

    class Alarm2
    {
        ///better use event constructor by addign event keyword, now it's a field instead of a property 
        ///and has no get and set so no values can be assigned externally
        public event Action OnAlarmRaised = delegate { };

        ///Called to raise an alarm
        public void Raisealarm()
        {   /// it is no longer needed to do check for null, it now gets assigned when the instance is created
            OnAlarmRaised();
        }
    }

    class Alarm3
    {

        /// eventHandler is the proper way in .NET to handle events
        public event EventHandler OnAlarmRaised = delegate { };

        ///Does not provide any events arguments
        public void Raisealarm()
        {
            Console.WriteLine("we are here: Alarm3");
            ///the event handler receives a reference to the alarm that is raising this event
            OnAlarmRaised(this, EventArgs.Empty);
        }
    }

    class Program
    {
        ///Method that must run when the alarm is raised
        static void AlarmListner1(object sender, EventArgs e)
        {
            Console.WriteLine("Alarm listner 1 called");
        }

        ///Method that must run when the alarm is raised
        static void AlarmListner2()
        {
            Console.WriteLine("Alarm listner 2 called");
        }

        static void Main(string[] args)
        {
            ///Create a new Alarm
            Alarm alarm = new Alarm();
            Alarm2 alarm2 = new Alarm2();
            Alarm3 alarm3 = new Alarm3();

            ///subscribe the two listners fist to eventhandler other to Action
            alarm3.OnAlarmRaised += AlarmListner1;
            alarm2.OnAlarmRaised += AlarmListner2;

            ///unsubscribe a listner
            //alarm.OnAlarmRaised -= AlarmListner2;

            ///raise the alarm
            alarm.Raisealarm();
            Console.WriteLine("Alarm Raised");
            Console.ReadKey();


        }
    }
}

