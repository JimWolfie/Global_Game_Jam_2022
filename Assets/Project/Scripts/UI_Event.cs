using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace GGJ
{
    public class UI_Event : MonoBehaviour
    {
        public bool waterEventPressed;
        public bool feedEventPressed;
        public bool interactEventPressed;


        public void Water()
        {
            Debug.Log("I have been watered");
        }

        public void Feed()
        {
            Debug.Log("I have been Fed");
        }
        public void Interact()
        {
            Debug.Log("I have been dated");
        }


    }
}
