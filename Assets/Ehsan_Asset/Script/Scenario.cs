using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Scenario
{


    public byte numberof_ball; //number of ball in current scenario

    public byte Next_Scenario; //number of Next Scenario (in current scenario)
    public byte pri_Scenario; //number of pri_Scenario  (in current scenario)




    //public GameObject ball_1_ins;
    //public GameObject ball_2_ins;


    public string[] ball_list; //list of ball current Scenario 

    public int index_ball_list; // which ball must grab (it used for grabing of ball and refresh objective)

    //private GameObject ball_1;
    //private GameObject ball_2;

    // //Todo: ehsan ??? aya niaze???
    // public GameObject ball_1_ins;
    // public GameObject ball_2_ins;


    // private Ball ball_comp_ball_1;
    // private Ball ball_comp_ball_2;

    //ball_1 = (GameObject)Resources.Load("Red");

    //  public Ball Current_Ball; //in order to know what is Color of current ball that user must grab, use this to update color of 
    //Objective (Color Objective = Color Ball)

    public string[] Ball_color; //in order to sync Color of Objective to Current Ball which must grab.


    // private string[] All_color_ball = {"Red","Yellow","Blue"};

    private List<string> All_color_ball_R = new List<string>() { "Red", "Yellow", "Blue" };
    private List<string> All_color_ball_L = new List<string>() { "Red", "Yellow", "Blue" };

    private int number_color_ball;

    //[HideInInspector]
    //public List<Animator> list_anim_ball = new List<Animator>();

    [HideInInspector]
    public List<GameObject> list_anim_ball = new List<GameObject>();
    public void Scenario_1()
    {


        Ball.index_ball_list = 0;


        // All_color_ball[Random.Range]


        ball_list = new string[] { "5", "7" };
        //Ball_color = new string[] {"Blue","Red" };

        // string ball_color_random = All_color_ball[UnityEngine.Random.Range(0, 3)];
        //   Ball_color = new string[] { All_color_ball[UnityEngine.Random.Range(0, 3)], All_color_ball[UnityEngine.Random.Range(0, 3)] };

        Ball_color = new string[] { random_ball_right(), random_ball_right() };



        index_ball_list = 0; //when new Scenario genearte, this variable must set to zero

        numberof_ball = 2;


        //*** when new Scenario Called, puppet must DeActivate, interaction mouse with ball and start_Button must Activated

        Start_Scenario.start_button.enabled = true;
        Start_Scenario.my_clickable.gameObject.SetActive(true);
        //  Start_Scenario.my_kinect.SetActive(false);
        //Start_Scenario.my_kinect_manag.enabled = false;
        Start_Scenario.left_pupp.enabled = false;
        Start_Scenario.right_pupp.enabled = false;

        //***

        GameObject ball_1;
        GameObject ball_2;



        // //Todo: ehsan ??? aya niaze???
        GameObject ball_1_ins;
        GameObject ball_2_ins;


        Ball ball_comp_ball_1;
        Ball ball_comp_ball_2;









        ball_1 = Resources.Load<GameObject>(Ball_color[0]); //read from Resource folder, prefab  of ball, in this case BlueBall.
        ball_2 = Resources.Load<GameObject>(Ball_color[1]);

        //ball_2 = Instantiate(Resources.Load<GameObject>("Red"), clock);

        ball_comp_ball_1 = ball_1.GetComponent<Ball>(); //get component Ball which is script, in order to set its attributes.
        ball_comp_ball_2 = ball_2.GetComponent<Ball>();

        ball_comp_ball_1.which_ball_tag = "Right"; //this ball goes in right section of clock(must grab by right hand)
        ball_comp_ball_1.ball_color = Ball_color[0]; //color of  ball
        ball_comp_ball_1.Time_handStay = 1.5; //time needs that patient must have patience :) in pick up and put in basket. 


        //ball_comp_ball_1.num_clock = "1"; //this ball sit on  clock 5.
        // ball_comp_ball_1.num_clock = "5";                             //ball_comp_ball_1.score();





        // ball_comp_ball_1.spawn_ball(); //this method spawn ball in 3d space

        // ball_comp_ball_1.set_posBall_center_clock(Int16.Parse(ball_comp_ball_1.num_clock));

        ball_comp_ball_1.Random_generation_number(4.5f, 5.5f);



        //ball_1_ins = Instantiate(ball_1, clock);


        //Create Ball Game Object and make it child of clock number gameObject that must be. for example 2-> clock num 2 

        // ball_1_ins = GameObject.Instantiate(ball_1, Ball_manager.transform_clock_num[ball_comp_ball_1.Index_ClockNum(ball_comp_ball_1.num_clock)]);
        ball_1_ins = GameObject.Instantiate(ball_1);

        // ball_comp_ball_1.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        //ball_comp_ball_1.spawn_ball();


        ball_comp_ball_2.which_ball_tag = "Left";
        ball_comp_ball_2.ball_color = Ball_color[1];
        ball_comp_ball_2.Time_handStay = 1.5;
        // ball_comp_ball_2.num_clock = "7";
        //ball_comp_ball_2.num_clock = "1";
        //ball_comp_ball_2.score();

        // ball_comp_ball_2.spawn_ball();

        // ball_comp_ball_2.set_posBall_center_clock(Int16.Parse(ball_comp_ball_2.num_clock));
        ball_comp_ball_2.Random_generation_number(6.5f, 7.5f);


        // ball_2_ins = Instantiate(ball_2, clock);

        //  ball_2_ins = GameObject.Instantiate(ball_2, Ball_manager.transform_clock_num[ball_comp_ball_2.Index_ClockNum(ball_comp_ball_2.num_clock)]);

        ball_2_ins = GameObject.Instantiate(ball_2);



        Next_Scenario = 2;
        pri_Scenario = 7;

        //  GmeObject.FindGameObjectWithTag("obj").GetComponent<TextMeshProUGUI>().text = "Objective: " + Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list];

        //when this Scenario called, update Objective and Color of it.
        //GameObject.FindGameObjectWithTag("obj").GetComponent<TextMesh>().text = Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list];

        //when new objective must go to Scene, dynamic space of that Objective and Color of it must be Refreshed.



        // list_anim_ball.Clear();




        // list_anim_ball.Add(ball_1_ins);

        //list_anim_ball[0].GetComponent<Animator>().enabled = true;



        // list_anim_ball.Add(ball_2_ins);

        // list_anim_ball[1].GetComponent<Animator>().enabled = false;

       // GameObject[] my_obj = { ball_1_ins, ball_2_ins };

        reset_anim(new GameObject[] { ball_1_ins, ball_2_ins });

        //list_anim_ball[1].enabled = false;

        Ball_manager.set_space_objective();

        set_color_objective();

        // Ball_manager.state_my_game = Ball_manager.State_Game.Config_game;

        //freeze_pos();

        reset_list_color_each_scenerio();



       



        
       // set_rigid_body();
    }

    public  void Scenario_2()
    {
        Ball.index_ball_list = 0;

        ball_list = new string[] { "4", "8" ,"4","8"};

        
        Ball_color = new string[] { random_ball_right(), random_ball_left()
                                    ,random_ball_right(), random_ball_left()};
    

        index_ball_list = 0;


        numberof_ball = 4;


        Start_Scenario.start_button.enabled = true;
        Start_Scenario.my_clickable.gameObject.SetActive(true);
        //  Start_Scenario.my_kinect.SetActive(false);
        //Start_Scenario.my_kinect_manag.enabled = false;
        Start_Scenario.left_pupp.enabled = false;
        Start_Scenario.right_pupp.enabled = false;


        GameObject ball_1;
        GameObject ball_2;
        GameObject ball_3;
        GameObject ball_4;

        // //Todo: ehsan ??? aya niaze???
        GameObject ball_1_ins;
        GameObject ball_2_ins;
        GameObject ball_3_ins;
        GameObject ball_4_ins;


        Ball ball_comp_ball_1;
        Ball ball_comp_ball_2;
        Ball ball_comp_ball_3;
        Ball ball_comp_ball_4;









        ball_1 = Resources.Load<GameObject>(Ball_color[0]); 
        ball_2 = Resources.Load<GameObject>(Ball_color[1]);
        ball_3 = Resources.Load<GameObject>(Ball_color[2]);
        ball_4 = Resources.Load<GameObject>(Ball_color[3]);



        ball_comp_ball_1 = ball_1.GetComponent<Ball>();
        ball_comp_ball_2 = ball_2.GetComponent<Ball>();
        ball_comp_ball_3= ball_3.GetComponent<Ball>();
        ball_comp_ball_4 = ball_4.GetComponent<Ball>();

        ball_comp_ball_1.which_ball_tag = "Right";
        ball_comp_ball_1.ball_color = Ball_color[0]; 
        ball_comp_ball_1.Time_handStay = 1.5;
      //  ball_comp_ball_1.num_clock = "4";
        



       // ball_comp_ball_1.spawn_ball();
        ball_comp_ball_1.Random_generation_number(3.5f, 4.5f);





       // ball_1_ins = GameObject.Instantiate(ball_1, Ball_manager.transform_clock_num[ball_comp_ball_1.Index_ClockNum(ball_comp_ball_1.num_clock)]);
        ball_1_ins = GameObject.Instantiate(ball_1);



        ball_comp_ball_2.which_ball_tag = "Left";
        ball_comp_ball_2.ball_color = Ball_color[1];
        ball_comp_ball_2.Time_handStay = 1.5;
       // ball_comp_ball_2.num_clock = "8";


        // ball_comp_ball_2.spawn_ball();
        ball_comp_ball_2.Random_generation_number(7.5f, 8.5f);


       // ball_2_ins = GameObject.Instantiate(ball_2, Ball_manager.transform_clock_num[ball_comp_ball_2.Index_ClockNum(ball_comp_ball_2.num_clock)]);
        ball_2_ins = GameObject.Instantiate(ball_2);


        ball_comp_ball_3.which_ball_tag = "Right";
        ball_comp_ball_3.ball_color = Ball_color[2];
        ball_comp_ball_3.Time_handStay = 1.5;
        // ball_comp_ball_2.num_clock = "8";


        // ball_comp_ball_2.spawn_ball();
        ball_comp_ball_3.Random_generation_number(4.5f, 5.5f);


        // ball_2_ins = GameObject.Instantiate(ball_2, Ball_manager.transform_clock_num[ball_comp_ball_2.Index_ClockNum(ball_comp_ball_2.num_clock)]);
        ball_3_ins = GameObject.Instantiate(ball_3);




        ball_comp_ball_4.which_ball_tag = "Left";
        ball_comp_ball_4.ball_color = Ball_color[3];
        ball_comp_ball_4.Time_handStay = 1.5;
        // ball_comp_ball_2.num_clock = "8";


        // ball_comp_ball_2.spawn_ball();
        ball_comp_ball_4.Random_generation_number(6.5f, 7.5f);


        // ball_2_ins = GameObject.Instantiate(ball_2, Ball_manager.transform_clock_num[ball_comp_ball_2.Index_ClockNum(ball_comp_ball_2.num_clock)]);
        ball_4_ins = GameObject.Instantiate(ball_4);


        Next_Scenario = 3;
        pri_Scenario = 1;


        //  GameObject.FindGameObjectWithTag("obj").GetComponent<TextMeshProUGUI>().text = "Objective: " + Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list];
        //GameObject.FindGameObjectWithTag("obj").GetComponent<TextMesh>().text = Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list];

        reset_anim(new GameObject[] { ball_1_ins, ball_2_ins,ball_3_ins,ball_4_ins });


        Ball_manager.set_space_objective();
        set_color_objective();


        //  Ball_manager.state_my_game = Ball_manager.State_Game.Config_game;
        index_ball_list = 0;

        // freeze_pos();


        reset_list_color_each_scenerio();

       // set_rigid_body();
    }

    public void Scenario_3()
    {
        Ball.index_ball_list = 0;

        ball_list = new string[] { "4", "8","2","10" };
        Ball_color = new string[] { random_ball_right(), random_ball_left()
                                    ,random_ball_right(), random_ball_left() };
        numberof_ball = 4;

        index_ball_list = 0;

        Start_Scenario.start_button.enabled = true;
        Start_Scenario.my_clickable.gameObject.SetActive(true);
        // Start_Scenario.my_kinect.SetActive(false);
        // Start_Scenario.my_kinect_manag.enabled = false;
        Start_Scenario.left_pupp.enabled = false;
        Start_Scenario.right_pupp.enabled = false;


        GameObject ball_1;
        GameObject ball_2;
        GameObject ball_3;
        GameObject ball_4;

        // //Todo: ehsan ??? aya niaze???
        GameObject ball_1_ins;
        GameObject ball_2_ins;
        GameObject ball_3_ins;
        GameObject ball_4_ins;


        Ball ball_comp_ball_1;
        Ball ball_comp_ball_2;
        Ball ball_comp_ball_3;
        Ball ball_comp_ball_4;









        ball_1 = Resources.Load<GameObject>(Ball_color[0]);
        ball_2 = Resources.Load<GameObject>(Ball_color[1]);
        ball_3 = Resources.Load<GameObject>(Ball_color[2]);
        ball_4 = Resources.Load<GameObject>(Ball_color[3]);



        ball_comp_ball_1 = ball_1.GetComponent<Ball>();
        ball_comp_ball_2 = ball_2.GetComponent<Ball>();
        ball_comp_ball_3 = ball_3.GetComponent<Ball>();
        ball_comp_ball_4 = ball_4.GetComponent<Ball>();

        ball_comp_ball_1.which_ball_tag = "Right";
        ball_comp_ball_1.ball_color = Ball_color[0];
        ball_comp_ball_1.Time_handStay = 1.5;
      //  ball_comp_ball_1.num_clock = "4";




      //  ball_comp_ball_1.spawn_ball();
        ball_comp_ball_1.Random_generation_number(3.0f, 3.5f);





       // ball_1_ins = GameObject.Instantiate(ball_1, Ball_manager.transform_clock_num[ball_comp_ball_1.Index_ClockNum(ball_comp_ball_1.num_clock)]);
        ball_1_ins = GameObject.Instantiate(ball_1);



        ball_comp_ball_2.which_ball_tag = "Left";
        ball_comp_ball_2.ball_color = Ball_color[1];
        ball_comp_ball_2.Time_handStay = 1.5;
        //  ball_comp_ball_2.num_clock = "8";


        // ball_comp_ball_2.spawn_ball();
        ball_comp_ball_2.Random_generation_number(8.5f, 9.0f);



        ball_2_ins = GameObject.Instantiate(ball_2);



        ball_comp_ball_3.which_ball_tag = "Right";
        ball_comp_ball_3.ball_color = Ball_color[2];
        ball_comp_ball_3.Time_handStay = 1.5;
        //  ball_comp_ball_3.num_clock = "2";




        // ball_comp_ball_3.spawn_ball();
        ball_comp_ball_3.Random_generation_number(3.5f, 5.0f);




        ball_3_ins = GameObject.Instantiate(ball_3);





        ball_comp_ball_4.which_ball_tag = "Left";
        ball_comp_ball_4.ball_color = Ball_color[3];
        ball_comp_ball_4.Time_handStay = 1.5;
       // ball_comp_ball_4.num_clock = "10";




       // ball_comp_ball_4.spawn_ball();
        ball_comp_ball_4.Random_generation_number(7.0f, 8.5f);




        ball_4_ins = GameObject.Instantiate(ball_4);

        


        Next_Scenario = 4;
        pri_Scenario = 2;

        reset_anim(new GameObject[] { ball_1_ins, ball_2_ins, ball_3_ins, ball_4_ins });


        //  GameObject.FindGameObjectWithTag("obj").GetComponent<TextMeshProUGUI>().text = "Objective: " + Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list];
        //GameObject.FindGameObjectWithTag("obj").GetComponent<TextMesh>().text = Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list];
        Ball_manager.set_space_objective();
        set_color_objective();


        // freeze_pos();

        reset_list_color_each_scenerio();

      //  set_rigid_body();
    }

    public void Scenario_4()
    {
        Ball.index_ball_list = 0;

        ball_list = new string[] { "3", "9", "5", "11","11","11" };
        Ball_color = new string[] { random_ball_right(), random_ball_left()
                                    ,random_ball_right(), random_ball_left()
                                    ,random_ball_right(), random_ball_left()};

        numberof_ball = 6;
        index_ball_list = 0;


        Start_Scenario.start_button.enabled = true;
        Start_Scenario.my_clickable.gameObject.SetActive(true);
        // Start_Scenario.my_kinect.SetActive(false);
        // Start_Scenario.my_kinect_manag.enabled = false;
        Start_Scenario.left_pupp.enabled = false;
        Start_Scenario.right_pupp.enabled = false;


        GameObject ball_1;
        GameObject ball_2;
        GameObject ball_3;
        GameObject ball_4;
        GameObject ball_5;
        GameObject ball_6;



        // //Todo: ehsan ??? aya niaze???
        GameObject ball_1_ins;
        GameObject ball_2_ins;
        GameObject ball_3_ins;
        GameObject ball_4_ins;
        GameObject ball_5_ins;
        GameObject ball_6_ins;


        Ball ball_comp_ball_1;
        Ball ball_comp_ball_2;
        Ball ball_comp_ball_3;
        Ball ball_comp_ball_4;
        Ball ball_comp_ball_5;
        Ball ball_comp_ball_6;









        ball_1 = Resources.Load<GameObject>(Ball_color[0]);
        ball_2 = Resources.Load<GameObject>(Ball_color[1]);
        ball_3 = Resources.Load<GameObject>(Ball_color[2]);
        ball_4 = Resources.Load<GameObject>(Ball_color[3]);
        ball_5 = Resources.Load<GameObject>(Ball_color[4]);
        ball_6 = Resources.Load<GameObject>(Ball_color[5]);




        ball_comp_ball_1 = ball_1.GetComponent<Ball>();
        ball_comp_ball_2 = ball_2.GetComponent<Ball>();
        ball_comp_ball_3 = ball_3.GetComponent<Ball>();
        ball_comp_ball_4 = ball_4.GetComponent<Ball>();
        ball_comp_ball_5 = ball_5.GetComponent<Ball>();
        ball_comp_ball_6 = ball_6.GetComponent<Ball>();


        ball_comp_ball_1.which_ball_tag = "Right";
        ball_comp_ball_1.ball_color = Ball_color[0];
        ball_comp_ball_1.Time_handStay = 2.5;
        //  ball_comp_ball_1.num_clock = "3";




        // ball_comp_ball_1.spawn_ball();

        ball_comp_ball_1.Random_generation_number(2.5f, 3.5f);





        ball_1_ins = GameObject.Instantiate(ball_1);



        ball_comp_ball_2.which_ball_tag = "Left";
        ball_comp_ball_2.ball_color = Ball_color[1];
        ball_comp_ball_2.Time_handStay = 2.5;
        // ball_comp_ball_2.num_clock = "9";


        // ball_comp_ball_2.spawn_ball();
        ball_comp_ball_2.Random_generation_number(8.5f, 9.5f);


        ball_2_ins = GameObject.Instantiate(ball_2);



        ball_comp_ball_3.which_ball_tag = "Right";
        ball_comp_ball_3.ball_color = Ball_color[2];
        ball_comp_ball_3.Time_handStay = 2.5;
        //ball_comp_ball_3.num_clock = "5";




        //ball_comp_ball_3.spawn_ball();




        ball_comp_ball_3.Random_generation_number(3.5f, 4.0f);
        ball_3_ins = GameObject.Instantiate(ball_3);





        ball_comp_ball_4.which_ball_tag = "Left";
        ball_comp_ball_4.ball_color = Ball_color[3];
        ball_comp_ball_4.Time_handStay = 2.5;
        // ball_comp_ball_4.num_clock = "11";




        // ball_comp_ball_4.spawn_ball();




        ball_comp_ball_4.Random_generation_number(8.0f, 8.5f);
        ball_4_ins = GameObject.Instantiate(ball_4);



        ball_comp_ball_5.which_ball_tag = "Right";
        ball_comp_ball_5.ball_color = Ball_color[4];
        ball_comp_ball_5.Time_handStay = 2.5;
        //  ball_comp_ball_1.num_clock = "3";




        // ball_comp_ball_1.spawn_ball();

        ball_comp_ball_5.Random_generation_number(4.0f, 5.0f);





        ball_5_ins = GameObject.Instantiate(ball_5);


        ball_comp_ball_6.which_ball_tag = "Left";
        ball_comp_ball_6.ball_color = Ball_color[5];
        ball_comp_ball_6.Time_handStay = 2.5;
        //  ball_comp_ball_1.num_clock = "3";




        // ball_comp_ball_1.spawn_ball();

        ball_comp_ball_6.Random_generation_number(7.0f, 8.0f);





        ball_6_ins = GameObject.Instantiate(ball_6);






        Next_Scenario = 5;
        pri_Scenario = 3;


        reset_anim(new GameObject[] { ball_1_ins, ball_2_ins, ball_3_ins, ball_4_ins, ball_5_ins, ball_6_ins });


        // GameObject.FindGameObjectWithTag("obj").GetComponent<TextMeshProUGUI>().text = "Objective: " + Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list];
        // GameObject.FindGameObjectWithTag("obj").GetComponent<TextMesh>().text = Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list];
        Ball_manager.set_space_objective();
        set_color_objective();

        // freeze_pos();

        reset_list_color_each_scenerio();

      //  set_rigid_body();
    }

    public void Scenario_5()
    {
        Ball.index_ball_list = 0;
        ball_list = new string[] { "3", "9", "1", "7","7","7" };
        Ball_color = new string[] { random_ball_right(), random_ball_left()
                                    ,random_ball_right(), random_ball_left()
                                    ,random_ball_right(), random_ball_left()};

        numberof_ball = 6;
        index_ball_list = 0;


        Start_Scenario.start_button.enabled = true;
        Start_Scenario.my_clickable.gameObject.SetActive(true);
        //Start_Scenario.my_kinect.SetActive(false);
        //Start_Scenario.my_kinect_manag.enabled = false;
        Start_Scenario.left_pupp.enabled = false;
        Start_Scenario.right_pupp.enabled = false;


        GameObject ball_1;
        GameObject ball_2;
        GameObject ball_3;
        GameObject ball_4;
        GameObject ball_5;
        GameObject ball_6;

        // //Todo: ehsan ??? aya niaze???
        GameObject ball_1_ins;
        GameObject ball_2_ins;
        GameObject ball_3_ins;
        GameObject ball_4_ins;
        GameObject ball_5_ins;
        GameObject ball_6_ins;


        Ball ball_comp_ball_1;
        Ball ball_comp_ball_2;
        Ball ball_comp_ball_3;
        Ball ball_comp_ball_4;
        Ball ball_comp_ball_5;
        Ball ball_comp_ball_6;










        ball_1 = Resources.Load<GameObject>(Ball_color[0]);
        ball_2 = Resources.Load<GameObject>(Ball_color[1]);
        ball_3 = Resources.Load<GameObject>(Ball_color[2]);
        ball_4 = Resources.Load<GameObject>(Ball_color[3]);
        ball_5 = Resources.Load<GameObject>(Ball_color[4]);
        ball_6 = Resources.Load<GameObject>(Ball_color[5]);




        ball_comp_ball_1 = ball_1.GetComponent<Ball>();
        ball_comp_ball_2 = ball_2.GetComponent<Ball>();
        ball_comp_ball_3 = ball_3.GetComponent<Ball>();
        ball_comp_ball_4 = ball_4.GetComponent<Ball>();
        ball_comp_ball_5 = ball_5.GetComponent<Ball>();
        ball_comp_ball_6 = ball_6.GetComponent<Ball>();


        ball_comp_ball_1.which_ball_tag = "Right";
        ball_comp_ball_1.ball_color = Ball_color[0];
        ball_comp_ball_1.Time_handStay = 2.5;
        // ball_comp_ball_1.num_clock = "3";




        //ball_comp_ball_1.spawn_ball();
        ball_comp_ball_1.Random_generation_number(1.5f, 2.5f);





        ball_1_ins = GameObject.Instantiate(ball_1);



        ball_comp_ball_2.which_ball_tag = "Left";
        ball_comp_ball_2.ball_color = Ball_color[1];
        ball_comp_ball_2.Time_handStay = 2.5;
        //  ball_comp_ball_2.num_clock = "9";


        //  ball_comp_ball_2.spawn_ball();

        ball_comp_ball_2.Random_generation_number(9.5f, 10.5f);




        ball_2_ins = GameObject.Instantiate(ball_2);



        ball_comp_ball_3.which_ball_tag = "Right";
        ball_comp_ball_3.ball_color = Ball_color[2];
        ball_comp_ball_3.Time_handStay = 2.5;
        // ball_comp_ball_3.num_clock = "1";




        //ball_comp_ball_3.spawn_ball();

        ball_comp_ball_3.Random_generation_number(2.5f, 3.5f);




        ball_3_ins = GameObject.Instantiate(ball_3);





        ball_comp_ball_4.which_ball_tag = "Left";
        ball_comp_ball_4.ball_color = Ball_color[3];
        ball_comp_ball_4.Time_handStay = 2.5;
        // ball_comp_ball_4.num_clock = "7";




        //ball_comp_ball_4.spawn_ball();


        ball_comp_ball_4.Random_generation_number(8.5f, 9.5f);



        ball_4_ins = GameObject.Instantiate(ball_4);




        ball_comp_ball_5.which_ball_tag = "Right";
        ball_comp_ball_5.ball_color = Ball_color[4];
        ball_comp_ball_5.Time_handStay = 2.5;
        // ball_comp_ball_4.num_clock = "7";




        //ball_comp_ball_4.spawn_ball();


        ball_comp_ball_5.Random_generation_number(3.5f, 4.5f);



        ball_5_ins = GameObject.Instantiate(ball_5);



        ball_comp_ball_6.which_ball_tag = "Left";
        ball_comp_ball_6.ball_color = Ball_color[4];
        ball_comp_ball_6.Time_handStay = 2.5;
        // ball_comp_ball_4.num_clock = "7";




        //ball_comp_ball_4.spawn_ball();


        ball_comp_ball_6.Random_generation_number(7.5f, 8.5f);



        ball_6_ins = GameObject.Instantiate(ball_6);




        Next_Scenario = 6;
        pri_Scenario = 4;


        reset_anim(new GameObject[] { ball_1_ins, ball_2_ins, ball_3_ins, ball_4_ins, ball_5_ins, ball_6_ins });

        //  GameObject.FindGameObjectWithTag("obj").GetComponent<TextMeshProUGUI>().text = "Objective: " + Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list];
        //GameObject.FindGameObjectWithTag("obj").GetComponent<TextMesh>().text = Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list];

        Ball_manager.set_space_objective();
        set_color_objective();

        // index_ball_list = 0;
        //   freeze_pos();

        reset_list_color_each_scenerio();

       // set_rigid_body();
    }

    public void Scenario_6()
    {
        Ball.index_ball_list = 0;
        ball_list = new string[] { "3", "9", "1", "7","11","5" };
        Ball_color = new string[] { random_ball_right(), random_ball_left()
                                    ,random_ball_right(), random_ball_left()
                                    ,random_ball_right(), random_ball_left() };

        numberof_ball = 6;
        index_ball_list = 0;


        Start_Scenario.start_button.enabled = true;
        Start_Scenario.my_clickable.gameObject.SetActive(true);
        // Start_Scenario.my_kinect.SetActive(false);
        // Start_Scenario.my_kinect_manag.enabled = false;
        Start_Scenario.left_pupp.enabled = false;
        Start_Scenario.right_pupp.enabled = false;


        GameObject ball_1;
        GameObject ball_2;
        GameObject ball_3;
        GameObject ball_4;
        GameObject ball_5;
        GameObject ball_6;

        // //Todo: ehsan ??? aya niaze???
        GameObject ball_1_ins;
        GameObject ball_2_ins;
        GameObject ball_3_ins;
        GameObject ball_4_ins;
        GameObject ball_5_ins;
        GameObject ball_6_ins;


        Ball ball_comp_ball_1;
        Ball ball_comp_ball_2;
        Ball ball_comp_ball_3;
        Ball ball_comp_ball_4;
        Ball ball_comp_ball_5;
        Ball ball_comp_ball_6;









        ball_1 = Resources.Load<GameObject>(Ball_color[0]);
        ball_2 = Resources.Load<GameObject>(Ball_color[1]);
        ball_3 = Resources.Load<GameObject>(Ball_color[2]);
        ball_4 = Resources.Load<GameObject>(Ball_color[3]);
        ball_5 = Resources.Load<GameObject>(Ball_color[4]);
        ball_6 = Resources.Load<GameObject>(Ball_color[5]);



        ball_comp_ball_1 = ball_1.GetComponent<Ball>();
        ball_comp_ball_2 = ball_2.GetComponent<Ball>();
        ball_comp_ball_3 = ball_3.GetComponent<Ball>();
        ball_comp_ball_4 = ball_4.GetComponent<Ball>();
        ball_comp_ball_5 = ball_5.GetComponent<Ball>();
        ball_comp_ball_6 = ball_6.GetComponent<Ball>();



        ball_comp_ball_1.which_ball_tag = "Right";
        ball_comp_ball_1.ball_color = Ball_color[0];
        ball_comp_ball_1.Time_handStay = 3;
        //  ball_comp_ball_1.num_clock = "3";




        //  ball_comp_ball_1.spawn_ball();
        ball_comp_ball_1.Random_generation_number(1.0f, 2.0f);





        ball_1_ins = GameObject.Instantiate(ball_1);



        ball_comp_ball_2.which_ball_tag = "Left";
        ball_comp_ball_2.ball_color = Ball_color[1];
        ball_comp_ball_2.Time_handStay = 3;
        // ball_comp_ball_2.num_clock = "9";


        // ball_comp_ball_2.spawn_ball();


        ball_comp_ball_2.Random_generation_number(10.0f, 11.0f);

        ball_2_ins = GameObject.Instantiate(ball_2);



        ball_comp_ball_3.which_ball_tag = "Right";
        ball_comp_ball_3.ball_color = Ball_color[2];
        ball_comp_ball_3.Time_handStay = 3;
        // ball_comp_ball_3.num_clock = "1";




        //ball_comp_ball_3.spawn_ball();




        ball_comp_ball_3.Random_generation_number(2.0f, 3.0f);

        ball_3_ins = GameObject.Instantiate(ball_3);





        ball_comp_ball_4.which_ball_tag = "Left";
        ball_comp_ball_4.ball_color = Ball_color[3];
        ball_comp_ball_4.Time_handStay = 3;
        // ball_comp_ball_4.num_clock = "7";




        //ball_comp_ball_4.spawn_ball();




        ball_comp_ball_4.Random_generation_number(9.0f, 10.0f);
        ball_4_ins = GameObject.Instantiate(ball_4);



        ball_comp_ball_5.which_ball_tag = "Right";
        ball_comp_ball_5.ball_color = Ball_color[4];
        ball_comp_ball_5.Time_handStay = 3;
        //  ball_comp_ball_5.num_clock = "11";




        //  ball_comp_ball_5.spawn_ball();




        ball_comp_ball_5.Random_generation_number(3.0f, 4.0f);
        ball_5_ins = GameObject.Instantiate(ball_5);




        ball_comp_ball_6.which_ball_tag = "Left";
        ball_comp_ball_6.ball_color = Ball_color[5];
        ball_comp_ball_6.Time_handStay = 3;
        // ball_comp_ball_6.num_clock = "5";




        //ball_comp_ball_6.spawn_ball();




        ball_comp_ball_6.Random_generation_number(8.0f, 9.0f);
        ball_6_ins = GameObject.Instantiate(ball_6);







        Next_Scenario = 7;
        pri_Scenario = 5;

        reset_anim(new GameObject[] { ball_1_ins, ball_2_ins, ball_3_ins, ball_4_ins, ball_5_ins, ball_6_ins });


        //  GameObject.FindGameObjectWithTag("obj").GetComponent<TextMeshProUGUI>().text = "Objective: " + Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list];
        // GameObject.FindGameObjectWithTag("obj").GetComponent<TextMesh>().text = Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list];
        Ball_manager.set_space_objective();
        set_color_objective();


        // freeze_pos();
        reset_list_color_each_scenerio();

      //  set_rigid_body();
    }

    public void Scenario_7()
    {
        Ball.index_ball_list = 0;
        ball_list = new string[] { "3", "9", "1.5", "10.5", "12_L", "12_R" };
        Ball_color = new string[] { random_ball_right(), random_ball_left()
                                    ,random_ball_right(), random_ball_left()
                                    ,random_ball_right(), random_ball_left() };

        numberof_ball = 6;
        index_ball_list = 0;


        Start_Scenario.start_button.enabled = true;
        Start_Scenario.my_clickable.gameObject.SetActive(true);
        // Start_Scenario.my_kinect.SetActive(false);
        //Start_Scenario.my_kinect_manag.enabled = false;
        Start_Scenario.left_pupp.enabled =false;
        Start_Scenario.right_pupp.enabled = false;


        GameObject ball_1;
        GameObject ball_2;
        GameObject ball_3;
        GameObject ball_4;
        GameObject ball_5;
        GameObject ball_6;

        // //Todo: ehsan ??? aya niaze???
        GameObject ball_1_ins;
        GameObject ball_2_ins;
        GameObject ball_3_ins;
        GameObject ball_4_ins;
        GameObject ball_5_ins;
        GameObject ball_6_ins;


        Ball ball_comp_ball_1;
        Ball ball_comp_ball_2;
        Ball ball_comp_ball_3;
        Ball ball_comp_ball_4;
        Ball ball_comp_ball_5;
        Ball ball_comp_ball_6;









        ball_1 = Resources.Load<GameObject>(Ball_color[0]);
        ball_2 = Resources.Load<GameObject>(Ball_color[1]);
        ball_3 = Resources.Load<GameObject>(Ball_color[2]);
        ball_4 = Resources.Load<GameObject>(Ball_color[3]);
        ball_5 = Resources.Load<GameObject>(Ball_color[4]);
        ball_6 = Resources.Load<GameObject>(Ball_color[5]);



        ball_comp_ball_1 = ball_1.GetComponent<Ball>();
        ball_comp_ball_2 = ball_2.GetComponent<Ball>();
        ball_comp_ball_3 = ball_3.GetComponent<Ball>();
        ball_comp_ball_4 = ball_4.GetComponent<Ball>();
        ball_comp_ball_5 = ball_5.GetComponent<Ball>();
        ball_comp_ball_6 = ball_6.GetComponent<Ball>();



        ball_comp_ball_1.which_ball_tag = "Right";
        ball_comp_ball_1.ball_color = Ball_color[0];
        ball_comp_ball_1.Time_handStay = 3.5;
        //  ball_comp_ball_1.num_clock = "3";




        // ball_comp_ball_1.spawn_ball();


        ball_comp_ball_1.Random_generation_number(0.0f,0.5f);

        //Debug.Log("Random number:" + UnityEngine.Random.Range(12.0f,0.5f));
        //Debug.Log("Random number:" + UnityEngine.Random.Range( 0.5f,12.0f));

        
        ball_1_ins = GameObject.Instantiate(ball_1);

       // ball_comp_ball_1.spawn_ball();



        ball_comp_ball_2.which_ball_tag = "Left";
        ball_comp_ball_2.ball_color = Ball_color[1];
        ball_comp_ball_2.Time_handStay = 3.5;
        //  ball_comp_ball_2.num_clock = "9";


        //  ball_comp_ball_2.spawn_ball();

        ball_comp_ball_2.Random_generation_number(11.5f, 12.0f);

        ball_2_ins = GameObject.Instantiate(ball_2);



        ball_comp_ball_3.which_ball_tag = "Right";
        ball_comp_ball_3.ball_color = Ball_color[2];
        ball_comp_ball_3.Time_handStay = 3.5;
        // ball_comp_ball_3.num_clock = "1.5";




        //ball_comp_ball_3.spawn_ball();
        ball_comp_ball_3.Random_generation_number(0.5f, 1.5f);

        //Todo: ehsan??????????????? where is ball


        //arg two is different from other funtion, becuase it is 1.5
        ball_3_ins = GameObject.Instantiate(ball_3);





        ball_comp_ball_4.which_ball_tag = "Left";
        ball_comp_ball_4.ball_color = Ball_color[3];
        ball_comp_ball_4.Time_handStay = 3.5;
        // ball_comp_ball_4.num_clock = "10.5";




        // ball_comp_ball_4.spawn_ball();




        ball_comp_ball_4.Random_generation_number(10.5f, 11.5f);
        ball_4_ins = GameObject.Instantiate(ball_4);



        ball_comp_ball_5.which_ball_tag = "Right";
        ball_comp_ball_5.ball_color = Ball_color[4];
        ball_comp_ball_5.Time_handStay = 3.5;
        // ball_comp_ball_5.num_clock = "12_L";




        // ball_comp_ball_5.spawn_ball();




        ball_comp_ball_5.Random_generation_number(1.5f, 2.5f);
        ball_5_ins = GameObject.Instantiate(ball_5);




        ball_comp_ball_6.which_ball_tag = "Left";
        ball_comp_ball_6.ball_color = Ball_color[5];
        ball_comp_ball_6.Time_handStay = 3.5;
        //  ball_comp_ball_6.num_clock = "12_R";




        // ball_comp_ball_6.spawn_ball();




        ball_comp_ball_6.Random_generation_number(9.5f, 10.5f);
        ball_6_ins = GameObject.Instantiate(ball_6);






        Next_Scenario = 1;
        pri_Scenario =6;


        reset_anim(new GameObject[] { ball_1_ins, ball_2_ins, ball_3_ins, ball_4_ins, ball_5_ins, ball_6_ins });


        // GameObject.FindGameObjectWithTag("obj").GetComponent<TextMeshProUGUI>().text = "Objective: " + Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list];
        // GameObject.FindGameObjectWithTag("obj").GetComponent<TextMesh>().text = Ball_manager.My_Scenario.ball_list[Ball_manager.My_Scenario.index_ball_list];
        Ball_manager.set_space_objective();
        set_color_objective();


        //  freeze_pos();
        reset_list_color_each_scenerio();

       // set_rigid_body();
    }







    //public void Scenario_test_offset_all()
    //{
    //    numberof_ball = 15;







    //    GameObject ball_1;
    //    GameObject ball_2;
    //    GameObject ball_3;
    //    GameObject ball_4;
    //    GameObject ball_5;
    //    GameObject ball_6;
    //    GameObject ball_7;
    //    GameObject ball_8;
    //    GameObject ball_9;
    //    GameObject ball_10;
    //    GameObject ball_11;
    //    GameObject ball_12;
    //    GameObject ball_13;
    //    GameObject ball_14;
    //    GameObject ball_15;


    //    // //Todo: ehsan ??? aya niaze???
    //    GameObject ball_1_ins;
    //    GameObject ball_2_ins;


    //    Ball ball_comp_ball_1;
    //    Ball ball_comp_ball_2;
    //    Ball ball_comp_ball_3;
    //    Ball ball_comp_ball_4;
    //    Ball ball_comp_ball_5;
    //    Ball ball_comp_ball_6;
    //    Ball ball_comp_ball_7;
    //    Ball ball_comp_ball_8;
    //    Ball ball_comp_ball_9;
    //    Ball ball_comp_ball_10;
    //    Ball ball_comp_ball_11;
    //    Ball ball_comp_ball_12;
    //    Ball ball_comp_ball_13;
    //    Ball ball_comp_ball_14;
    //    Ball ball_comp_ball_15;









    //    ball_1 = Resources.Load<GameObject>("BlueBall"); 
    //    ball_2 = Resources.Load<GameObject>("BlueBall");
    //    ball_3 = Resources.Load<GameObject>("BlueBall");
    //    ball_4 = Resources.Load<GameObject>("BlueBall");
    //    ball_5 = Resources.Load<GameObject>("BlueBall");
    //    ball_6 = Resources.Load<GameObject>("BlueBall");
    //    ball_7 = Resources.Load<GameObject>("BlueBall");
    //    ball_8 = Resources.Load<GameObject>("BlueBall");
    //    ball_9 = Resources.Load<GameObject>("BlueBall");
    //    ball_10 = Resources.Load<GameObject>("BlueBall");
    //    ball_11 = Resources.Load<GameObject>("BlueBall");
    //    ball_12 = Resources.Load<GameObject>("BlueBall");
    //    ball_13 = Resources.Load<GameObject>("BlueBall");
    //    ball_14 = Resources.Load<GameObject>("BlueBall");
    //    ball_15= Resources.Load<GameObject>("BlueBall");

    //    //bball_1all_2 = Instantiate(Resources.Load<GameObject>("Red"), clock);

    //    ball_comp_ball_1 = ball_1.GetComponent<Ball>();
    //    ball_comp_ball_2 = ball_2.GetComponent<Ball>();
    //    ball_comp_ball_3 = ball_3.GetComponent<Ball>();
    //    ball_comp_ball_4 = ball_4.GetComponent<Ball>();
    //    ball_comp_ball_5 = ball_5.GetComponent<Ball>();
    //    ball_comp_ball_6 = ball_6.GetComponent<Ball>();
    //    ball_comp_ball_7 = ball_7.GetComponent<Ball>();
    //    ball_comp_ball_8 = ball_8.GetComponent<Ball>();
    //    ball_comp_ball_9 = ball_9.GetComponent<Ball>();
    //    ball_comp_ball_10 = ball_10.GetComponent<Ball>();
    //    ball_comp_ball_11 = ball_11.GetComponent<Ball>();
    //    ball_comp_ball_12 = ball_12.GetComponent<Ball>();
    //    ball_comp_ball_13 = ball_13.GetComponent<Ball>();
    //    ball_comp_ball_14 = ball_14.GetComponent<Ball>();
    //    ball_comp_ball_15 = ball_15.GetComponent<Ball>();

    //    ball_comp_ball_1.which_ball_tag = "Right";
    //    ball_comp_ball_1.ball_color = "Blue"; //it must be blue *******
    //    ball_comp_ball_1.Time_handStay = 1.5;
    //    ball_comp_ball_1.num_clock = "5";
    //    //ball_comp_ball_1.score();



    //    ball_comp_ball_1.spawn_ball();

    //    //ball_1_ins = Instantiate(ball_1, clock);



    //    ball_1_ins = GameObject.Instantiate(ball_1, Ball_manager.transform_clock_num[Int16.Parse(ball_comp_ball_1.num_clock) + 1]);
    //    //ball_comp_ball_1.spawn_ball();


    //    ball_comp_ball_2.which_ball_tag = "Left";
    //    ball_comp_ball_2.ball_color = "Red";
    //    ball_comp_ball_2.Time_handStay = 1.5;
    //    ball_comp_ball_2.num_clock = "7";
    //    //ball_comp_ball_2.num_clock = "1";
    //    //ball_comp_ball_2.score();

    //    ball_comp_ball_2.spawn_ball();

    //    // ball_2_ins = Instantiate(ball_2, clock);

    //    ball_2_ins = GameObject.Instantiate(ball_2, Ball_manager.transform_clock_num[Int16.Parse(ball_comp_ball_2.num_clock) + 1]);

    //}



    //public void Next_Scenario()
    //{
    //    Ball_manager.My_Scenario = new Scenario();
    //}


    public void set_color_objective()
    {
        TextMesh my_objective = GameObject.FindGameObjectWithTag("obj").GetComponent<TextMesh>();

        switch (Ball_manager.My_Scenario.Ball_color[Ball_manager.My_Scenario.index_ball_list])
        {
            case "Red":
              //  my_objective.color = new Color(255, 0, 0);
                my_objective.color = Color.red;
              //  my_objective.color = new Color(37, 255, 0);

                break;
            case "Blue":
                //  my_objective.color = new Color(0, 85, 255);
                my_objective.color = Color.blue;
              //  my_objective.color = new Color(37, 255, 0);

                break;
            case "Yellow":
                // my_objective.color = new Color(255, 211, 0);
               // my_objective.color = Color.yellow;
             
                my_objective.color = new Color32(236, 195, 0,255);
                break;

            default:
                break;
        }

    }

    public string random_ball_right()

    {
        if (All_color_ball_R.Count == 0)
        {
            All_color_ball_R.Add("Red");
            All_color_ball_R.Add("Yellow");
            All_color_ball_R.Add("Blue");

            
        }


        number_color_ball = UnityEngine.Random.Range(0, All_color_ball_R.Count);

        string my_ball = All_color_ball_R[number_color_ball];
        remove_color_ball_r();

        return my_ball;


    }

    public string random_ball_left()

    {
        if (All_color_ball_L.Count == 0)
        {
            All_color_ball_L.Add("Red");
            All_color_ball_L.Add("Yellow");
            All_color_ball_L.Add("Blue");


        }


        number_color_ball = UnityEngine.Random.Range(0, All_color_ball_L.Count);

        string my_ball = All_color_ball_L[number_color_ball];
        remove_color_ball_l();

        return my_ball;


    }
    //public void set_color_ball(char which_side)
    //{

    //    if (which_side=='R')
    //    {

    //    }
    //    else
    //    {

    //    }
    
    //}

    public void remove_color_ball_r()
    {

        All_color_ball_R.RemoveAt(number_color_ball);
    }
    public void remove_color_ball_l()
    {

        All_color_ball_L.RemoveAt(number_color_ball);
    }

    public  static void freeze_pos()
    {
      // Get All Balls in Scene.
         GameObject[] balls_scene = GameObject.FindGameObjectsWithTag("Balls");

        if (balls_scene!=null)
        {
            //suppose, when user click on ball, click on Start; we must DeActivate Canvas and update Time_handStay of that Ball.
            for (int i = 0; i < balls_scene.Length; i++)
            {
                balls_scene[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

                //balls_scene[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

            }
        }
       

    }

    public void reset_list_color_each_scenerio()
    {
        All_color_ball_R.Clear();

        All_color_ball_R.Add("Red");
        All_color_ball_R.Add("Yellow");
        All_color_ball_R.Add("Blue");


        All_color_ball_L.Clear();

        All_color_ball_L.Add("Red");
        All_color_ball_L.Add("Yellow");
        All_color_ball_L.Add("Blue");

    }

    public static void set_is_kinematic_ball(bool is_kinematic)
    {
        GameObject[] balls_scene = GameObject.FindGameObjectsWithTag("Balls");

        //suppose, when user click on ball, click on Start; we must DeActivate Canvas and update Time_handStay of that Ball.
        for (int i = 0; i < balls_scene.Length; i++)
        {                                                       //true

            balls_scene[i].GetComponent<Rigidbody>().isKinematic = is_kinematic;

            //Debug.Log("Rigigd body ball: " + balls_scene[i].GetComponent<Rigidbody>().isKinematic);
        }

    }

    public void reset_anim(GameObject [] ball_inst)
    {

        list_anim_ball.Clear();

        for (int i = 0; i < ball_inst.Length; i++)
        {
            ball_inst[i].GetComponent<Animator>().enabled = false;
            list_anim_ball.Add(ball_inst[i]);
        }



      //  list_anim_ball.Add(ball_1_ins);

        list_anim_ball[0].GetComponent<Animator>().enabled = true;



     //   list_anim_ball.Add(ball_2_ins);

    //    list_anim_ball[1].GetComponent<Animator>().enabled = false;

    }

}

    //public class Scenario_2
    //{

    //    public byte numberof_ball;


    //    private GameObject ball_1;
    //    private GameObject ball_2;

    //    //Todo: ehsan ??? aya niaze???
    //    public GameObject ball_1_ins;
    //    public GameObject ball_2_ins;


    //    private Ball ball_comp_ball_1;
    //    private Ball ball_comp_ball_2;

    //    //ball_1 = (GameObject)Resources.Load("Red");

    //    public Scenario_2()
    //    {
    //        numberof_ball = 2;


    //        ball_1 = Resources.Load<GameObject>("BlueBall"); // it must be blue ******
    //        ball_2 = Resources.Load<GameObject>("RedBall");

    //        //ball_2 = Instantiate(Resources.Load<GameObject>("Red"), clock);

    //        ball_comp_ball_1 = ball_1.GetComponent<Ball>();
    //        ball_comp_ball_2 = ball_2.GetComponent<Ball>();

    //        ball_comp_ball_1.which_ball_tag = "Right";
    //        ball_comp_ball_1.ball_color = "Blue"; //it must be blue *******
    //        ball_comp_ball_1.Time_handStay = 1.5;
    //        ball_comp_ball_1.num_clock = "5";
    //        //ball_comp_ball_1.score();



    //        ball_comp_ball_1.spawn_ball();

    //        //ball_1_ins = Instantiate(ball_1, clock);



    //        ball_1_ins = GameObject.Instantiate(ball_1, Ball_manager.transform_clock_num[Int16.Parse(ball_comp_ball_1.num_clock) + 1]);
    //        //ball_comp_ball_1.spawn_ball();


    //        ball_comp_ball_2.which_ball_tag = "Left";
    //        ball_comp_ball_2.ball_color = "Red";
    //        ball_comp_ball_2.Time_handStay = 1.5;
    //        ball_comp_ball_2.num_clock = "7";
    //        //ball_comp_ball_2.num_clock = "1";
    //        //ball_comp_ball_2.score();

    //        ball_comp_ball_2.spawn_ball();

    //        // ball_2_ins = Instantiate(ball_2, clock);

    //        ball_2_ins = GameObject.Instantiate(ball_2, Ball_manager.transform_clock_num[Int16.Parse(ball_comp_ball_2.num_clock) + 1]);


    //    }

    //    public void Next_Scenario()
    //    {
    //        Ball_manager.My_Scenario = new Scenario();
    //    }

    //}




