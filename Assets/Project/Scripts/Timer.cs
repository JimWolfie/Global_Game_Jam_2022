using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

namespace GGJ
{
    public class Timer: MonoBehaviour
    {
        [SerializeField]
        private float duration;

        [SerializeField]
        private float timer;

        [SerializeField]
        private TextMeshProUGUI display_Text;

        public EventOutcome _Outcome;
        bool enables = false;

        public string context;
        public GameEventManager gm;

        public UI_Event reference;

        private void Start()
        {
            UpdateTimer();

        }

       

        IEnumerator UpdateTimer()
        {
            //we failed
            //we update timer
            //we set failure

            while(timer >0.7f)
            {
                timer -= Time.deltaTime;
                UpdateDisplay(timer);
                yield return null;
            }
            DisplayOutcome();
          
        }

        private void DisplayOutcome()
        {
            ToggleEnables();
            switch(context)
            {
                case "food":
                    Debug.Log("Failed to feed");
                    return;
                case "water":
                    Debug.Log("fed the correct ammount");
                    return;
                case "interaction":
                    Debug.Log("too much food");
                    return;
            }

        }
        void FoodResult()
        {
            var o = (int)_Outcome;
            if(0!=1)
            {
                gm.currentDayFlagValue.HasFlag(RFFs.UnderWatered);
                
            }
            //setbit flag
        }
        void WaterResult()
        {
            var o = (int)_Outcome;
            if(0!=1)
            {
                //set bitflag
            }
            //set bit flag
        }
        void InteractionResult()
        {
            var o = (int)_Outcome;
            if(0!=1)
            {
                //set bitflag
            }

        }
        private void UpdateDisplay(float time)
        {
            if(enables)
            {
                var minutes = Mathf.FloorToInt(time/60);
                var seconds = Mathf.FloorToInt(time % 60);

                var currentTime = ""+minutes+":" + seconds;
                display_Text.SetText(currentTime);
            } else
            {
                display_Text.SetText("");
            }
        }

        private void ResetTimer(float duration)
        {
            ToggleEnables();
            timer = duration;
            UpdateDisplay(timer);
            StartCoroutine("UpdateTimer");
        }
        private void FailedEvent()
        {

            Debug.Log("we failed");
        }

        public void ToggleText()
        {
            if(!enables)
            {

                enables = true;
                UpdateDisplay(timer);

            } else if(enables)
            {

                display_Text.SetText("");
                enables= false;
            }

        }

        public void StartNewTimer(float duration, string context)
        {
            ResetTimer(duration);
            this.context = context;
        }

        public void ToggleEnables()
        {
            enables = true ? !enables : enables;
        }

    }
}
