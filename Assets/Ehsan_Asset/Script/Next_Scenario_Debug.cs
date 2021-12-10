using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Next_Scenario_Debug : MonoBehaviour
{
    private static byte count =1 ;

    UnityEvent my_event;

    public bool Game_restriction = false;

    //private hand_event Right_hand;
    //private hand_event left_hand;
    public void Next_Scenario()
    {
        Destroy_balls_scene(); //Destroy all balls in Scene.

        count++;

        restrict_levels();

        switch (count)
        {
            case 1:
                Ball_manager.My_Scenario.Scenario_1();
                break;
            case 2:
                Ball_manager.My_Scenario.Scenario_2();
                break;
            case 3:
                Ball_manager.My_Scenario.Scenario_3();
                break;
            case 4:
                Ball_manager.My_Scenario.Scenario_4();
                break;
            case 5:
                Ball_manager.My_Scenario.Scenario_5();
                break;
            case 6:
                Ball_manager.My_Scenario.Scenario_6();
                break;
            case 7:
                Ball_manager.My_Scenario.Scenario_7();
                break;
            default:
                break;
        }


    }

    private void restrict_levels()
    {
        if (!Game_restriction)
        {


            if (count == 8)
            {
                count = 1;
            }
        }

        else
        {
            if (count == 4)
            {
                count = 1;
            }

            else if(count == 0)
            {
                count = 3;
            }

        }
    }

    public void Next_Scenario_2() //used when click on Next_Scenario Button.
    {
        Destroy_balls_scene(); //Destroy all balls in Scene.

        //AudioSource my_start_sound = GameObject.FindGameObjectWithTag("start_sound").GetComponent<AudioSource>();
        //my_start_sound.Play();


        //count++;

        //if (count == 8)
        //{
        //    count = 1;
        //}





        //switch (Ball_manager.My_Scenario.Next_Scenario) //what is Next Scenario in Current Scenarioو update Scene of it.
        //{
        //    case 1:
        //        Ball_manager.My_Scenario.Scenario_1();
        //        break;
        //    case 2:
        //        Ball_manager.My_Scenario.Scenario_2();
        //        break;
        //    case 3:
        //        Ball_manager.My_Scenario.Scenario_3();
        //        break;
        //    case 4:
        //        Ball_manager.My_Scenario.Scenario_4();
        //        break;
        //    case 5:
        //        Ball_manager.My_Scenario.Scenario_5();
        //        break;
        //    case 6:
        //        Ball_manager.My_Scenario.Scenario_6();
        //        break;
        //    case 7:
        //        Ball_manager.My_Scenario.Scenario_7();
        //        break;
        //    default:
        //        //Ball_manager.My_Scenario.Scenario_1();
        //        break;
        //}


        Ball_manager.next_scenario();
    }


    public void Pri_Scenario() //used when click on pri_Scenario Button.
    {
        Destroy_balls_scene();
        //count++;

        //AudioSource my_start_sound = GameObject.FindGameObjectWithTag("start_sound").GetComponent<AudioSource>();
        //my_start_sound.Play();

        //if (count == 8)
        //{
        //    count = 1;
        //}


        count--;


        restrict_levels();




        //switch (Ball_manager.My_Scenario.pri_Scenario) //What is privious Scenario of current Scenario.
        switch (count)
        {
            case 1:
                Ball_manager.My_Scenario.Scenario_1();
                break;
            case 2:
                Ball_manager.My_Scenario.Scenario_2();
                break;
            case 3:
                Ball_manager.My_Scenario.Scenario_3();
                break;
            case 4:
                Ball_manager.My_Scenario.Scenario_4();
                break;
            case 5:
                Ball_manager.My_Scenario.Scenario_5();
                break;
            case 6:
                Ball_manager.My_Scenario.Scenario_6();
                break;
            case 7:
                Ball_manager.My_Scenario.Scenario_7();
                break;
            default:
               // Ball_manager.My_Scenario.Scenario_7();
                break;
        }

      //  Scenario.freeze_pos();

        //Discription like Next Scneario Comments.

        GameObject[] balls_scene = GameObject.FindGameObjectsWithTag("Balls");

        //suppose, when user click on ball, click on Start; we must DeActivate Canvas and update Time_handStay of that Ball.
        for (int i = 0; i < balls_scene.Length; i++)
        {
            balls_scene[i].GetComponent<Rigidbody>().isKinematic = false;


        }

        GameObject.FindGameObjectWithTag("Red").GetComponent<Rigidbody>().isKinematic = true;
        GameObject.FindGameObjectWithTag("Yellow").GetComponent<Rigidbody>().isKinematic = true;
        GameObject.FindGameObjectWithTag("Blue").GetComponent<Rigidbody>().isKinematic = true;

        GameObject.FindGameObjectWithTag("Left").GetComponent<Rigidbody>().isKinematic = true;
        GameObject.FindGameObjectWithTag("Right").GetComponent<Rigidbody>().isKinematic = true;

        Ball_manager.state_my_game = Ball_manager.State_Game.Config_game;
    }




    public void Destroy_balls_scene()
    {

        Ball_manager.pick_ball_after_clapp_s = true;

        my_event = new UnityEvent();
       
        // StopAllCoroutines();

        hand_event Right_hand = GameObject.FindGameObjectWithTag("Right").GetComponent<hand_event>();
        Right_hand.is_grab = false; //when a ball grabbed and user press next or pri Scenario, is_grab must be false.

        //if (Right_hand.timer != null)
        //{
        //    // StopCoroutine(Right_hand.timer);
        //  //  StopAllCoroutines();

        //}
        if (Right_hand.timer!=null)
        {
            my_event.AddListener(Right_hand.Stop_my_coroutine); //you cant use stopcoritune(Right_hand.timer), stopcoroutine must be 
                                                                //call where Coroutine saved.
                                                                //maybe we can do just Right_hand.Stop_my_coroutine
                                                                //and dont need UnityEvent.
            my_event.Invoke();
        }
      
        

        hand_event Left_hand = GameObject.FindGameObjectWithTag("Left").GetComponent<hand_event>();
        Left_hand.is_grab = false;
        //if (Left_hand.timer != null)
        //{
        //    // StopCoroutine(Left_hand.timer);
        //   // StopAllCoroutines();
        //}

        if (Left_hand.timer!=null)
        {
            my_event.AddListener(Left_hand.Stop_my_coroutine);
            my_event.Invoke();
        }

       


     

        GameObject [] balls_scene =  GameObject.FindGameObjectsWithTag("Balls");
        for (int i = 0; i < balls_scene.Length; i++)
        {
           // StopCoroutine(balls_scene[i].GetComponent<Ball>().Record_Timer());
            Destroy(balls_scene[i]);
        }


        Ball_manager.ball_in_basket = 0;
       

    }

    //public void next_Scenario() 
    //{
    //    Destroy_balls_scene();
    //}
    //public void pri_Scenario() 
    //{
    //    Destroy_balls_scene()


    //}

}
