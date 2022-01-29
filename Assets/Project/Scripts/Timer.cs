using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GGJ
{
    public class Timer : MonoBehaviour
    {
        [SerializeField]
        private float duration;

        [SerializeField]
        private float timer;

        [SerializeField]
        private TextMeshProUGUI display_Text;

        public bool failure{ get; private set; }
        bool enables = false;

        public string context;

        private void Start()
        {
            ResetTimer();
        }

        private void Update()
        {
                UpdateTimer();
        }

        private void UpdateTimer()
        {
            //we failed
            //we update timer
            //we set failure

            if(failure)
            {
                FailedEvent();

            }
            if(timer > 0 && !failure)
            {
                timer -= Time.deltaTime;
                UpdateDisplay(timer);

            }
            if(timer <0.7)
            {
                //we failed if we get here so call the method to update
                //and send events
                failure = true;
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
            }
        }

        private void ResetTimer()
        {
            timer = duration;
            UpdateDisplay(timer);
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
      
    }
}
