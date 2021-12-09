using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using UnityEngine.Experimental.UIElements;

using UnityEngine.UI;
public class Start_Scenario : MonoBehaviour
{
    public static Button start_button; //when start button clicked, up to end of current scene, it must be DeActivated.
    public static Object_Clickable my_clickable; //after start button pushed, User can't change position of ball; so we need this variable. 

    // public static KinectManager my_kinect_manag;

    //***when Start_button not clicked, Sound of start not play and puppet hand don't move, although kinect tracking,
    //so we need left and right puppet component to DeActivate and Activate them.
    public static CharTo_puppet left_pupp;
    public static CharTo_puppet right_pupp;

    //***

    private void Start()
    {
        //  my_kinect = GameObject.FindGameObjectWithTag("Kinect_manager"); //used for detecting if 
        //my_kinect.SetActive(false);

        // my_kinect_manag = GameObject.FindGameObjectWithTag("Kinect_manager").GetComponent<KinectManager>();
        // my_kinect_manag.enabled = false;

        //*** find component of CharTo_puppet. 
        left_pupp = GameObject.FindGameObjectWithTag("Left_puppet").GetComponent<CharTo_puppet>();
        right_pupp = GameObject.FindGameObjectWithTag("Right_puppet").GetComponent<CharTo_puppet>();
        //***

        //left_pupp.SetActive(false);
        //right_pupp.SetActive(false);

        left_pupp.enabled = false;
        right_pupp.enabled = false;

        //GameObject[] balls_scene = GameObject.FindGameObjectsWithTag("Balls");
        //for (int i = 0; i < balls_scene.Length; i++)
        //{
        //    // StopCoroutine(balls_scene[i].GetComponent<Ball>().Record_Timer());
        //    balls_scene[i].SetActive(false);
        //}

        //find component of Object_clickable.
        my_clickable = GameObject.FindGameObjectWithTag("clickable_component").GetComponent<Object_Clickable>();
        start_button = GetComponent<Button>();

    }


    public static void click_on_start() //when start button pushed or Auto_Start CoRoutine is Finshed successfully, this method is called.
    {

        //when this method called, we are in Play_game State.
        Ball_manager.state_my_game = Ball_manager.State_Game.Play_game;


        //GameObject[] balls_scene = GameObject.FindGameObjectsWithTag("Balls");
        //for (int i = 0; i < balls_scene.Length; i++)
        //{
        //    // StopCoroutine(balls_scene[i].GetComponent<Ball>().Record_Timer());
        //    balls_scene[i].SetActive(true);
        //}


        start_button.enabled = false; //when Start Button pushed, DeActivate it.

       // Ball_manager.time_setup_scenario = Math.Round(Time.time,1);

        my_clickable.gameObject.SetActive(false); //DeActivate interacting with Balls.

        //*** play Start Sound
        AudioSource my_start_sound = GameObject.FindGameObjectWithTag("start_sound").GetComponent<AudioSource>();
        my_start_sound.Play();

        //***

        //  my_kinect_manag.enabled = true;

        //Activate puppets, so user can grab Ball and put into Basket.
        left_pupp.enabled =true;
        right_pupp.enabled = true;


        //when we are in play_Game State, User must interact with Balls and baskets.

        GameObject.FindGameObjectWithTag("Red").GetComponent<Rigidbody>().isKinematic = false;
        GameObject.FindGameObjectWithTag("Yellow").GetComponent<Rigidbody>().isKinematic = false;
        GameObject.FindGameObjectWithTag("Blue").GetComponent<Rigidbody>().isKinematic = false;

        GameObject.FindGameObjectWithTag("Left").GetComponent<Rigidbody>().isKinematic = false;
        GameObject.FindGameObjectWithTag("Right").GetComponent<Rigidbody>().isKinematic = false;


        //Get All Balls in Scene.
        GameObject[] balls_scene = GameObject.FindGameObjectsWithTag("Balls");

        //suppose, when user click on ball, click on Start; we must DeActivate Canvas and update Time_handStay of that Ball.
        for (int i = 0; i < balls_scene.Length; i++)
        {
            balls_scene[i].GetComponent<Rigidbody>().isKinematic = true;
           // balls_scene[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            // StopCoroutine(balls_scene[i].GetComponent<Ball>().Record_Timer());
            if (balls_scene[i].GetComponentInChildren<Set_time_grab>()!=null)
            {
                balls_scene[i].GetComponent<Ball>().Time_handStay = Math.Abs(float.Parse(balls_scene[i].
                                                                            GetComponentInChildren<Set_time_grab>().input_time_grab.text));
                //balls_scene[i].transform.GetChild(2).gameObject.SetActive(false);
                //balls_scene[i].transform.GetChild(1).gameObject.SetActive(false);

                balls_scene[i].transform.GetChild(1).gameObject.SetActive(false);
                //balls_scene[i].transform.GetChild(1).gameObject.SetActive(false);
            }
           

           
        }

      

       // GameObject.FindGameObjectWithTag("obj").GetComponent<TextMesh>().text = Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list];

       // Ball.set_color_objective();

        // Ball_manager.time_start_objective_current_ball = 0;

        Ball_manager.time_start_objective_current_ball =Math.Round(Time.time,1); //When Start button click, new Objective updated,
                                                                                 //we must get Time in that moment, to use when need
                                                                                 //to compute Delta t1.

        // my_kinect.SetActive(true);


       // Ball_manager.state_my_game = Ball_manager.State_Game.Play_game;


    }


    public  void click_on_start_button() //when start button pushed, this method is called.
    {

        //when start_button pushed, we are in Push_by_start_button state.
        Ball_manager.state_my_game = Ball_manager.State_Game.Push_by_Start_button;


        //Ball_manager.state_my_game = Ball_manager.State_Game.Play_game;


        //GameObject[] balls_scene = GameObject.FindGameObjectsWithTag("Balls");
        //for (int i = 0; i < balls_scene.Length; i++)
        //{
        //    // StopCoroutine(balls_scene[i].GetComponent<Ball>().Record_Timer());
        //    balls_scene[i].SetActive(true);
        //}


        start_button.enabled = false; //when Start Button pushed, DeActivate it.

        // Ball_manager.time_setup_scenario = Math.Round(Time.time,1);

        my_clickable.gameObject.SetActive(false); //DeActivate interacting with Balls.

        //*** play Start Sound
        AudioSource my_start_sound = GameObject.FindGameObjectWithTag("start_sound").GetComponent<AudioSource>();
        my_start_sound.Play();

        //***

        //  my_kinect_manag.enabled = true;

        //Activate puppets, so user can grab Ball and put into Basket.
        left_pupp.enabled = true;
        right_pupp.enabled = true;




        //we must interact with Ball and basket, when this button pushed.
        GameObject.FindGameObjectWithTag("Red").GetComponent<Rigidbody>().isKinematic = false;
        GameObject.FindGameObjectWithTag("Yellow").GetComponent<Rigidbody>().isKinematic = false;
        GameObject.FindGameObjectWithTag("Blue").GetComponent<Rigidbody>().isKinematic = false;


        GameObject.FindGameObjectWithTag("Left").GetComponent<Rigidbody>().isKinematic = false;
        GameObject.FindGameObjectWithTag("Right").GetComponent<Rigidbody>().isKinematic = false;


        //Get All Balls in Scene.
        GameObject[] balls_scene = GameObject.FindGameObjectsWithTag("Balls");

        //suppose, when user click on ball, click on Start; we must DeActivate Canvas and update Time_handStay of that Ball.
        for (int i = 0; i < balls_scene.Length; i++)
        {
            balls_scene[i].GetComponent<Rigidbody>().isKinematic = true;

            

            // StopCoroutine(balls_scene[i].GetComponent<Ball>().Record_Timer());
            if (balls_scene[i].GetComponentInChildren<Set_time_grab>() != null)
            {
                balls_scene[i].GetComponent<Ball>().Time_handStay = Math.Abs(float.Parse(balls_scene[i].
                                                                            GetComponentInChildren<Set_time_grab>().input_time_grab.text));
                //balls_scene[i].transform.GetChild(2).gameObject.SetActive(false);
                //balls_scene[i].transform.GetChild(1).gameObject.SetActive(false);

                balls_scene[i].transform.GetChild(1).gameObject.SetActive(false);
                //balls_scene[i].transform.GetChild(1).gameObject.SetActive(false);
            }



        }



        // GameObject.FindGameObjectWithTag("obj").GetComponent<TextMesh>().text = Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list];

        // Ball.set_color_objective();

        // Ball_manager.time_start_objective_current_ball = 0;

        Ball_manager.time_start_objective_current_ball = Math.Round(Time.time, 1); //When Start button click, new Objective updated,
                                                                                   //we must get Time in that moment, to use when need
                                                                                   //to compute Delta t1.

        // my_kinect.SetActive(true);


        // Ball_manager.state_my_game = Ball_manager.State_Game.Play_game;


    }

}
