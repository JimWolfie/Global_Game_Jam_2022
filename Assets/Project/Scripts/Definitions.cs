using System;



namespace GGJ
{
    public class Definitions 
    {
       
    }

    [Flags]
    public enum RFFs
    {
        //Relationship Failure Flags
        None = 0,
        OverWatered = 1,
        OverFedFood = 2,
        OverInteracted = 4,
        UnderWaterd = 8,
        UnderFedFood = 16,
        UnderInteracted = 32,
        NoProblems = 64
    }
    public class RandomDateTimeInts
    {
        public int Days;
        public int Hours;
        public int Minutes;
        public int Seconds;
        public RandomDateTimeInts()
        {
           
            Days = UnityEngine.Random.Range(1, 3);

            Hours = UnityEngine.Random.Range(1, 8);
            Minutes = UnityEngine.Random.Range(1, 30);
            Seconds = UnityEngine.Random.Range(1, 60);
        }
    }
    public class DatedEvents
    {
        public DateTime eventTime;
        public string context;
        public DatedEvents(DateTime eventTime, string context)
        {
            this.eventTime = eventTime;
            this.context = context;
        }
    }
}
