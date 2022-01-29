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
   
    public class DatedEvents
    {
        public DateTime eventTime;
        public string context;
        public DatedEvents(DateTime eventTime, string context)
        {
            this.eventTime = eventTime;
            this.context = context;
        }
        public DatedEvents(string context)
        {
            this.eventTime = DateTime.Now + new TimeSpan(
                UnityEngine.Random.Range(1, 3),
                UnityEngine.Random.Range(1, 8),
                UnityEngine.Random.Range(1, 30),
                UnityEngine.Random.Range(1, 60));
            this.context = context;
        }

        public bool CompareContext(DatedEvents dateToCompare)
        {
            var d = dateToCompare;
            var sameCtx = this.context.Equals(d.context);
            
            if(sameCtx)
            {
                //not same context we can move on. 
                
                return true; 
            }else
            {
                return false;
            }
        }

        public bool ReturnMostRecent( DatedEvents dateToCompare, out DatedEvents mostRecent)
        {
            //return ture if we do anything further, return false if its just the comparing object

            var b = CompareContext(dateToCompare);
            if(!b)
            {
                mostRecent = null;
                return false;
            }
            var d = (this.eventTime.CompareTo(dateToCompare.eventTime));
            switch(d)
            {
                case -1://this date is earlier
                    mostRecent = this;
                    return false;
                case 0://date is the same
                    mostRecent = this;
                    return false;
                case 1://this date is later
                    mostRecent = dateToCompare;
                    return true;
                default://return calling, probalby no need
                    mostRecent = this;
                    return false;
            }

        }
    }
}
