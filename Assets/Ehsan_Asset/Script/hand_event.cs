using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
//using System.Diagnostics;
using UnityEngine;
//using UnityEngine.Events;

//[RequireComponent(typeof(Rigidbody))]
public class hand_event : MonoBehaviour
{
    private string which_hand_tag; //used for grabbing ball, this hand is Right or Left. 

    private Ball ball_colide; //used for component ball object that collide with hand.

    public Coroutine timer; //saved Timer grabbing in order to Stop it when we want.
    // public IEnumerator
   // public UnityEvent my_event;

    private bool is_started_Coroutine = true; //OnCollisionStay called whenever gameObject Coliide with Collider. one time Timer must
                                              //start, whenever GameObject are inside Collider, so in Second time inside OnCollisionStay
                                              //it must not called Timer (Coroutine).

    // public bool up_clock = false;
    [HideInInspector]
    public  bool is_grab = false;  //when this hand grab one ball, must not grab any other balls.

    // public static Scenario current_scenario;


    public AudioSource background_music;

    void Start()
    {
        which_hand_tag = gameObject.tag; //this hand is Right or Left.
      //  Debug.Log("which hand "+ which_hand_tag);
        
    }
   
    private void OnCollisionStay(Collision collision) //detecting Collision  between each hand and GameObject
    {
        ball_colide = collision.gameObject.GetComponent<Ball>();


        //**important Debug
        //Todo:ehsan important debug Debug.Log("Colission!!!!");
        //Todo:ehsan important debug Debug.Log("Game Object Colision: "+collision.gameObject.name);



        if (ball_colide != null) //make sure GameObject that collide with the hand is ball which must have component Ball.
        {
            // Debug.Log("score:" + ball_colide.score());
            // Debug.Log("tag_ball:"+ball_colide.which_ball_tag);

          

            // Debug.Log("tag hand"+which_hand_tag);

            // current_scenario.ball_list[current_scenario.index_ball_list] == current_scenario.index_ball_list)


            //ball_colide.can_beep =true;

            //check right, left - Start Timer for first Time when Collision happened- must grab only one ball- Objective
            //pick ball after tashvig_sound played
            if (which_hand_tag == ball_colide.which_ball_tag && is_started_Coroutine && !is_grab
                && Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list] == ball_colide.num_clock 
                && Ball_manager.pick_ball_after_clapp_s
                )
            {
                //background_music.Pause();
                background_music.volume = 0.2f;

                ball_colide.which_hand_colide = this.transform; //this ball grab with which hand.

               // ball_colide.which_hand_colide.transform.position = new Vector3(0.057f, 0.038f, 0f);

                //Debug.Log("inside loop coroutine!!!!");
                timer = StartCoroutine(ball_colide.Record_Timer()); //start Timer and saved it in timer.
                is_started_Coroutine = false;
            }
            //else if (ball_colide.num_clock == "12")
            //{
            //    timer = StartCoroutine(ball_colide.Record_Timer());
            //    is_started_Coroutine = false;

            //}



            if (which_hand_tag == ball_colide.which_ball_tag &&  ball_colide.in_basket) //in order to  give permission to hands to pick up balls
                                                                                      //note that cant pick up two balls at same time.
            {
                is_started_Coroutine = true;
            }


        }

        //if (ball_colide.)
        //{

        //}

    }

    private void OnCollisionExit(Collision collision) //if hand exit from region of collider of grabbing the balls, timer 
                                                      //and Coroutine must stopped.
    {
        if (timer != null)
        {
            
            //if hand exit from Collision area of ball, beep_sound must stopped and timer must be in active.
            if (collision.gameObject.tag == "Balls" && Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list] == ball_colide.num_clock)
            {
                collision.gameObject.GetComponentInChildren<TextMesh>(true).gameObject.SetActive(false);
                collision.gameObject.GetComponent<Ball>().my_beep_sound.Stop();
                collision.gameObject.GetComponent<Ball>().can_beep = true;

                //background_music.Play();
                background_music.volume = 1.0f;
            }

           

            StopCoroutine(timer);
            is_started_Coroutine = true;
         //   if (collision.gameObject.GetComponentInChildren<TextMesh>().gameObject.activeSelf)
         //   {

            //???????????
              // collision.gameObject.GetComponentInChildren<TextMesh>(true).gameObject.SetActive(false);
            
          //  }

            //if (collision.gameObject.GetComponentInChildren<TextMesh>() == null)
            //{
            //    Debug.Log(collision.gameObject);
            //}
           
        }


        //Debug.Log("CoRoutine must stopped");

    }

    public void Stop_my_coroutine() //must stopCoroutine where it is started and saved.
    {
      //  if (timer!=null) it set at Next_Sceanrio Debug
      //  {

            StopCoroutine(timer); //each CoRoutine must stopped where is started.
      //  }
        

    }

    public  string set_one_points( string number_ball)
    {
        //float my_numb = float.Parse(number_ball);




        if (number_ball.Contains(":"))
        {
            //number_ball.IndexOf(".");

            //  number_ball[number_ball.IndexOf(".")]. = ":";

            // string  [] my_numb = number_ball.Split('.');

            int second_num = (int)(5 * float.Parse(number_ball));

            //second_num



            number_ball = number_ball.Replace(":", ".");


            //string[] numb_split = number_ball.Split('.');

            //numb_split[1] = second_num.ToString();

            //number_ball = numb_split[0] + ":" + numb_split[1];
             return number_ball;


        }
        else
        {
              return number_ball;
        }

    }



}
