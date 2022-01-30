using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GGJ
{
    [CreateAssetMenu(fileName = "new text component", menuName = "new text")]
    public class textObj : ScriptableObject
    {
        public TextAsset t_text;
        public string[] _text;

        private void OnValidate()
        {
            var content = t_text.text;
            var AllWords = content.Split("\n");
            _text = new List<string>(AllWords).ToArray();
        }

        public string lineAtIndex (int index)
        {
            if(index < _text.Length)
            {
                return _text[index];
            }
            return "";
        }
    }
     
}
