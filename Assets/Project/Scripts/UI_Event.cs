using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace GGJ
{
    public class UI_Event : MonoBehaviour
    {
        public EventOutcome food;
        public EventOutcome water ;
        public EventOutcome interaction ;


        public void Water()
        {
            Debug.Log("I have been watered");
            if((int)water ==2)
            {
                Debug.Log("Stop that's too much!!!");
                return;
            }
            water +=1;
            
        }

        public void Feed()
        {
            Debug.Log("I have been Fed");
            Debug.Log("I have been fed");
            if((int)food ==2)
            {
                Debug.Log("Stop that's too much!!!");
                return;
            }
            food +=1;

        }
        public void Interact()
        {
            Debug.Log("I have been interacted");
            if((int)interaction ==2)
            {
                Debug.Log("Stop that's too much!!!");
                return;
            }
            interaction +=1;

        }


    }
}
