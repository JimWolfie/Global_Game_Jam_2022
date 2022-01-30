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

        public Sprite plantHealthy;
        public GameObject plantDead;
        public GameObject plantWilting;
        public GameObject plantBudding;
        public GameObject plantBloom;


         void Start()
        {
           
           
        }

        private void HelloLine(int index)
        {
            //talking.SetText(helloLines._text[index]);
        }
        
        public void ToggleHealthy()
        {

        }
       
    }
}
