using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.EventSystems;
using TMPro;
public class Mouse_Movment_time : MonoBehaviour
{

    private Coroutine mouse_not_moved; //CoRoutine of Auto Start game.

    public TextMeshProUGUI autoStart_countdown; //label of auto start which count from 5 to zero.

    public AudioSource auto_start_countdown; //sound when count down Auto_Start Started.

    private bool not_start_game_level_1 = false; //we want that, when for first time game loads which loads Level 1,
                                                //AutoStart not Started.

    //private bool can_beep_auto_start;
    public IEnumerator detect_not_mouse_moved(double wait_time) //Coroutine of Auto_Start.
    {
        autoStart_countdown.text = (wait_time + 1).ToString();
        autoStart_countdown.gameObject.SetActive(true);


        //Scenario.freeze_pos();


        while (wait_time >= 0)
        {

            // wait_time = wait_time - 0.1;

            //autoStart_countdown.gameObject.SetActive(true);
            autoStart_countdown.text = (System.Int16.Parse(autoStart_countdown.text) - 1).ToString();
            auto_start_countdown.Play();  //sound of Count down must be played.

            //if (can_beep_auto_start)
            //{
            // auto_start_countdown.Play();
            //my_beep_sound.loop = true;

            // can_beep_auto_start = false;

            // }

            wait_time = wait_time - 1.0f; //we want that each second, this CountDown Show up.




            yield return new WaitForSeconds(1.0f); // wait one Second.
        }

        autoStart_countdown.gameObject.SetActive(false); // when count down finshed successfully, DeActivate it.
        // Ball_manager.state_my_game = Ball_manager.State_Game.Play_game;

        Start_Scenario.click_on_start(); //start the game.


    }

    //this method used for Detecting if arrow keys or W-S-A-D or mouse movment happened, so 
    //Count Down stopped and when none of this happen, Start from begging.
    public void detect_key()
    {
        //if (Input.GetButton("Horizontal") || Input.GetButton("Vertical") || Input.GetAxis("Mouse X")!=0 ||
        //    Input.GetAxis("Mouse Y") != 0)
        //{
        //    if (mouse_not_moved!=null)
        //    {
        //        StopCoroutine(mouse_not_moved);
        //    }

        //    Debug.Log("inside stop corutine");

        //}

        //else if (!Input.GetButton("Horizontal") || !Input.GetButton("Vertical") || Input.GetAxis("Mouse X") == 0 ||
        //    Input.GetAxis("Mouse Y") == 0)
        //{

        //    mouse_not_moved = StartCoroutine(detect_not_mouse_moved(2));

        //}

        //Ball_manager.state_my_game == Ball_manager.State_Game.Config_game ||

        //if we are in state of call_Coroutine and  those buttons or mouse movment happend, autoStart must stopped.
        if (Ball_manager.state_my_game == Ball_manager.State_Game.Call_Coroutine)


        {



            if (Input.GetButton("Horizontal") || Input.GetButton("Vertical") || Input.GetAxis("Mouse X") != 0 ||
          Input.GetAxis("Mouse Y") != 0)
            {
                // if (mouse_not_moved != null)
                // {
                StopCoroutine(mouse_not_moved); //CoRoutine of Auto_Start must be Stopped and state of game changed.

                Ball_manager.state_my_game = Ball_manager.State_Game.Config_game;
                // can_beep_auto_start = true;

                //  autoStart_countdown.gameObject.SetActive(false);
                //}

                //Debug.Log("inside stop corutine");

               Scenario.set_is_kinematic_ball(true);

            }


        }

        //if we are in config state and non of those button pressed, Start CoRoutine.
        else if (Ball_manager.state_my_game == Ball_manager.State_Game.Config_game)
        {



            if (!Input.GetButton("Horizontal") || !Input.GetButton("Vertical") || Input.GetAxis("Mouse X") == 0 ||
               Input.GetAxis("Mouse Y") == 0)
            {
                //  if (Ball_manager.state_my_game == Ball_manager.State_Game.Config_game)
                // {
                //Ball_manager.state_my_game = Ball_manager.State_Game.Play_game;

                if (mouse_not_moved != null)
                {
                    StopCoroutine(mouse_not_moved);
                    // autoStart_countdown.gameObject.SetActive(false);
                    // can_beep_auto_start = true;

                }


                Ball_manager.state_my_game = Ball_manager.State_Game.Call_Coroutine;
                mouse_not_moved = StartCoroutine(detect_not_mouse_moved(5));


                //}

                //Debug.Log("inside start corutine");




            }


        }


        //if we push start button, must Auto_Start CoRoutine Stopped.
        else if (Ball_manager.state_my_game == Ball_manager.State_Game.Push_by_Start_button)
        {
            if (mouse_not_moved != null)
            {
                StopCoroutine(mouse_not_moved);
                autoStart_countdown.gameObject.SetActive(false);
                // can_beep_auto_start = true;


            }

            Ball_manager.state_my_game = Ball_manager.State_Game.Play_game;

        }

    }
    //}


    public void Update()
    {

        //we want that when Game Loads, Auto_Start Disabled but when used Next and pri Button, Auto_Start
        //for level 1 Activated.
        if (Ball_manager.My_Scenario.Next_Scenario - 1 != 1 || not_start_game_level_1)
        {
            detect_key();

            not_start_game_level_1 = true;

        }

       


        // if (Input.GetButton("Horizontal") || Input.GetButton("Vertical") || Input.GetAxis("Mouse X") != 0 ||
        //Input.GetAxis("Mouse Y") != 0)
        // {
        //     if (mouse_not_moved != null)
        //     {
        //         StopCoroutine(mouse_not_moved);

        //         Ball_manager.state_my_game = Ball_manager.State_Game.Config_game;
        //     }

        //     Debug.Log("inside stop corutine");

        // }

        // else if (!Input.GetButton("Horizontal") || !Input.GetButton("Vertical") || Input.GetAxis("Mouse X") == 0 ||
        //     Input.GetAxis("Mouse Y") == 0)
        // {
        //     if (Ball_manager.state_my_game == Ball_manager.State_Game.Config_game)
        //     {
        //         Ball_manager.state_my_game = Ball_manager.State_Game.Play_game;
        //         mouse_not_moved = StartCoroutine(detect_not_mouse_moved(2));

        //     }

        //     Debug.Log("inside start corutine");

        // }







        //if ( Ball_manager.state_my_game == Ball_manager.State_Game.Config_game)
        //{
        //    detect_key();
        //   // Ball_manager.state_my_game = Ball_manager.State_Game.Play_game;



        //}



    }
}
