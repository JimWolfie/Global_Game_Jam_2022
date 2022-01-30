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

        public string[] helloLines;

        public string[] goodbyeLines;

        public string[] feedLines;
        public string[] waterLines;
        public string[] communction;

        public string[] overfeed;
        public string[] underfeed;
        public string[] overwater;
        public string[] underwater;
        public string[] neglect;
        public string[] annoy;

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
