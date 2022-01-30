using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace GGJ
{
    public class GameEventManager : MonoBehaviour
    {
        public DateTime previousDayApplicationEnd;
        public  DateTime startTime;//when application was loaded today
        public DatedEvents NextEvent;
        private List<DatedEvents> _EventList = null;
        public RFFs previousDayFlagValue;
        public RFFs currentDayFlagValue;
        public Timer timer;

        

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
            
            if(NextEvent==null)
            {
                DatedEvents q = _EventList.OrderByDescending(T => T.eventTime).FirstOrDefault();
                NextEvent = q;
                return;
            }
            
            if(NextEvent.LessThan1Hour(out float duration))
            {
                timer.StartNewTimer(duration, NextEvent.context);
                NextEvent=null;
                return;
            }
            return;
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
            previousDayApplicationEnd = DateTime.Parse(dateString, 
                System.Globalization.CultureInfo.InvariantCulture);
        }

      
    }
    

}
