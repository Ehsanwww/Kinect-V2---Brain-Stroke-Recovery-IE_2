using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Ball_manager : MonoBehaviour
{
  // private Ball ehsan_ball;

    //private GameObject redBall;

    public Transform clock; // get transform of clock which has num clock as childrens. used for ball gameObject to make them
                            //child of num clock.

    //public  static Vector3 [] pos_num_clock; //it was never used, but if have error, uncomment it.

    public static Transform[] transform_clock_num; //Container for Transform of,children of clock which is numbers.


    //public Vector3 offset_Ball1;
    //public Vector3 offset_Ball2;

   // public bool can_offset_ball = false;

    public float offset_z_puppet; //offset z for puppet hands 

   // public  Vector3 offset_clock_1;
   // public  Vector3 offset_clock_1_5;
   // public  Vector3 offset_clock_2;
   // public  Vector3 offset_clock_3;
   // public  Vector3 offset_clock_4;
   // //public  Vector3 offset_clock_5;
   //// public  Vector3 offset_clock_6;
   //// public  Vector3 offset_clock_7;
   // public  Vector3 offset_clock_8;
   // public  Vector3 offset_clock_9;
   // public  Vector3 offset_clock_10;
   // public  Vector3 offset_clock_10_5;
   // public  Vector3 offset_clock_11;
   // public  Vector3 offset_clock_12_L;
   // public  Vector3 offset_clock_12_R;

    //private GameObject ball_1_ins;
    //private GameObject ball_2_ins;

    public static Ball_manager this_ball_manager; //address of Ball_manager when assigned to GameObject


    public  static TextMeshProUGUI score; //in order to access to Score UI 


    

    public static byte index_history = 1;//in order to have which history label must now update(Down_Left UI)
    public static TextMeshProUGUI[] history_lable_UI; //get TextMeshProUGUI of all history labels in order to change it when new record generate.


    //public static bool End_Scenario;

    public static Scenario My_Scenario; //in order to access to current Scenario attributes.

    //we have 3 baskets(Red,yellow,Blue), in order to have dynamic baskets, we need this. in order to optimize it,
    //instead of GameObject, use Transform.
   public static Dictionary<string, GameObject> Baskets = new Dictionary<string, GameObject>();
    
    //which basket is on left, middle, right.
   public static string[] basket_color = { "Red","Yellow" ,"Blue" }; //[0] for left basket, [1] for middle basket, [2] for right basket



    //public static Dictionary<string,string> basket_color = new Dictionary<string, string> { { "Red", "Red" }, { "Yellow","Yellow" },
    //    { "Blue","Blue" }
    //    }; //[0] for left basket, [1] for middle basket, [2] for right basket

    //public static Dictionary<string, string> basket_color = new Dictionary<string, string>();

    //  List<int> primeNumbers = new List<int>();


    public static double time_start_objective_current_ball; //in order to know when new Objective starts.

    public static bool pick_ball_after_clapp_s = true; //when a ball put into Basket and clapping sound play,
                                                       //there is a time that takes to play the sound, when this sound
                                                       //not finished, user can't grab Ball.


    public static byte ball_in_basket = 0; //for changing scenario when all balls put into baskets. 

    public static bool not_playing = true; //when Ball put into basket and clapping sound play, in that time if hand
                                           //exit from Collision Area of Basket, computer thinks it is not in that area
                                           // and CoRoutine Stoped, in order to prevent from that we must set this variable;
                                           //just a line before clapping sound play, this variable go to false and after playing
                                           //is done, it goes to true.

    // public static double time_setup_scenario = 0.0f;


    //we use Timer for AutoStart of each level, in order to control it we must know, we are not in which state of game.
    public static State_Game state_my_game;

    //private Mouse_Movment_time my_mouse;


    public  static GameObject hour_hand;
    public static GameObject min_hand;

    void Start()
    {


        //basket_color.Add("Red", "Red");
        //basket_color.Add("Yellow", "Yellow");
        //basket_color.Add("Blue", "Blue");

       // basket_color.Add("Red", "123");

        score = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>(); //in order to access to current score, use
        //this when new Score generate.

        //in order to access to history labels and change them when new pick or put happens. 
        history_lable_UI = GameObject.FindGameObjectWithTag("history_label").GetComponentsInChildren<TextMeshProUGUI>();







        //when 3d new clock done

        // GameObject clock_num_gameObject = GameObject.FindGameObjectWithTag("clock_num");

        // Transform[] transform_clock_num = clock_num_gameObject.GetComponentsInChildren<Transform>();


        
        transform_clock_num = clock.GetComponentsInChildren<Transform>();




        // offset_clock_1 = Vector3.zero;
        //offset_clock_1_5 = Vector3.zero;
        //offset_clock_2 = Vector3.zero;
        //offset_clock_3 = Vector3.zero;
        //offset_clock_4 = Vector3.zero;
        //offset_clock_5 = Vector3.zero;
        //offset_clock_6 = Vector3.zero;
        //offset_clock_7 = Vector3.zero;
        //offset_clock_8 = Vector3.zero;
        //offset_clock_9 = Vector3.zero;
        //offset_clock_10 = Vector3.zero;
        //offset_clock_10_5 = Vector3.zero;
        //offset_clock_11 = Vector3.zero;
        //offset_clock_12_L = Vector3.zero;
        //offset_clock_12_R = Vector3.zero;



        this_ball_manager = this;




    //Doesnt need to do this, because you make it child of that number, just set it to zero, to stick to number
    //pos_num_clock = new Vector3[transform_clock_num.Length-1];

    ////because in 0, it returns!! father although it must be childern
    //for (int i = 1; i < transform_clock_num.Length; i++)
    //{
    //    //pos_num_clock[i-1] = transform_clock_num[i].localPosition;

    //    pos_num_clock[i - 1] = new Vector3(0,0,0);
    //}





    //clock = GameObject.FindGameObjectWithTag("Clock").transform;


    //redBall = (GameObject) Resources.Load("Red");

    ////redBall.AddComponent<Ball>();
    //ehsan_ball = redBall.GetComponent<Ball>();

    //ehsan_ball.ball_color = "Red";
    ////Right-Left
    //ehsan_ball.which_ball_tag = "Right";

    //ehsan_ball.Time_handStay = 10.5f;


    // ehsan_ball.spawn_ball();

    //Instantiate(redBall, clock);
    //Instantiate(ehsan_ball);



    My_Scenario = new Scenario();
         My_Scenario.Scenario_1(); //first Scenario Generate, when Game Starts.

        //AudioSource my_start_sound = GameObject.FindGameObjectWithTag("start_sound").GetComponent<AudioSource>();
        //my_start_sound.Play();


        //hand_event.current_scenario = My_Scenario;

        //My_Scenario.Scenario_7();

        //Scenario_1();




        //Scenario_7();

        //offset_z_puppet = 2.0f;


        Baskets.Add("Red", GameObject.FindGameObjectWithTag("Red_Basket")); //find GameObjects of all three baskets. 
        Baskets.Add("Yellow", GameObject.FindGameObjectWithTag("Yellow_Basket"));
        Baskets.Add("Blue", GameObject.FindGameObjectWithTag("Blue_Basket"));




        time_start_objective_current_ball = 0;



        state_my_game = State_Game.Config_game; //when game starts, we are in config state of game.


        // my_mouse = new Mouse_Movment_time();

        //hour_hand = GameObject.FindGameObjectWithTag("hour");
        //min_hand = GameObject.FindGameObjectWithTag("min");
      


    }



    private void FixedUpdate()
    {
        //if (can_offset_ball)
        //{
        //    ball_1_ins.transform.localPosition = offset_Ball * Time.deltaTime;
        //    ball_2_ins.transform.localPosition = offset_Ball * Time.deltaTime;

        //}
       // if (can_offset_ball)
      //  {

            //My_Scenario.ball_1_ins.transform.localPosition = offset_Ball1 * Time.deltaTime ;
            //My_Scenario.ball_2_ins.transform.localPosition = offset_Ball2 * Time.deltaTime;




      //  }

        CharTo_puppet.z_offset_puppet = offset_z_puppet; //change z offset of hands_puppet.


        

       // Debug.Log("Time: " + Time.time);
    }

    //private void LateUpdate()
    //{
    //    Scenario.freeze_pos();
    //}


    //public  byte Scenario_1()
    //{
    //    GameObject ball_1;
    //    GameObject ball_2;

    //    Ball ball_comp_ball_1;
    //    Ball ball_comp_ball_2;

    //    //ball_1 = (GameObject)Resources.Load("Red");


    //     ball_1 = Resources.Load<GameObject>("BlueBall"); // it must be blue ******
    //     ball_2 =  Resources.Load<GameObject>("RedBall");

    //    //ball_2 = Instantiate(Resources.Load<GameObject>("Red"), clock);

    //    ball_comp_ball_1 = ball_1.GetComponent<Ball>();
    //    ball_comp_ball_2 = ball_2.GetComponent<Ball>();

    //    ball_comp_ball_1.which_ball_tag = "Right";
    //    ball_comp_ball_1.ball_color = "Blue"; //it must be blue *******
    //    ball_comp_ball_1.Time_handStay = 1.5;
    //    ball_comp_ball_1.num_clock = "5";
    //   //ball_comp_ball_1.score();

    //    ball_comp_ball_1.spawn_ball();

    //    //ball_1_ins = Instantiate(ball_1, clock);

    //    ball_1_ins = Instantiate(ball_1, transform_clock_num[Int16.Parse(ball_comp_ball_1.num_clock)+1]);


    //    ball_comp_ball_2.which_ball_tag = "Left";
    //    ball_comp_ball_2.ball_color = "Red";
    //    ball_comp_ball_2.Time_handStay = 1.5;
    //    ball_comp_ball_2.num_clock = "7";
    //    //ball_comp_ball_2.num_clock = "1";
    //    //ball_comp_ball_2.score();

    //    ball_comp_ball_2.spawn_ball();

    //   // ball_2_ins = Instantiate(ball_2, clock);

    //    ball_2_ins = Instantiate(ball_2, transform_clock_num[Int16.Parse(ball_comp_ball_2.num_clock)+1]);


    //    return 2;

    //}



    //public void Update()
    //{
    //    if (state_my_game == State_Game.Config_game)
    //    {
    //        my_mouse.detect_key();

    //    }
    //    else
    //    {

    //    }
    //}


    public static void next_scenario()
    {

        ball_in_basket = 0; //when new scenario generate, ball in basket must set to zero.




        


        switch (My_Scenario.Next_Scenario)
        {
            case 1:
                My_Scenario.Scenario_1();
                break;
            case 2:
                My_Scenario.Scenario_2();

                break;
            case 3:
                My_Scenario.Scenario_3();
                break;
            case 4:
                My_Scenario.Scenario_4();
                break;
            case 5:
                My_Scenario.Scenario_5();
                break;
            case 6:
                My_Scenario.Scenario_6();
                break;
            case 7:
                My_Scenario.Scenario_7();
                break;

            default:
                break;


              
        }

       // Scenario.freeze_pos();

        //*** when new Scenario must starts, Timer of auto_start must finish or Start button must pushed in order to 
        //*** interact with Ball, so before that, User must not interact with ball and basket.

        GameObject[] balls_scene = GameObject.FindGameObjectsWithTag("Balls");

        //suppose, when user click on ball, click on Start; we must DeActivate Canvas and update Time_handStay of that Ball.
        for (int i = 0; i < balls_scene.Length; i++)
        {                                                       //true
                                                                
            balls_scene[i].GetComponent<Rigidbody>().isKinematic = false;

            //Debug.Log("Rigigd body ball: " + balls_scene[i].GetComponent<Rigidbody>().isKinematic);
        }


        GameObject.FindGameObjectWithTag("Red").GetComponent<Rigidbody>().isKinematic = true;
        GameObject.FindGameObjectWithTag("Yellow").GetComponent<Rigidbody>().isKinematic = true;
        GameObject.FindGameObjectWithTag("Blue").GetComponent<Rigidbody>().isKinematic = true;



        GameObject.FindGameObjectWithTag("Left").GetComponent<Rigidbody>().isKinematic = true;
        GameObject.FindGameObjectWithTag("Right").GetComponent<Rigidbody>().isKinematic = true;

        //*** 

        Ball_manager.state_my_game = Ball_manager.State_Game.Config_game; //when we goes to next_scenario, we are in config_state.



    }


    public enum State_Game //state of game which is config when no CoRoutine of Auto_start Timer is played, when it calls we are
                           // we are in Call_Coroutine, when the Coroutine finshed successfully we are in Play_game state,
                           //when start Button Pushed, we are in Push_by_Start_button.
    { 
        Config_game,
        Play_game,
        Call_Coroutine,
        Push_by_Start_button

    
    }



    //animate hand of clock
    public static void animate_clock(string my_obj)

    {

        hour_hand = GameObject.FindGameObjectWithTag("hour");
        min_hand = GameObject.FindGameObjectWithTag("min");


        //string[] obj_split =  my_obj.Split(':');

        // string[] obj_split = my_obj.Split('.');
        string[] numb_split = my_obj.Split('.');


        if (my_obj.Contains("."))
        {
            //number_ball.IndexOf(".");

            //  number_ball[number_ball.IndexOf(".")]. = ":";

            // string  [] my_numb = number_ball.Split('.');

            int second_num = (int)(5 * float.Parse(my_obj));

            //second_num



            my_obj = my_obj.Replace(".", ":");


           // string[] numb_split = my_obj.Split(':');

            numb_split[1] = second_num.ToString();

            my_obj = numb_split[0] + ":" + numb_split[1];


            //return my_obj;


        }
        else
        {
            //return my_obj;
        }





        hour_hand.transform.localEulerAngles = new Vector3(hour_hand.transform.localEulerAngles.x, hour_hand.transform.localEulerAngles.y, int.Parse(numb_split[0]) * 30);

        if (numb_split.Length == 2)
        {
            min_hand.transform.localEulerAngles = new Vector3(min_hand.transform.localEulerAngles.x, min_hand.transform.localEulerAngles.y,
                                                          ((int.Parse(numb_split[1]) * 30) / 5) - 90);
        }
        else
        {
            min_hand.transform.localEulerAngles = new Vector3(min_hand.transform.localEulerAngles.x, min_hand.transform.localEulerAngles.y,
                                                          (360- 90)); //put hour_clock on 12 clock
        }
        

    }

    public static void set_space_objective()
    {

        // Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list] = 


        //set_two_points(ref Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list]);

        //string h = "1";
        //set_two_points(ref h);


        //new Ball().enable_animator();
        

        //Ball_manager.My_Scenario.list_anim_ball[Ball_manager.My_Scenario.index_ball_list].enabled = true;

        if (Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list].Length > 3)
        {

            GameObject.FindGameObjectWithTag("obj").GetComponent<TextMesh>().text =
            //Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list];
            set_two_points(Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list]);



           
        }

        //if we have string with 3 characters, we need one space.
        else if (Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list].Length == 3)
        {
            GameObject.FindGameObjectWithTag("obj").GetComponent<TextMesh>().text =
                set_two_points(Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list]);
            // " " 


        }

        //if we have string with 2 characters, we need two space.
        else
        {
            GameObject.FindGameObjectWithTag("obj").GetComponent<TextMesh>().text =
            "  " + set_two_points(Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list]);

        }

        //move  hour and min of clock
        Ball_manager.animate_clock(Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list]);
    }

    public static void set_color_objective()
    {
        TextMesh my_objective = GameObject.FindGameObjectWithTag("obj").GetComponent<TextMesh>(); //Objective GameObject.

        switch (Ball_manager.My_Scenario.Ball_color[Ball_manager.My_Scenario.index_ball_list]) //find color of current ball
                                                                                               //that must grab.
        {
            case "Red":
                //  my_objective.color = new Color(255,0,0);
                my_objective.color = Color.red;

                break;
            case "Blue":
                //  my_objective.color = new Color(0,85, 255);

                my_objective.color = Color.blue;

                //  my_objective.color = new Color32(0, 85, 255,255);
                break;
            case "Yellow":
                // my_objective.color = new Color(255, 211, 0);
                // my_objective.color = Color.yellow;
                my_objective.color = new Color32(236, 195, 0, 255);
                break;

            default:
                break;
        }

    }


    //set : between hour and min
    public static string set_two_points(string number_ball)
    {
        //float my_numb = float.Parse(number_ball);




        if (number_ball.Contains("."))
        {
            //number_ball.IndexOf(".");

            //  number_ball[number_ball.IndexOf(".")]. = ":";

            // string  [] my_numb = number_ball.Split('.');

            int second_num = (int)(5 * float.Parse(number_ball));

            //second_num



            number_ball = number_ball.Replace(".", ":");


            string[] numb_split = number_ball.Split(':');

            numb_split[1] = second_num.ToString();

            if (int.Parse(numb_split[1]) <=9)
            {
                
                numb_split[1] = "0" + numb_split[1];
            }

            number_ball = numb_split[0] + ":" + numb_split[1];


            return number_ball;


        }
        else
        {
            return number_ball;
        }

    }











}


