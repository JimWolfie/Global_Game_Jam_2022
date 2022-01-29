using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GGJ
{
    public class GameEventManager : MonoBehaviour
    {
        private DateTime previousDay;
        private DateTime startTime;//when application was loaded today
        private DateTime NextEvent;
        private RFFs previousFlagValue;
        private RFFs todaysFlagValue;

        private void Awake()
        {
            startTime=System.DateTime.Now;
           
        }
        private void Start()
        {
            Debug.Log(startTime);
            RFFs v = RFFs.OverFedFood;
            Debug.Log(v.ToString());
            Debug.Log(v+1);
        }

        private void Update()
        {
            if(DateTime.Now >= NextEvent)
            {
                
                PopNextEvent();
                
            }
        }

        public void CreateNewNeedEvent(string context)
        {
            var dt = new RandomDateTimeInts();
            var ev = new TimeSpan(dt.Days, dt.Hours, dt.Minutes, dt.Seconds);
            QueueEvent(new DatedEvents(DateTime.Now + ev, context));
        }
        private void QueueEvent(DatedEvents newEvent)
        {
            
        }
        private void PopNextEvent()
        {

        }
       

        private void SavePreviousFlag(RFFs currentflags)
        {
            PlayerPrefs.SetInt("Relationship", (int)currentflags);
            PlayerPrefs.SetString("previousDay", DateTime.Now.ToString());
            
        }
        private void LoadPreviousFlag()
        {
            previousFlagValue = (RFFs)PlayerPrefs.GetInt("Relationship",64);

            var dateString = PlayerPrefs.GetString("previousDay");
            previousDay = DateTime.Parse(dateString, 
                System.Globalization.CultureInfo.InvariantCulture);
        }

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
            var rand = new System.Random();
            Days = rand.Next();
            Hours = rand.Next();
            Minutes = rand.Next();
            Seconds = rand.Next();
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
