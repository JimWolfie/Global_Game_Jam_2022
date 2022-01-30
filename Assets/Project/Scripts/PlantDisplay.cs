using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

namespace GGJ
{
    public class PlantDisplay : MonoBehaviour
    {
        public UI_Event btn;
        public StateManager sm;
        public GameEventManager gm;

        [SerializeField]
        TextAsset _file;

        public textObj helloLines;

        public textObj goodbyeLines;

        public textObj feedLines;
        public textObj waterLines;
        public textObj communction;

        public textObj overfeed;
        public textObj underfeed;
        public textObj overwater;
        public textObj underwater;
        public textObj neglect;
        public textObj annoy;

        public TextMeshProUGUI talking;

        public SpriteRenderer plantDisplayed;
        public Sprite[] possibleSprites;
        public Sprite goodSprite;
        public Sprite bestSprite;
       

         void Start()
         {
            
            UpdatePlantDisplay(ref gm.currentDayFlagValue);
           
         }
         
       


        public void UpdatePlantDisplay(ref RFFs flagCheck)
        {
            if(!((int)gm.currentDaySucccess > 0))
            {
                plantDisplayed.sprite = possibleSprites[(int)flagCheck];
            }else if((int)gm.currentDaySucccess > 32)
            {
                plantDisplayed.sprite = goodSprite;
            } else
            {
                plantDisplayed.sprite = bestSprite;
            }
            
        }

        private void HelloLine(int index)
        {
            talking.SetText("Hello again");
            return;
        }
        private void goodbye(int index)
        {
            talking.SetText("check back tomorrow okay!");
            return;
        }
        private void justwateredLine(int index)
        {
            talking.SetText("thanks for the water");
            return;
        }
        private void justfedLine(int index)
        {
            talking.SetText("thanks for the meal and fertilizer");
            return;
        }
        private void justtalkedLine(int index)
        {
            talking.SetText("that's interesting and neat and cool");
            return;
        }


    }
}
