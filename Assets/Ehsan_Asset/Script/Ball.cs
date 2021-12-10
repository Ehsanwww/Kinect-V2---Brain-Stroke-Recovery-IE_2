using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditorInternal;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [HideInInspector]
    public string which_ball_tag; //This ball is for Right or Left of Clock.
    [HideInInspector]
    public string ball_color; //color of ball

    [HideInInspector]
    public double Time_handStay; //Time that takes to pick or put this Ball.

    //[HideInInspector]
    //public bool is_12 = false;

    [HideInInspector]
    public string num_clock; //this ball place on which number of clock.

    [HideInInspector]
    public Transform which_hand_colide; //in order to make this ball, child of the hand that grab it.

    [HideInInspector]
    public byte Ball_Score; //this ball has what Score  5->one


    //public static byte ball_in_basket = 0; //for changing scenario when all balls put into baskets. 

    public bool in_basket = false; //this ball is in basket or not.

    //public bool is_grab = false;

    //private Transform clock;


    //public Ball(string which_ball_tag , string ball_color)
    //{
    //    this.which_ball_tag = which_ball_tag;
    //    this.ball_color = ball_color;
    //}

    // void Start()
    //{
    //    //clock = GameObject.FindGameObjectWithTag("Clock").transform;

    //}

    private Ball_manager my_ball_manag;


    // void Start()
    //{
    //    my_ball_manag = GameObject.FindGameObjectWithTag("Scenario").GetComponent<Ball_manager>();
    //}


    private TextMesh label_time; //UI Label of Timer that appear when hand Collide with ball or Basket.


    private string temp_color; //in order to Swap Color of Basket (for dynamic placement of Basket)

    //  private string [] basket_color = { "Red","Blue"}; //[0] for left basket, [1] for right basket

    //  private string[] basket_color = { "Red","Yellow" ,"Blue" }; //[0] for left basket, [1] for middle basket, [2] for right basket

    // private Dictionary<string,GameObject> basket_pos = new Dictionary<string, GameObject>();



    //Dictionary<string, GameObject> Baskets = new Dictionary<string, GameObject>();


    private AudioSource my_tashvig_sound; //Tashvig_sound which played after Ball put into Basket.

    private double time_that_PickUp; //the time since from start of game this ball grab.

    // private static double time_start_objective_current_ball = 0;

    private double time_that_Put; //the time since from start of game this ball put into basket.

    [HideInInspector]
    public AudioSource my_beep_sound; //beep_sound when collision happen between hand and ball, hand and basket.

    private AudioSource my_garb_sound; //when Ball is grabbed, this sound is played.


    //*** sound and music is continious but computer is discrete; in order to play sound up to end and again play it, we 
    //use this booleans also I make true loop of sound.

    [HideInInspector]
    public bool can_beep;

    [HideInInspector]
    public bool can_beep_basket;

    [HideInInspector]
    public static int index_ball_list =0;

    //[HideInInspector]
    //public hand_event which_hand;

    //***

    //private Ball_manager my_ball_manager;

    // private Animator my_animator;


    private AudioSource background_music;


    private Next_Scenario_Debug my_next_scenario;


    private void Start()
    {
        label_time = GetComponentInChildren<TextMesh>(); //get UI Label Element which is Childern of ball(UI Label Timer)
        label_time.gameObject.SetActive(false); //by default is must be DeActivate.


        // Physics.IgnoreLayerCollision(0, 9,true);

        //  gameObject.transform.lossyScale = new Vector3(1.5f, 1.5f, 1.5f);

        //GameObject a = GameObject.FindGameObjectWithTag("Test");

        my_beep_sound = GameObject.FindGameObjectWithTag("Beep_sound").GetComponent<AudioSource>();

        my_garb_sound = GameObject.FindGameObjectWithTag("Grab_sound").GetComponent<AudioSource>();


        can_beep = true; //value of beep_sound 
        can_beep_basket = true;


        //GameObject.FindGameObjectWithTag("Scenario").GetComponent<Ball_manager>();

        //  my_animator = GetComponent<Animator>();


        //my_animator.enabled = false;

        background_music = GameObject.FindGameObjectWithTag("background_music").GetComponent<AudioSource>();


        my_next_scenario = GameObject.FindGameObjectWithTag("Next_Scenario").GetComponent<Next_Scenario_Debug>();

    }


    //public void print_att()
    //{
    //    Debug.Log("which_ball_tag" + which_ball_tag);
    //    Debug.Log("ball_color" + ball_color);


    //}




    //when ball was child of number clock

    //public void spawn_ball()
    //{
    //    transform.position = Vector3.zero;
    //}


    #region spawn_ball_methods, two ways
    
    public void spawn_ball() //position of Ball on Clock.
    {
        //clock = GameObject.FindGameObjectWithTag("Clock").transform;

        switch (num_clock)
        {
            case "1":
                //Instantiate(gameObject, clock);
                // transform.position = new Vector3(-0.06966861f, 0.3374501f, 0.07247011f);


                //Instantiate(gameObject);

                //transform.localEulerAngles = new Vector3(0,0,30);


                //transform.position = Ball_manager.pos_num_clock[0];

                // transform.position = Ball_manager.this_ball_manager.offset_clock_1;

                transform.localPosition = new Vector3(-0.03800002f, 0.0589999f, 0.2f);
                break;
            case "1.5":
                // transform.position = Ball_manager.pos_num_clock[1];

                //transform.position = Ball_manager.this_ball_manager.offset_clock_1_5;
                transform.localPosition = new Vector3(0.1120003f, -0.1010002f, 0.1180002f);

                break;

            case "2":
                //  transform.position = Ball_manager.pos_num_clock[2];

                //transform.position = Ball_manager.this_ball_manager.offset_clock_2;

                transform.localPosition = new Vector3(-0.05800009f, 0, 0.2f);
                //transform.localEulerAngles = new Vector3(0, 0, 60);
                break;

            case "3":
                //  transform.position = Ball_manager.pos_num_clock[3];
                //transform.position = Ball_manager.this_ball_manager.offset_clock_3;

                transform.localPosition = new Vector3(-0.03100008f, 0.03199989f, 0.2f);
                //transform.localEulerAngles = new Vector3(0, 0, 90);
                break;
            case "4":
                // transform.position = Ball_manager.pos_num_clock[4];

                // transform.position = Ball_manager.this_ball_manager.offset_clock_4;

                transform.localPosition = new Vector3(-5.960464e-08f, -0.03299981f, 0.2f);

                // transform.localPosition = new Vector3(-0.08599997f, 0.05500013f, 0.2f);
                //transform.localEulerAngles = new Vector3(0, 0, 120);
                break;
            case "5":
                // transform.position = new Vector3(-0.06966849f, 0.07993476f, 0.07247011f);




                // transform.position = Ball_manager.pos_num_clock[5];
                // transform.position = Vector3.zero;

                transform.position = new Vector3(-8.940697e-08f, -0.02900016f, 0.2f);
                //transform.localEulerAngles = new Vector3(0, 0, 150);
                break;
            case "7":
                //transform.position = new Vector3(0.07900808f, 0.07993478f, 0.07247011f);
                //transform.localEulerAngles = new Vector3(0, 0, 210);

                // transform.position = Ball_manager.pos_num_clock[7];
                // transform.position = Vector3.zero;

                transform.position = new Vector3(-0.02319974f, -0.02240014f, 0.2f);
                break;
            case "8":
                //transform.localEulerAngles = new Vector3(0, 0, 240);

                // transform.position = Ball_manager.pos_num_clock[8];

                // transform.position = Ball_manager.this_ball_manager.offset_clock_8;
                transform.localPosition = new Vector3(-5.960464e-08f, -0.03299981f, 0.2f);
                break;
            case "9":
                //transform.localEulerAngles = new Vector3(0, 0, 270);

                // transform.position = Ball_manager.pos_num_clock[9];

                // transform.position = Ball_manager.this_ball_manager.offset_clock_9;

                transform.localPosition = new Vector3(0.0539999f, 0.03000003f, 0.2f);
                break;
            case "10":
                //transform.localEulerAngles = new Vector3(0, 0, 300);

                // transform.position = Ball_manager.pos_num_clock[10];

                // transform.position = Ball_manager.this_ball_manager.offset_clock_10;

                transform.localPosition = new Vector3(0.07500023f, 0, 0.2f);
                break;
            case "10.5":
                //transform.localEulerAngles = new Vector3(0, 0, 300);

                // transform.position = Ball_manager.pos_num_clock[11];
                // transform.position = Ball_manager.this_ball_manager.offset_clock_10_5;
                transform.localPosition = new Vector3(-0.1120003f, -0.1010002f, 0.1180002f);
                break;
            case "11":
                //transform.localEulerAngles = new Vector3(0, 0, 330);

                // transform.position = Ball_manager.pos_num_clock[12];

                // transform.position = Ball_manager.this_ball_manager.offset_clock_11;
                transform.localPosition = new Vector3(0.03799993f, 0.0589999f, 0.2f);
                break;
            case "12_L":
                //transform.position = new Vector3(0.004669772f, 0.3573691f, 0.07247011f);
                //transform.localEulerAngles = new Vector3(0, 0, 360);

                // transform.position = Ball_manager.pos_num_clock[13];


                //transform.position = my_ball_manag.offset_clock_1;

                //transform.position = Ball_manager.this_ball_manager.offset_clock_12_L;
                transform.localPosition = new Vector3(0.164f, 1.467f, 0.3880005f);
                break;
            case "12_R":
                //transform.position = new Vector3(0.004669772f, 0.3573691f, 0.07247011f);
                //transform.localEulerAngles = new Vector3(0, 0, 360);

                // transform.position = Ball_manager.pos_num_clock[13];


                //transform.position = my_ball_manag.offset_clock_1;

                //transform.position = Ball_manager.this_ball_manager.offset_clock_12_R;
                transform.localPosition = new Vector3(-0.07999992f, -0.105f, 0.2f);
                break;

            default:
                //transform.position = my_ball_manag.offset_clock_1;
                break;
        }

    }

    public void Random_generation_number(float min, float max)
    {
        //float my_random


        float my_rand;




        if (min <= max)
        {
             my_rand = UnityEngine.Random.Range(min, max);
        }
        else
        {
             my_rand = UnityEngine.Random.Range(max, min);

           
        }
        //num_clock = my_rand.ToString();

        num_clock = System.Math.Round(my_rand, 1).ToString();

       // num_clock = set_two_points(num_clock);


        Ball_manager.My_Scenario.ball_list[index_ball_list] = num_clock;
            //System.Math.Round(my_rand, 1).ToString();
        index_ball_list++;

       // num_clock = num_clock.ToString();

        set_posBall_center_clock(float.Parse(num_clock));
    }

   
   

    public void set_position_ball_perimeter(float number_clock)
    {
        // transform.position = new Vector3(transform.position.x, transform.position.y + 0.72f, transform.position.z); //R of clock


        // transform.position = new Vector3(transform.position.x, transform.position.y + 0.72f, transform.position.z); //R of clock


        //transform.Translate()

        // Rigidbody my_ball;


        #region down and up clock
        //0.72 is R of clock
        if (4.0f < number_clock && number_clock < 8.0f)
        {
            transform.Translate(Vector3.up * 0.63f);
        }
        else if (11.0f < number_clock && number_clock < 12.0f || 0.0f < number_clock && number_clock < 1.0f)
        { 
            transform.Translate(Vector3.up * 0.68f);

        }

        else
        {
            transform.Translate(Vector3.up * 0.72f);

        }
        #endregion


        // transform.Translate(Vector3.up * 0.72f);

        transform.localRotation = Quaternion.Euler(0, 220, 0);



    }
    public void spawn_ball_degree(float number_clock)
    {

        float my_degree = number_clock * 30;

        // transform.localRotation.eulerAngles =  new Vector3(0, 0, -30.0f);


        transform.localRotation = Quaternion.Euler(0, 0, -my_degree);

        set_position_ball_perimeter(number_clock);

    }

    public void set_posBall_center_clock(float number_clock)
    {
        transform.position = new Vector3(-5.2f, 2.5f, 5.4f); //center of clock

        spawn_ball_degree(number_clock);
    }


    #endregion

    public byte Index_ClockNum(string number) //this method used for return index number of array of transform_clock_num which
                                              //is transform of clock number; used for make child of clock number this ball.
    {
        switch (number)
        {
            case "1":
                return 1;
            case "1.5":
                return 2;
            case "2":
                return 3;
            case "3":
                return 4;
            case "4":
                return 5;
            case "5":
                return 6;
            case "6":
                return 7;
            case "7":
                return 8;
            case "8":
                return 9;
            case "9":
                return 10;
            case "10":
                return 11;
            case "10.5":
                return 12;
            case "11":
                return 13;
            case "12_L":
                return 14;
            case "12_R":
                return 16;



            default:
                return 0;
                
        }


    }

    public IEnumerator  Record_Timer() //Timer of pick up ball.
    {
       // if (this != null)
      //  {

            double Time_Stay = Time_handStay; //Time that is takes to grab ball.



            while (Time_Stay >= 0)
            {
                if (this != null) //if this ball is not Destroyed, check this Condition (used when hand want to grab ball and there is no)
                {
                    label_time.gameObject.SetActive(true);
                    label_time.text = Time_Stay.ToString(); //update UI Label of Timer 

                   

                }



            //Todo:ehsan important debug  Debug.Log(Time_Stay);

               //if (my_beep_sound!=null)
               //   {
               // my_beep_sound.Stop();

               
               //     }


                //Time_Stay = Time_Stay - 0.1;
                Time_Stay = Time_Stay - 0.1;


            Time_Stay = Math.Round(Time_Stay, 1); //we need just one precision of  Time_Stay.

            // if (Math.Round(Time.realtimeSinceStartup) % 2 ==0)
            // {

            if (can_beep) //when timer of grabbing ball starts, beep_sound play. when Ball goes of collision area, this sound stop.
            {
                my_beep_sound.Play();
                //my_beep_sound.loop = true;

                can_beep = false; //in order to not have unpleasent sound.

            }
              

              //  Debug.Log("Time: "+ Time.time);
             //}

            
           // my_beep_sound.Play();

                 //my_beep_sound.PlayOneShot(my_beep_sound.clip, 0.5f);
            yield return new WaitForSeconds(0.1f); //just wait 0.1 second.

            }

        my_beep_sound.Stop(); //when time of grab finished, beep_sound must stoped.

        my_garb_sound.Play(); //grab sound must play.

        Ball_manager.pick_ball_after_clapp_s = false;
         //   if (this != null)
        //    {
                label_time.gameObject.SetActive(false); //if Timer ends, just DeActivate it.
                                                        //   }

        //background_music.Play();
        background_music.volume = 1.0f;


        //if (this == null)
        //{
        //    StopCoroutine(which_hand.timer);
        //}
        // if (this!=null)
        // {
        this.transform.position = which_hand_colide.position; //this ball must be grabbed, so position and parent of this ball must set
                                                                  //to hand.
            this.transform.parent = which_hand_colide; //make this ball child of hand that Collide with it.
        // }


          hand_event which_hand = GameObject.FindGameObjectWithTag(which_ball_tag).GetComponent<hand_event>(); //find which hand grab ball
                                                                                        //set is_grab to true
                                                                                        //because ball is grabbed.
       // which_hand
        which_hand.is_grab = true; 


            //dynamic basket setup



            if (which_ball_tag == "Right")
            {
                //placement of Ball in hands are not the same, so we need to distingusih which hands grab ball.
                this.transform.localPosition = new Vector3(0.057f, 0.062f, 0.014f); //for right hand

                if (Ball_manager.basket_color[2] != ball_color) //Right hand put ball in Right basket,
                                                                //so if they are not the same, must change Right basket
                                                                //and set basket to color of Ball_color and change 
                                                                //position of basket.

                // if (Ball_manager.basket_color["Blue"] != ball_color)
                {
                    //Debug.Log("Basket_color"+Ball_manager.basket_color["Blue"]);
                    Vector3 temp_pos = Ball_manager.Baskets[ball_color].transform.position; //save position of current Basket
                                                                                            //which is in right in temp variable.
                    
                    //change position of Basket that ball must be put on it, so find it and put in in Right.
                    Ball_manager.Baskets[ball_color].transform.position = Ball_manager.Baskets[Ball_manager.basket_color[2]].transform.position;

                    //set position of privious basket in right to privious position of basket that must be now in right. 
                    Ball_manager.Baskets[Ball_manager.basket_color[2]].transform.position = temp_pos;

                    // temp_color = Ball_manager.basket_color["Blue"];
                    //Ball_manager.basket_color["Blue"] = ball_color;
                    //Ball_manager.basket_color[ball_color] = temp_color;

                    temp_color = Ball_manager.basket_color[2]; //save color of Right Basket that must be changed.

                    for (int i = 0; i < 3; i++)
                    {
                        if (Ball_manager.basket_color[i] == ball_color)
                        {                                               // we know that, we have three basket color, which is in Left, Middle and Right
                            Ball_manager.basket_color[i] = temp_color; //find position of basket color that must be set on Right
                                                                       //and change it to basket color on Right.
                        }

                    }


                    Ball_manager.basket_color[2] = ball_color; //change color of Right basket to color of ball.




                    //GameObject.FindGameObjectWithTag(basket_color[1]).SetActive(false);

                    //Ball_manager.Baskets[basket_color[1]].SetActive(false);

                    // basket_color[1] = ball_color;



                    // Ball_manager.Baskets[basket_color[1]].SetActive(true);
                    // Ball_manager.Baskets[basket_color[1]].transform.position = new Vector3(-5.403f, 1.742f, 5.442f);

                    //GameObject basket = Ball_manager.Baskets[basket_color[1]];
                    //  basket.SetActive(true);
                    //  basket.transform.position = new Vector3(-4.918f, 1.742f, 5.442f);
                }

            }
            else //same Comments like Above, but for Left hands.
            {
                this.transform.localPosition = new Vector3(-0.057f, -0.062f, -0.014f); //for Left hand

                if (Ball_manager.basket_color[0] != ball_color)
                // if (Ball_manager.basket_color["Red"] != ball_color)
                {

                    Vector3 temp_pos = Ball_manager.Baskets[ball_color].transform.position;
                    Ball_manager.Baskets[ball_color].transform.position = Ball_manager.Baskets[Ball_manager.basket_color[0]].transform.position;
                    Ball_manager.Baskets[Ball_manager.basket_color[0]].transform.position = temp_pos;

                    //  string temp_color = Ball_manager.basket_color["Red"];
                    temp_color = Ball_manager.basket_color[0];

                    for (int i = 0; i < 3; i++)
                    {
                        if (Ball_manager.basket_color[i] == ball_color)
                        {
                            Ball_manager.basket_color[i] = temp_color;
                        }

                    }


                    Ball_manager.basket_color[0] = ball_color;



                    // Ball_manager.basket_color[ball_color] = temp_color;
                    //GameObject.FindGameObjectWithTag(basket_color[0]).SetActive(false);


                    //Ball_manager.Baskets[basket_color[0]].SetActive(false);

                    // basket_color[0] = ball_color;
                    //Debug.Log("*basket color " + basket_color[0] + " *Ball color" + ball_color);






                    //Ball_manager.Baskets[basket_color[0]].SetActive(true);
                    //Ball_manager.Baskets[basket_color[0]].transform.position = new Vector3(-5.403f, 1.742f, 5.442f);


                    //basket.SetActive(true);
                    //basket.transform.position = new Vector3(-5.403f, 1.742f, 5.442f);

                    //if (ball_color == "Red")
                    //{

                    //}

                }

                //basket_color[0] = ball_color;
            }


            // is_grab = true;


            Rigidbody ball_rigidb = GetComponent<Rigidbody>();
            ball_rigidb.isKinematic = true; //in order to not physcis Simulation changed position of Object, must set isKinematic to True.



            //score();
            //ball_rigidb.detectCollisions = false;

            // Rigidbody my_hand = GetComponentInParent<Rigidbody>();
            //my_hand.detectCollisions = false;


            if (Ball_manager.index_history == 4) //used for UI History of User which is pick up or put (Left-Down UI)
            {
                Ball_manager.index_history = 1; //when all 4 containers are set, change back to one and start again from there.
            }


            if (this.which_ball_tag == "Right") //detect this Ball is right or left in order to write it in CSV file and history. 
            {
                // Ball_manager.history_lable_UI[Ball_manager.index_history + 1].text
                //  = Ball_manager.history_lable_UI[Ball_manager.index_history].text;

            //**** used for write data into CSV File.
                string shoulder = UI_Text.shoulder_right_deg.ToString();
                shoulder = set_space_try( shoulder); //set space for try
                

                string elbow = UI_Text.Elbow_right_deg.ToString();
                 elbow = set_space_try(elbow);  //set space for try



            TimeSpan saat = DateTime.Now.TimeOfDay; //get time when pick up ball happen.
                uint hour = (uint)saat.Hours;
                uint min = (uint)saat.Minutes;
                uint sec = (uint)saat.Seconds;
            //****


                for (int i = Ball_manager.index_history; i >= 1; i--) // if new record Generate, shift down all Records.
                {
                    Ball_manager.history_lable_UI[i].text
                    =
                 Ball_manager.history_lable_UI[i - 1].text;
                }

            //    Ball_manager.history_lable_UI[0].text = //create new record and put it in zero position of array.
            //"Shoulder:" + shoulder + ", Elbow:" + elbow +
            //", Wrist:" + 360 + ", Hand:" + "Right" + ", State: " + "Pick";



            Ball_manager.history_lable_UI[0].text = //create new record and put it in zero position of array.
       shoulder.ToString() + "                                " + elbow.ToString() + "                                  " + "360"
       + "                                         " + "R" + "                                 " + "Pick";

            Ball_manager.index_history++; //each new Record generate, index_history must increase.


            time_that_PickUp = Math.Round(Time.time , 1); //Time  the Ball grabbed.

            //double diff_pickup_start = Math.Round(time_that_PickUp - Ball_manager.time_start_objective_current_ball
            //                                                        - Ball_manager.time_setup_scenario, 1);

            double diff_pickup_start = Math.Round(time_that_PickUp - Ball_manager.time_start_objective_current_ball
                                                                    , 1); //delta t1

            //**Write to CSV file **
            WriteToCSV.write_record(Get_UserName.user_name, shoulder, elbow, "360", "Right", "Pick", hour + ":" + min + ":" + sec
                    , diff_pickup_start.ToString(),"--"
                    ,(Ball_manager.My_Scenario.Next_Scenario-1).ToString()
                     , this.num_clock
                    ,"--");

            


           

            }
            else if (this.which_ball_tag == "Left") //Same as Right but for left hands (Write into CSV file and history label)

            {
                string shoulder = UI_Text.shoulder_left_deg.ToString();
                string elbow = UI_Text.Elbow_left_deg.ToString();


                shoulder = set_space_try(shoulder);
                elbow = set_space_try(elbow);


            TimeSpan saat = DateTime.Now.TimeOfDay;
                uint hour = (uint)saat.Hours;
                uint min = (uint)saat.Minutes;
                uint sec = (uint)saat.Seconds;


                for (int i = Ball_manager.index_history; i >= 1; i--)
                {
                    Ball_manager.history_lable_UI[i].text
                    =
                 Ball_manager.history_lable_UI[i - 1].text;
                }

            //    Ball_manager.history_lable_UI[0].text =
            //"Shoulder:" + UI_Text.shoulder_left_deg + ", Elbow:" + UI_Text.Elbow_left_deg +
            //", Wrist:" + 360 + ", Hand:" + "Left" + ", State: " + "Pick";


            Ball_manager.history_lable_UI[0].text =
          UI_Text.shoulder_left_deg + "                                " + UI_Text.Elbow_left_deg +
     "                                  " + 360 + "                                         " + "L" + "                                 " + "Pick";

            Ball_manager.index_history++;

            time_that_PickUp = Math.Round(Time.time , 1); //the time ball grabbed.

            //double diff_pickup_start = Math.Round(time_that_PickUp - Ball_manager.time_start_objective_current_ball 
            //                                    - Ball_manager.time_setup_scenario, 1);

            double diff_pickup_start = Math.Round(time_that_PickUp - Ball_manager.time_start_objective_current_ball
                                                , 1); //delta t1

            //**Write to CSV file **
            WriteToCSV.write_record(Get_UserName.user_name, shoulder, elbow, "360", "Left", "Pick", hour + ":" + min + ":" + sec
                    , diff_pickup_start.ToString(), "--"
                    , (Ball_manager.My_Scenario.Next_Scenario - 1).ToString()
                    , this.num_clock
                    ,"--");

            

        }






          //  Debug.Log("CoRoutine finished!");
       // }

    }

    public IEnumerator Record_Timer_Put() //same as Record_Timer but in this case when Ball put into basket.
    {
        double Time_Stay = Time_handStay; //Time that user must wait above Basket.


        while (Time_Stay >= 0)
        {
            label_time.gameObject.SetActive(true);
            label_time.text = Time_Stay.ToString();

            //Todo:ehsan important debug  Debug.Log(Time_Stay);

            Time_Stay = Time_Stay - 0.1;

            Time_Stay = Math.Round(Time_Stay, 1);


            if (can_beep_basket) //when ball is in Collider area of basket, beep sound must play up to end, again and again.
            {
                my_beep_sound.Play();
                //my_beep_sound.loop = true;

                can_beep_basket = false; //when beep sound play, another beep sound must not play.

            }




            yield return new WaitForSeconds(0.1f);

        }


        my_beep_sound.Stop(); //when time of put into basket finished, beep_sound must stop.

        label_time.gameObject.SetActive(false);

        //background_music.Play();
        background_music.volume = 1.0f;

        hand_event which_hand = GameObject.FindGameObjectWithTag(which_ball_tag).GetComponent<hand_event>();
        which_hand.is_grab = false;
        //  Rigidbody my_hand = GetComponentInParent<Rigidbody>();
        // my_hand.detectCollisions = true;


        score(); //when Ball put into Basket, Ball_Score must set.

        Ball_manager.score.text = (Int16.Parse(Ball_manager.score.text) + Ball_Score).ToString(); //increase Score UI value with new value.
       // Ball_manager.score.text = Ball_Score.ToString();

        Destroy(gameObject);

        in_basket = true; // when this ball put into basket
      Ball_manager.ball_in_basket++; //when this ball put into basket, ball in basket must increase.

       // is_grab =false;




        if (Ball_manager.index_history == 4)
        {
            Ball_manager.index_history = 1;
        }


        if (this.which_ball_tag == "Right")
        {
            // Ball_manager.history_lable_UI[Ball_manager.index_history + 1].text
            //  = Ball_manager.history_lable_UI[Ball_manager.index_history].text;

            string shoulder = UI_Text.shoulder_right_deg.ToString();
            string elbow = UI_Text.Elbow_right_deg.ToString();


            shoulder = set_space_try(shoulder);
            elbow = set_space_try(elbow);


            TimeSpan saat = DateTime.Now.TimeOfDay;
           uint hour = (uint)saat.Hours;
           uint min = (uint)saat.Minutes;
           uint sec = (uint)saat.Seconds;


            // *** maybe better to save Ball_manager.index_history somewhere ***
            for (int i = Ball_manager.index_history; i >= 1; i--)
            {
                Ball_manager.history_lable_UI[i].text
                =
               Ball_manager.history_lable_UI[i - 1].text;
            }

            

        //    Ball_manager.history_lable_UI[0].text =
        //"Shoulder:" + UI_Text.shoulder_right_deg + ", Elbow:" + UI_Text.Elbow_right_deg +
        //", Wrist:" + 360 + ", Hand:" + "Right" + ", State: " + "Put";


            Ball_manager.history_lable_UI[0].text =
      UI_Text.shoulder_right_deg.ToString() + "                                " +UI_Text.Elbow_right_deg.ToString() +
     "                                  " + 360 + "                                         " + "R" + "                                 " + "Put";

            Ball_manager.index_history++;


           
            time_that_Put = Math.Round(Time.time,1); //the time ball put into basket.

            double diff_time = Math.Round(time_that_Put - time_that_PickUp,1); //delta t2

            //**Write to CSV file **
            WriteToCSV.write_record(Get_UserName.user_name, shoulder, elbow, "360", "Right", "Put", hour + ":" + min + ":" + sec
                ,"--", diff_time.ToString()
                , (Ball_manager.My_Scenario.Next_Scenario - 1).ToString()
                    ,this.num_clock
                    ,Ball_manager.score.text);
            //Time_handStay.ToString()


        }
        else if (this.which_ball_tag == "Left")

        {
            string shoulder = UI_Text.shoulder_left_deg.ToString();
            string elbow = UI_Text.Elbow_left_deg.ToString();

            shoulder = set_space_try(shoulder);
            elbow = set_space_try(elbow);


            TimeSpan saat = DateTime.Now.TimeOfDay;
            uint hour = (uint)saat.Hours;
            uint min = (uint)saat.Minutes;
            uint sec = (uint)saat.Seconds;


            for (int i = Ball_manager.index_history; i >= 1; i--)
            {
                Ball_manager.history_lable_UI[i].text
               =
               Ball_manager.history_lable_UI[i - 1].text;
            }



          


            Ball_manager.history_lable_UI[0].text =
         UI_Text.shoulder_left_deg + "                                " + UI_Text.Elbow_left_deg +
     "                                  " + 360 + "                                         " + "L" + "                                 " + "Put";

            Ball_manager.index_history++;

            time_that_Put = Math.Round(Time.time,1); //the time ball put into basket.
            double diff_time = Math.Round(time_that_Put - time_that_PickUp,1); //delta t2.

            //**Write to CSV file ** 
            WriteToCSV.write_record(Get_UserName.user_name, shoulder, elbow, "360", "Left", "Put", hour + ":" + min + ":" + sec
                ,"--", diff_time.ToString()
                , (Ball_manager.My_Scenario.Next_Scenario - 1).ToString()
                    , this.num_clock
                    , Ball_manager.score.text);

           // Time_handStay.ToString()
        }

        //Int16 index_ball = Ball_manager.My_Scenario.index_ball_list++;
        Ball_manager.My_Scenario.index_ball_list = Ball_manager.My_Scenario.index_ball_list + 1; // when ball put on basket, index must increase
                                                                                                 //and point to new objective.

        if (Ball_manager.My_Scenario.index_ball_list == Ball_manager.My_Scenario.ball_list.Length) //I think we don't needs this comparision
                                                                                                   //, because it never happends.
        {
            Ball_manager.My_Scenario.index_ball_list = 0;
        }




       // Destroy(gameObject);


        

      
        //play clapping sound when Ball put into basket.
        my_tashvig_sound = GameObject.FindGameObjectWithTag("Tashvig_sound").GetComponent<AudioSource>();
        my_tashvig_sound.Play();

       // this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        // Destroy(gameObject); //Destroy that ball when it puts into basket.

        Ball_manager.not_playing = false; //goes to comment where this variable define.

        //float width_sound = my_tashvig_sound.clip.length;
         yield return new WaitForSeconds(3.0f); //test this when other hand want to grab
       
      //  Debug.Log("after destroy " + this);


        Ball_manager.pick_ball_after_clapp_s = true; //can pick other ball, when Tashvig_Sound Finished. 

        //AudioSource my_start_sound =  GameObject.FindGameObjectWithTag("start_sound").GetComponent<AudioSource>();
        //  my_start_sound.Play();



        //Refresh Objective and point to new objective which is new ball.





        // GameObject.FindGameObjectWithTag("obj").GetComponent<TextMesh>().text = Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list];





        // set_color_objective();



        //Ball_manager.time_start_objective_current_ball = 0;




        if (Ball_manager.My_Scenario.numberof_ball == Ball_manager.ball_in_basket) //after all balls put into basket, new Scenario must generate.
        {

            Ball_manager.next_scenario();


            my_next_scenario.Next_Scenario();
            //???????????



            //Ball_manager.ball_in_basket = 0; //when new scenario generate, ball in basket must set to zero.


            //switch (Ball_manager.My_Scenario.Next_Scenario)
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
            //        break;
            //}


            //Scenario one = new Scenario();
            //Ball_manager.My_Scenario.Next;

            // Ball_manager.My_Scenario.Scenario_2();

            // ball_in_basket = 0; //when new scenario generate, ball in basket must set to zero.
        }


        else //when current Scenario not finished and next ball must grab, do this
        {
            AudioSource my_start_sound = GameObject.FindGameObjectWithTag("start_sound").GetComponent<AudioSource>(); //play start sound
            my_start_sound.Play();

            //update Objective

           Ball_manager.set_space_objective(); //adequate space for our objective which is in center of clock.

            Ball_manager.My_Scenario.list_anim_ball[Ball_manager.My_Scenario.index_ball_list].GetComponent<Animator>().enabled = true;
            //enable_animator();


            //GameObject.FindGameObjectWithTag("obj").GetComponent<TextMesh>().text = 
            //    Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list];

            //if (Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list].Length >3)
            //{

            //    GameObject.FindGameObjectWithTag("obj").GetComponent<TextMesh>().text =
            //    Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list];
            //}

            //else if (Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list].Length ==3)
            //{
            //    GameObject.FindGameObjectWithTag("obj").GetComponent<TextMesh>().text =
            //   " "+Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list];

            //}

            //else
            //{
            //    GameObject.FindGameObjectWithTag("obj").GetComponent<TextMesh>().text =
            //    "  " + Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list];

            //}


            //change color of Objective to color of Ball that must Grabbed.
            Ball_manager.set_color_objective();

            // Ball_manager.time_start_objective_current_ball = 0;
            Ball_manager.time_start_objective_current_ball = Math.Round(Time.time,1); //when new objective Assigned, time start that 
                                                                                      //objective must be put into this variable.
        }


        Ball_manager.not_playing = true; //goes to comment where this variable define.

        //   Destroy(gameObject); //Destroy that ball when it puts into basket.

        //  Debug.Log("CoRoutine_put finished!");


        //Destroy(gameObject); //Destroy that ball when it puts into basket.

    }


    public    void score() //Scoreing mechanism, for example when ball is in clock 5 or 7, it has 1 Score, if he puts it, into basket.
    {
        //switch (num_clock)
        //{
        //    case "5":
        //    case "7":
        //        Ball_Score =  1;
        //        break;

        //    case "4":
        //    case "8":
        //        Ball_Score = 2;
        //        break;

        //    case "3":
        //    case "9":
        //        Ball_Score = 3;
        //        break;

        //    case "1":
        //    case "2":
        //    case "11":
        //    case "10":
        //        Ball_Score = 4;
        //        break;

        //    case "12_L":
        //        Ball_Score = 5;
        //        break;

        //    case "12_R":
        //        Ball_Score = 5;
        //        break;


        //    default:
        //        Ball_Score = 0;
        //        break;
        //}

       

        switch (Mathf.RoundToInt(float.Parse(num_clock)).ToString())
        {
            case "5":
            case "7":
                Ball_Score = 10;
                break;

            case "4":
            case "8":
                Ball_Score = 20;
                break;

            case "3":
            case "9":
                Ball_Score = 30;
                break;

            
            case "2":
            case "10":
                Ball_Score = 40;
                break;
            case "1":
            case "11":
            
                Ball_Score = 50;
                break;



            //case "12_L":  
            //case "12_R":
            //    Ball_Score = 60;
            //    break;

            //case "1.5":
            //case "10.5":
            //    Ball_Score = 50;
            //    break;

            case "0":
            case "12":
                Ball_Score = 60;
                break;


            default:
                Ball_Score = 0;
                break;
        }





    }



    public string set_space_try(string joint)
    {
        switch (joint.Length)
        {
            case 5:
                return joint;
                //break;
            case 4:
                return joint + " ";
                // break;
            case 3:
                return joint + "  ";
            case 2:
                return joint + "   ";
            default:
                return joint;
               // break;



        }

        //return;
    
    }

    



    //public   void  enable_animator()
    //{

    //    //my_anim.enabled = true;

    //    my_animator.enabled = true;


    //}
    //private void OnMouseDrag()
    //{

    //    Debug.Log("Mouse Dragged " + this.gameObject.name);
    //}
}
