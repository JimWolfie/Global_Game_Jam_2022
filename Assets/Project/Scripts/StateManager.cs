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
        private bool f_u_food;
        private bool f_o_food;
        private bool f_u_water;
        private bool f_o_water;
        private bool f_u_inter;
        private bool f_o_inter;

        private int f_result;
        private int w_result;
        private int s_result;

        #region results of events

        public void HandleOutcome(string context)
        {
            cacheBools();
            
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
            
            if(f_u_food)
            {//if under fed
                switch(f_result)
                {
                    case 0:
                        //was not fed
                    gm.DisplayDeath();    
                    break;
                    case 1:
                    gm.currentDayFlagValue -= 2;

                    //fed exactly once
                    break;
                    case 2:
                    gm.currentDayFlagValue -= 2;
                    gm.currentDayFlagValue += 16;
                    gm.currentDaySucccess = RSSs.None;
                    //overfed
                    break;
                    default:
                    gm.currentDayFlagValue -= 2;
                    gm.currentDaySucccess = RSSs.None;
                    //error, default overfeed
                    break;
                }

            }
            else if(f_o_food)
            {//if overfed
                switch(f_result)
                {
                    case 0:
                        //no food
                        //remove overfeed add underfeed
                        gm.currentDayFlagValue -=16; //remove overfed
                        gm.currentDayFlagValue +=2; //add underfed
                    gm.currentDaySucccess = RSSs.None;
                    break;
                    case 1:
                        gm.currentDayFlagValue -=16;
                        //fed, remove flag. don't reward
                    break;
                    case 2:
                        gm.currentDaySucccess = RSSs.None;
                    break;
                    default:
                        //assume overfeed
                        gm.currentDaySucccess = RSSs.None;
                        
                    break;
                }

            }else if((int)gm.currentDayFlagValue ==64 )
            {
                switch(f_result)
                {
                    case 0:
                        gm.currentDayFlagValue-=64;
                        gm.currentDayFlagValue += 2;//no feed, add healthy
                    gm.currentDaySucccess = RSSs.None;

                    break;
                    case 1:
                        gm.currentDaySucccess += 1; //good outcome
                    break;
                    case 2:
                        gm.currentDayFlagValue -=64;
                        gm.currentDayFlagValue +=16;
                    gm.currentDaySucccess = RSSs.None;
                    break;
                    default:
                    break;
                }
            }

            unCacheBools();
            //setbit flag
        }
        void WaterResult()
        {
              if(f_u_water)
            {//if underwater
                switch(w_result)
                {
                    case 0:
                        //not watered when underwatered. display death
                        gm.DisplayDeath();
                    break;
                    case 1:
                        //watered when underwatered, remove flag
                        gm.currentDayFlagValue -= 1;
                    break;
                    case 2:
                        gm.currentDayFlagValue -= 1;
                        gm.currentDayFlagValue += 8;
                    gm.currentDaySucccess = RSSs.None;
                    break;
                    default:
                    //error, assume overwater
                    gm.currentDayFlagValue -= 1;
                    gm.currentDayFlagValue += 8;
                    gm.currentDaySucccess = RSSs.None;
                    break;
                }

            }
            else if(f_o_water)
            {//if overwater
                switch(w_result)
                {
                    case 0:
                        //not water
                        gm.currentDayFlagValue -=8;
                        gm.currentDayFlagValue +=1;
                    gm.currentDaySucccess = RSSs.None;
                    break;
                    case 1:
                        gm.currentDayFlagValue-=8;
                    break;
                    case 2:
                        gm.currentDaySucccess = RSSs.None;
                        
                    break;
                    default:
                        gm.currentDaySucccess = RSSs.None;
                    break;
                }

            } else if((int)gm.currentDayFlagValue ==64)
            {
                switch(w_result)
                {
                    case 0:
                    gm.currentDayFlagValue -=64;
                    gm.currentDayFlagValue +=1;
                    gm.currentDaySucccess = RSSs.None;
                    break;
                    case 1:
                    gm.currentDaySucccess +=1;
                    break;
                    case 2:
                    gm.currentDayFlagValue -=64;
                    gm.currentDayFlagValue +=8;
                    gm.currentDaySucccess = RSSs.None;
                    break;
                    default:
                    gm.currentDayFlagValue -=64;
                    gm.currentDayFlagValue +=8;
                    gm.currentDaySucccess = RSSs.None;
                    break;
                }
            }

            unCacheBools();
        }
        void InteractionResult()
        {
            if(f_u_inter)
            {
                switch(s_result)
                {

                    case 0:
                    
                    gm.DisplayDeath();
                    break;
                    case 1:
                
                    gm.currentDayFlagValue -= 4;
                    break;
                    case 2:
                    gm.currentDayFlagValue -= 4;
                    gm.currentDayFlagValue += 32;
                    gm.currentDaySucccess = RSSs.None;
                    break;
                    default:

                    gm.currentDayFlagValue -= 4;
                    gm.currentDayFlagValue += 32;
                    gm.currentDaySucccess = RSSs.None;
                    break;
                }

            } else if(f_o_inter)
            {//if annoying
                switch(s_result)
                {
                    case 0:
                    //not water
                    gm.currentDayFlagValue -=32;
                    gm.currentDayFlagValue +=4;
                    gm.currentDaySucccess = RSSs.None;
                    break;
                    case 1:
                    gm.currentDayFlagValue-=32;
                    break;
                    case 2:
                    gm.currentDaySucccess = RSSs.None;

                    break;
                    default:
                    gm.currentDaySucccess = RSSs.None;
                    break;
                }

            } else if((int)gm.currentDayFlagValue ==64)
            {
                switch(s_result)
                {
                    case 0:
                    gm.currentDayFlagValue -=64;
                    gm.currentDayFlagValue +=4;
                    gm.currentDaySucccess = RSSs.None;
                    break;
                    case 1:
                    gm.currentDaySucccess +=1;
                    break;
                    case 2:
                    gm.currentDayFlagValue -=64;
                    gm.currentDayFlagValue +=32;
                    gm.currentDaySucccess = RSSs.None;
                    break;
                    default:
                    gm.currentDayFlagValue -=64;
                    gm.currentDayFlagValue +=32;
                    gm.currentDaySucccess = RSSs.None;
                    break;
                }
            }

            unCacheBools();

        }
        
        void cacheBools()
        {
            //for orginization reasons, do not poll the fields up top!

           f_u_food = gm.currentDayFlagValue.HasFlag(RFFs.UnderFedFood);
            f_o_food = gm.currentDayFlagValue.HasFlag(RFFs.OverFedFood);
            f_result = (int)ui_ref.food;
            f_u_water= gm.currentDayFlagValue.HasFlag(RFFs.UnderWatered);
             f_o_water = gm.currentDayFlagValue.HasFlag(RFFs.OverWaterd);
             w_result = (int)ui_ref.water;
            f_u_inter = gm.currentDayFlagValue.HasFlag(RFFs.UnderInteracted);
             f_o_inter = gm.currentDayFlagValue.HasFlag(RFFs.OverInteracted);
            s_result = (int)ui_ref.interaction;

        }
        void unCacheBools()
        {
            //for orginization reasons, does not pass back control until these are gone!
            f_u_food = false;
        f_o_food= false;
         f_u_water= false;
         f_o_water= false;
        f_u_inter= false;
         f_o_inter= false;

        f_result = 0;
         w_result=0;
         s_result=0;
         
         ui_ref.water = EventOutcome.None;
         ui_ref.food = EventOutcome.None;
            ui_ref.interaction = EventOutcome.None;
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
