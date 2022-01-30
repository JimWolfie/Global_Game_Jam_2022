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

        
        bool enables = false;

        public string context;
        
        public StateManager sm;
        public GameEventManager gm;
        

        private void Start()
        {
            //UpdateTimer();

        }
        public void LateUpdate()
        {
            
        }


        public IEnumerator UpdateTimer()
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
            ToggleEnables();
            sm.HandleOutcome(context);
            gm.CheckListForMissingEventType();
            

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
            StartCoroutine(UpdateTimer());
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
