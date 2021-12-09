using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class Object_Clickable : MonoBehaviour
{
    private bool is_selectable = false; //used for change position of ball when it is selected.
    private Transform Clicked_ball_tranfrom; //used to get position of transform of ball.


    private float my_speed_mov = 0.15f; //speed of change position of ball.

    //in order to Activate and DeActivate Arrow and Canvas Ball, we need their GameObjects.
    private GameObject arrow_ball;
    private GameObject canvas_ball;

   
    private TMP_InputField input_time_grab;  //in order to have value of input_field which user put in input_field, use input_time_grab
    private Ball Ball_hitted; //in order to change value of Time_handStay(time grab and put into basket)

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) //know when left Mouse Button Clicked.
        {


            //*** in order to know which gameObject is selected with mouse, we must cast a Ray from the main camera.
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //***

            //when Ball Selected, we have Input field which is UI Element;
            //UI Element use grahphic RayCaster , and  3d element use Physics rayCaster.
            //if we hit Ball which is 3d  or UI element of that Ball, we want to select that Ball.
            //9 is Layer that we want to ignore it, it is Collider that goes in 3 and 9 clock.
            if (Physics.Raycast(ray, out hit, 100.0f, 9) || EventSystem.current.IsPointerOverGameObject() )
            {

                // Debug.Log("hit: " + hit.transform.gameObject);

                //detect if we hit 3d object with mouse.
                if (hit.transform != null)
                {

               

                if (hit.transform.tag == "Balls") //if we hit Ball
                {
                    // Debug.Log("hit: " + hit.transform.gameObject);

                    if (arrow_ball!=null) //if Ball selected before, get time that put in input_field, DeActivate Canvas and arrow.
                    {
                        //input_time_grab = hit.transform.GetComponentInChildren<TMP_InputField>();
                        // input_time_grab = hit.transform.GetChild(2).GetComponentInChildren<TMP_InputField>();

                        Ball_hitted.Time_handStay =Math.Abs(double.Parse(input_time_grab.text)); 
                           
                        arrow_ball.SetActive(false);
                        canvas_ball.SetActive(false);
                    }
                   
                    //if we hit Ball for first time, save transform of that ball and make is_selectable true to move ball with arrow keys.     
                    Clicked_ball_tranfrom = hit.transform;
                    is_selectable = true;

                    //arrow_ball =  hit.transform.GetChild(1).gameObject;
                    arrow_ball =  hit.transform.GetChild(1).GetChild(0).gameObject; //get arrow of ball which is child child ball.

                    arrow_ball.SetActive(true); //Activate arrow becuase ball is selected.

                    Ball_hitted =hit.transform.GetComponent<Ball>(); //in order to change value of Time_hand_stay, we must get Ball 
                                                                    //component.
                    

                    
                    canvas_ball =hit.transform.GetChild(1).gameObject; //Get Canvas of ball and Activate Canvas of the ball.
                    canvas_ball.SetActive(true);
                    input_time_grab = hit.transform.GetComponentInChildren<TMP_InputField>(); //put value of input_field in variable.
                }

               // else if (hit.transform.tag != "Balls")
               else //if we hit something other than Balls, DeActivate arrow and canvas of privious ball and make is_selectable false.
                {
                    is_selectable = false;
                    Clicked_ball_tranfrom = null;

                    if (arrow_ball!=null) //if pri element that click, is ball
                    {
                        // input_time_grab = hit.transform.GetComponentInChildren<TMP_InputField>();
                        // hit.transform.GetComponent<Ball>().Time_handStay = Math.Abs(float.Parse(input_time_grab.text));
                        Ball_hitted.Time_handStay = Math.Abs(double.Parse(input_time_grab.text));

                        arrow_ball.SetActive(false);
                        canvas_ball.SetActive(false);
                    }
                    
                }

                }

                //else
                //{
                //    Debug.Log("no hit but has event" + EventSystem.current.currentSelectedGameObject);
                //}


            }
            else if ( !Physics.Raycast(ray, out hit, 100.0f, 9) ) //if we don't hit something, make is_selectable and ball_transform false.
            {
               // Debug.Log("hit: " + hit.transform.gameObject);

                is_selectable = false;
                Clicked_ball_tranfrom = null;

                if (arrow_ball != null) //if dont hit something and the Ball was Selected before.
                {
                  //  input_time_grab = hit.transform.GetComponentInChildren<TMP_InputField>();
                   // hit.transform.GetComponent<Ball>().Time_handStay = Math.Abs(float.Parse(input_time_grab.text));

                    //***like above code snippet, get value in input field and put it in Time_handStay of that ball
                    //DeActivate Canvas and Arrow.
                    Ball_hitted.Time_handStay = Math.Abs(double.Parse(input_time_grab.text));

                    arrow_ball.SetActive(false);
                    canvas_ball.SetActive(false);

                    //***
                }
               
            }

        }
        
        if (is_selectable) //if a ball was selected, change position of Ball.
        {
            if (Input.GetButton("Horizontal")) //if a,d, left Arrow and right Arrow Selected, get Horizontal Axis value and change position. 
            {
                Clicked_ball_tranfrom.position += new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * my_speed_mov, 0.0f, 0.0f);
            }

            if (Input.GetButton("Vertical"))//if w,s, Down Arrow and Up Arrow Selected, get Vertical Axis value and change position.
            {
                Clicked_ball_tranfrom.position += new Vector3(0.0f, Input.GetAxis("Vertical") * Time.deltaTime * my_speed_mov, 0.0f);
            }



            //if (Input.GetKey(KeyCode.RightArrow))
            //{
            //    Clicked_ball_tranfrom.position += new Vector3(1.0f * Time.deltaTime * my_speed_mov,0.0f,0.0f); 
            //}
            //if (Input.GetKey(KeyCode.UpArrow))
            //{
            //    Clicked_ball_tranfrom.position += new Vector3(0.0f, 1.0f * Time.deltaTime * my_speed_mov, 0.0f);
            //}
            //if (Input.GetKey(KeyCode.DownArrow))
            //{
            //    Clicked_ball_tranfrom.position += new Vector3(0.0f, -1.0f * Time.deltaTime * my_speed_mov, 0.0f);
            //}
            //if (Input.GetKey(KeyCode.LeftArrow))
            //{
            //    Clicked_ball_tranfrom.position += new Vector3(-1.0f * Time.deltaTime * my_speed_mov,0.0f , 0.0f);
            //}

        }

        // Debug.Log("Mouse pos: " + Input.mousePosition);
    }

    //private void OnMouseDrag()
    //{
    //    Debug.Log("Mouse Dragged!");
    //}
    //private void OnMouseDown()
    //{
    //    Debug.Log("Mouse Down!");
    //}
}
