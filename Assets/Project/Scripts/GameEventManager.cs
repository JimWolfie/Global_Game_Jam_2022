using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GGJ
{
    public class GameEventManager : MonoBehaviour
    {
        public DateTime previousDay;
        public  DateTime startTime;//when application was loaded today
        public DateTime NextEvent;
        public RFFs previousDayFlagValue;
        private RFFs currentDayFlagValue;
        private Queue<DatedEvents> _EventList = null;

        private void Awake()
        {
            startTime=System.DateTime.Now;
           
        }
        private void Start()
        {
            LoadPreviousFlag();
        }
        private void OnApplicationQuit()
        {
            SavePreviousFlag(currentDayFlagValue);

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
            _EventList.Enqueue(newEvent);
        }
        private void PopNextEvent()
        {
            DatedEvents result;
            var success= _EventList.TryDequeue(out result);
            if(success)
            {

            }
        }
       

        private void SavePreviousFlag(RFFs currentflags)
        {
            PlayerPrefs.SetInt("Relationship", (int)currentflags);
            PlayerPrefs.SetString("previousDay", DateTime.Now.ToString());
            
        }
        private void LoadPreviousFlag()
        {
            previousDayFlagValue = (RFFs)PlayerPrefs.GetInt("Relationship",64);

            var dateString = PlayerPrefs.GetString("previousDay");
            previousDay = DateTime.Parse(dateString, 
                System.Globalization.CultureInfo.InvariantCulture);
        }

    }
    

}
