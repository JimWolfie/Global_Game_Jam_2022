using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace GGJ
{
    public class PlantDisplay : MonoBehaviour
    {
        public UI_Event btn;
        public StateManager sm;
        public GameEventManager gm;

        string[] helloLines;

        string[] goodbyeLines;

        string[] feedLines;
        string[] waterLines;
        string[] communction;

        string[] overfeed;
        string[] underfeed;
        string[] overwater;
        string[] underwater;
        string[] neglect;
        string[] annoy;

        public void Start()
        {
            HelloLine();
        }

        private void HelloLine()
        {
            throw new NotImplementedException();
        }
        private void OnValidate()
        {
            var lines = File ? _file.text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries) : null;
            _items = Newlist(lines);
            Debug.Log(_items);
        }
    }
}
