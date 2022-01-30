using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

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

        public void Start()
        {
            HelloLine();
        }

        private void HelloLine()
        {
            throw new NotImplementedException();
        }
        
        private void NewList(string[] lines)
        {

        }
       
    }
}
