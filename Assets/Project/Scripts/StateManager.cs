using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ
{
    public class StateManager : MonoBehaviour
    {
        //determines the current flag values
        
        
        public UI_Event ui_ref; // reference to the display
        public EventOutcome _Outcome; //handled in ui. tracks overclicking
        public GameEventManager gm; //reference to gm to track events

        #region results of events

        public void HandleOutcome(string context)
        {
            
            switch(context)
            {
                case "food":
                FoodResult();
                return;
                case "water":
                WaterResult();
                return;
                case "interaction":
                InteractionResult();
                return;
            }

        }
        void FoodResult()
        {
            var o = (int)ui_ref.food;
            if(gm.currentDayFlagValue.HasFlag(RFFs.UnderFedFood))
            {
                 

            }
            if(gm.currentDayFlagValue.HasFlag(RFFs.OverFedFood))
            {


            }

            //setbit flag
        }
        void WaterResult()
        {
            var o = (int)_Outcome;
            if(0!=1)
            {
                //set bitflag
            }
            //set bit flag
        }
        void InteractionResult()
        {
            var o = (int)_Outcome;
            if(0!=1)
            {
                //set bitflag
            }

        }
        /*
        void genericResult()
        {
         if [do thing] to [underthing]
            underthing flag removed
         if [does thing] to [healthy thing 
            +1success
         if does thing to overthing => remove overthing
         if [too thing] => success to none

        }*/
        #endregion
        

    }
}
