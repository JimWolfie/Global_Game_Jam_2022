using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace GGJ
{
    public class GameEventManager : MonoBehaviour
    {
        public DateTime previousDay;
        public  DateTime startTime;//when application was loaded today
        public DateTime NextEvent;
        private List<DatedEvents> _EventList = null;
        public RFFs previousDayFlagValue;
        private RFFs currentDayFlagValue;

        

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

        

        public void CreateNewNeedEvent(string context)
        {
            if(_EventList!=null && !(_EventList.Count>3) )
            {
                QueueEvent(new DatedEvents(context));
            }
            
        }
        private void QueueEvent(DatedEvents newEvent)
        {
            bool sametype = false;
            foreach(DatedEvents e in _EventList)
            {
                
                if(!sametype && e.CompareContext(newEvent))
                {
                    DatedEvents mostRecent;
                    bool t = e.ReturnMostRecent(newEvent, out mostRecent);
                    if(t)
                    {
                        _EventList.Add(mostRecent);
                    }
                    sametype = true;
                }
            }
            if(sametype==false)
            {
                _EventList.Add(newEvent);
            }
        }
        public void PopNextEvent()
        {
            if(_EventList.Count>0)
            {
                DatedEvents q = _EventList.OrderByDescending(T => T.eventTime).FirstOrDefault();
                NextEvent = q.eventTime;
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
