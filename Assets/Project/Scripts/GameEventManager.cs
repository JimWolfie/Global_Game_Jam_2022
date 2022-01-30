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
        public List<DatedEvents> _EventList {get; private set;} = null;
        public RFFs previousDayFlagValue;
        public RFFs currentDayFlagValue;

        public RSSs previousDaySuccess;
        public RSSs currentDaySucccess;

        public UI_Event et;

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
            if( !(_EventList.Count>3) )
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
        { //we pop on startup of application
            
            if(NextEvent==null)
            {
                DatedEvents q = _EventList.OrderByDescending(T => T.eventTime).FirstOrDefault();
                NextEvent = q;
                _EventList.Remove(q);
                
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
            PlayerPrefs.SetInt("Relationship", (int)currentflags); // fails
            PlayerPrefs.SetString("previousDay", DateTime.Now.ToString()); //fails
            PlayerPrefs.SetInt("Success", (int)currentDaySucccess);

            if(_EventList.Count>0)
            {
                foreach(DatedEvents d in _EventList)
                {
                    PlayerPrefs.SetString(d.context, d.eventTime.ToString());
                }
            }
            var nev = NextEvent;
            PlayerPrefs.SetString(nev.context, nev.eventTime.ToString());
            PlayerPrefs.SetInt("Food_Progress", (int)et.food);
            PlayerPrefs.SetInt("Water_Progress", (int)et.water);
            PlayerPrefs.SetInt("Interaction_Progress", (int)et.interaction);

        }
        private void LoadPreviousFlag()
        {
            previousDayFlagValue = (RFFs)PlayerPrefs.GetInt("Relationship", 64);
            previousDaySuccess = (RSSs)PlayerPrefs.GetInt("Success", 0);
            var dateString = PlayerPrefs.GetString("previousDay");

            previousDayApplicationEnd = DateTime.Parse(dateString,
                System.Globalization.CultureInfo.InvariantCulture);

            var f_event = PlayerPrefs.GetString("food", "food");
            var s_event = PlayerPrefs.GetString("interaction", "interaction");
            var w_event = PlayerPrefs.GetString("water", "water");

            et.food = (EventOutcome)PlayerPrefs.GetInt("Food_Progress",0);
            et.water = (EventOutcome)PlayerPrefs.GetInt("Water_Progress", 0);
            et.interaction = (EventOutcome)PlayerPrefs.GetInt("Interaction_Progress", 0);

            List_Init(f_event, s_event, w_event);
            PopNextEvent();
        }

        private void List_Init(string f_event, string s_event, string w_event)
        {
            if(f_event.Equals("food"))
            {
                CreateNewNeedEvent("food");
            } else
            {
                var w = new DatedEvents(DateTime.Parse(f_event,
                System.Globalization.CultureInfo.InvariantCulture), "food");
                QueueEvent(w);
            }

            if(s_event.Equals("interaction"))
            {
                CreateNewNeedEvent("interaction");
            } else
            {
                var w = new DatedEvents(DateTime.Parse(f_event,
                System.Globalization.CultureInfo.InvariantCulture), "interaction");
                QueueEvent(w);
            }

            if(w_event.Equals("water"))
            {
                CreateNewNeedEvent("water");
            } else
            {
                var w = new DatedEvents(DateTime.Parse(f_event,
                System.Globalization.CultureInfo.InvariantCulture), "water");
                QueueEvent(w);
            }
        }
        
        public void CheckListForMissingEventType()
        {
            if(_EventList.Count==0)
            {
                CreateNewNeedEvent("food");
                return;
            }
            var et = eventType.None;
            foreach(DatedEvents d in _EventList)
            {
                switch(d.context)
                {
                    case "food":
                        et += 1;
                        break;
                    case "water":
                        et+=2;
                        break;
                    case "interaction":
                        et+=4;
                        break;
                    default:
                        et+=0;
                        break;
                        
                }
                if(!(et.HasFlag(eventType.interaction)))
                {
                    CreateNewNeedEvent("interaction");
                }
                if(!(et.HasFlag(eventType.water)))
                {
                    CreateNewNeedEvent("water");
                }
                if(!(et.HasFlag(eventType.food)))
                {
                    CreateNewNeedEvent("food");
                }
            }

        }
      
    }
    

}
