using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Basket : MonoBehaviour
{
    private Ball ball_colide; //for caching GameObject that Collide with this basket.

   // public TextMeshProUGUI score;


    //** Coroutine of Basket (Timer of Basket that user must wait to put into basket)
    private Coroutine timer;
    private bool is_started_Coroutine = true;
    //**


    public AudioSource background_music;
    
    // public Transform sar_mokaab;

    // public Vector3 speed;



    //public BoxCollider colider_up;
    //public BoxCollider colider_down;


    //private void OnCollisionEnter(Collision collision)
    //{
    //    ball_colide = collision.gameObject.GetComponentInChildren<Ball>();

    //    Debug.Log("Colision basket "+collision.gameObject.name);

    //    if (ball_colide != null)
    //    {

    //        if (ball_colide.ball_color == this.gameObject.tag )

    //        {
    //            Debug.Log("inside loop score basket" );
    //            //Rigidbody ball_rb =  collision.gameObject.GetComponent<Rigidbody>();

    //            //Rigidbody ball_rb = ball_colide.gameObject.GetComponent<Rigidbody>();
    //           // ball_rb.isKinematic = false;


    //            //ball_rb.useGravity = true;


    //            //ball_colide.transform.position = new Vector3(-5.813f, 1.961f, 5.151f);

    //            ball_colide.transform.position = sar_mokaab.position; //when isKinematic is true

    //            //ball_rb.MovePosition(sar_mokaab.position); //when isKinematic is false
    //            ball_colide.transform.parent = null;
    //            //ball_rb.AddForce(0,-10f,0);

    //            ball_colide.score();

    //            score.text = (Int16.Parse(score.text) + ball_colide.Ball_Score).ToString();

    //          //  score.text = "Score:";




    //        }

    //    }

    //}


    //private void OnTriggerenter(Collider other)


    //{






    //    }
    //** OnCollisionStay
    private void OnCollisionStay(Collision collision)
    {
        ball_colide = collision.gameObject.GetComponent<Ball>();

         //Todo:ehsan important debug Debug.Log("Colision basket " + gameObject.tag + " with " + collision.gameObject.name);

        if (ball_colide != null) //make sure objec that collide with basket is ball.
        {
            // Debug.ClearDeveloperConsole();
            
                hand_event which_hand = GameObject.FindGameObjectWithTag(ball_colide.which_ball_tag).GetComponent<hand_event>();

            if (ball_colide.ball_color == this.gameObject.tag && is_started_Coroutine && which_hand.is_grab && 
                Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list] == ball_colide.num_clock) //make sure color of basket and ball is the same
                                                                                       //and coroutine Started just first time in Collision area.

            {
                // Debug.Log("inside loop score basket");


                //ball_colide.transform.parent = null;  //this line make 4 hour to debug!!!!









                //ball_colide.transform.position = new Vector3(-5.813f, 1.961f, 5.151f);

                //ball_colide.transform.parent = null;
                //ball_colide.transform.position = sar_mokaab.position; //when isKinematic is true


                //background_music.Pause();
                background_music.volume = 0.2f;

                timer = StartCoroutine(ball_colide.Record_Timer_Put()); //call Coroutine Record_Timer_Put()
                is_started_Coroutine = false;


               // ball_colide.Ball_Score;

                //*************
                // score.text = (Int16.Parse(score.text) + ball_colide.Ball_Score).ToString();

                //  score.text = "Score:";




            }

        }


    }

    private void OnCollisionExit(Collision collision) //if ball exit from Collider area of basket, turn off Timer and Deactivate UI Timer.
    {
        if (timer != null && Ball_manager.not_playing) //if coRoutine Runs and clapping sound not played.
        {
            //if ball exit from collision area of basket, beep_sound must stop and timer of basket must be DeActivated.
            if (collision.gameObject.tag == "Balls")
            {
                collision.gameObject.GetComponentInChildren<TextMesh>(true).gameObject.SetActive(false);

                collision.gameObject.GetComponent<Ball>().my_beep_sound.Stop();
                collision.gameObject.GetComponent<Ball>().can_beep_basket = true;

               // background_music.Play();

                background_music.volume = 1.0f;
            }

            StopCoroutine(timer);
            is_started_Coroutine = true;
            //collision.gameObject.GetComponentInChildren<TextMesh>().gameObject.SetActive(false); //????????
        }


        //Debug.Log("CoRoutine must stopped");

    }






    //bare halati ke topha beran dakhel sabad

    //private void OnCollisionExit(Collision collision)
    //{

    //    // ball_colide = other.gameObject.GetComponentInChildren<Ball>();
    //    ball_colide = collision.gameObject.GetComponent<Ball>();



    //    Debug.Log("Colision basket " + collision.gameObject.name);

    //    if (ball_colide != null)
    //    {
    //       // Debug.ClearDeveloperConsole();

    //        if (ball_colide.ball_color == this.gameObject.tag)

    //        {
    //            Debug.Log("inside loop score basket");
    //            //Rigidbody ball_rb =  collision.gameObject.GetComponent<Rigidbody>();

    //            Rigidbody ball_rb = ball_colide.gameObject.GetComponent<Rigidbody>();

    //            //ball_colide.transform.parent = null;  //this line make 4 hour to debug!!!!

    //            //ball_rb.isKinematic = false;
    //            //ball_rb.MovePosition(sar_mokaab.position); //when isKinematic is false

    //            ball_rb.constraints = RigidbodyConstraints.None;

    //            //Important comment
    //            //line of code below, do freeze all parameter that mentiond all together
    //           // ball_rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX
    //                               //   | RigidbodyConstraints.FreezePositionZ;

    //            ball_rb.constraints =  RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;


    //            ball_rb.isKinematic = false;
    //             //ball_rb.constraints = RigidbodyConstraints.FreezePositionX;
    //             //ball_rb.constraints = RigidbodyConstraints.FreezePositionZ;

    //            //ball_rb.useGravity = true;

    //            //ball_rb.constraints = RigidbodyConstraints.FreezeAll;

    //            ball_rb.useGravity = true;


    //            //ball_colide.transform.position = new Vector3(-5.813f, 1.961f, 5.151f);

    //            //ball_colide.transform.parent = null;
    //            //ball_colide.transform.position = sar_mokaab.position; //when isKinematic is true



    //            // speed = new Vector3(0,-0.1f,0);
    //            // Vector3.SmoothDamp(transform.position, sar_mokaab.position, ref speed, 0.1f);




    //            //ball_rb.AddForce(0,-10f,0);

    //            ball_colide.score();

    //            //*************
    //           // score.text = (Int16.Parse(score.text) + ball_colide.Ball_Score).ToString();

    //            //  score.text = "Score:";




    //        }

    //    }


    //}




}
