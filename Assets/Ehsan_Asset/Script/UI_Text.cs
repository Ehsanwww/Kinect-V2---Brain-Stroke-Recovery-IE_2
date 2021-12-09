using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Runtime.InteropServices;
using System.Transactions;

public class UI_Text : MonoBehaviour
{ 
    //** UI Element of Angles, for exmaple: Shoulder Left, Elbow Left Labels, in order to Refresh this value at runtime, we need this. 
    public TextMeshProUGUI score; //maybe dont need this.

    public TextMeshProUGUI shoulder_l;
    public TextMeshProUGUI elbow_l;
    public TextMeshProUGUI wrist_l;

    public TextMeshProUGUI shoulder_r;
    public TextMeshProUGUI elbow_r;
    public TextMeshProUGUI wrist_r;

    //**

    //*** in order to know what is Angle of Shoulder,Elbow and Wrist, we need Transform of them.
    public Transform shoulder_right;
    public Transform Elbow_right;
    public Transform Wrist_right;


    public Transform shoulder_left;
    public Transform Elbow_left;
    public Transform Wrist_left;
    //***

    public static double shoulder_right_deg; //used to Round to 1 precision. 
    public static double shoulder_right_deg_current; //used for Storing value of euler angle which has more than 5 precision. 


    public static double Elbow_right_deg;
    public static double Wrist_right_deg;

    public static double shoulder_left_deg;
   // public static double shoulder_left_deg_priv;
    private double shoulder_left_deg_current ;

    public static double Elbow_left_deg;
    public static double Wrist_left_deg;

    // private float my_ang = -60;

    public static KinectManager my_kienct_mange; //used for knowing if someone tracked or not.
    private bool count_not_track; //used for set UI lable of angle to "--", if no one is tracked. this variable use for performace issue.


    ////because scale  of 3d Avatar changed in order that hands could grab Ball and put into Basket, hands by Default place 
    ///in clock 3 and 9, which accidentally detect Collision, we don't want this, so we must set detect coliision to false.
    private Rigidbody right_hand; 
    private Rigidbody left_hand;
  

    private bool exit_trigger_s_l;
    private bool exit_trigger_s_r;

    // Start is called before the first frame update
    void Start()
    {
        right_hand  = GameObject.FindGameObjectWithTag("Right").GetComponent<Rigidbody>(); //get component of Rigidbody of Right hand.
        left_hand = GameObject.FindGameObjectWithTag("Left").GetComponent<Rigidbody>();

        //score.text = score.text.Insert(6, (4+2).ToString());
        //score.text = score.text.Replace(" ", "6");

        //score.text = score.text.Insert(6, (8).ToString());
        //score.text = "Gholi!!!";
        //score.text = "Score:" + "4";

        //my_ang %= 360; 
        //Debug.Log(my_ang);

        my_kienct_mange = GameObject.FindGameObjectWithTag("Kinect_manager").GetComponent<KinectManager>(); //used for detecting if 
                                                                                                            //if someone is tracked or not.

        count_not_track = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!my_kienct_mange.IsUserTracked(my_kienct_mange.GetPrimaryUserID())) //when user is not front of kinect ,don't update UI
        {

            //Debug.Log(WrapAngle(370));
            //  Debug.Log("Shoulder right global euler angle without wrap");
            // Debug.Log("shoulder right " + shoulder_right.eulerAngles);
            // Debug.Log("x wrap: " + WrapAngle(shoulder_right.eulerAngles.x) + " y: " + WrapAngle(shoulder_right.eulerAngles.y)
            //   + " z: " + WrapAngle(shoulder_right.eulerAngles.z));

            ///*** Debug for angle Shoulder ****
            //Debug.Log("Global Quternion: " + shoulder_right.rotation);
            //Debug.Log("Local Quternion: " + shoulder_right.localRotation);
            //Debug.Log("Local euler: " + shoulder_right.localEulerAngles);
            //Debug.Log("global euler: " + shoulder_right.eulerAngles);
            //Debug.Log("from quternion to local euler: " + shoulder_right.transform.localEulerAngles);


           

           // Debug.Log("vector3.angle" + Vector3.Angle();

            if (!count_not_track) //if no one is in front of Kinect, just one time set UI element of angle to --.
            {
                //shoulder_l.text = "Shoulder_l deg:--";
                //elbow_l.text = "Elbow_l deg:--";
                //wrist_l.text = "Wrist_l deg:--";

                //shoulder_r.text = "Shoulder_r deg:--";
                //elbow_r.text = "Elbow_r deg:";
                //wrist_r.text = "Wrist_r deg:--";



                shoulder_l.text = "--";
                elbow_l.text = "--";
                wrist_l.text = "--";

                shoulder_r.text = "--";
                elbow_r.text = "--";
                wrist_r.text = "--";

                count_not_track = true;

            }
           

            right_hand.detectCollisions = false;
            left_hand.detectCollisions = false;
           // right_hand.enabled = false;
          //  left_hand.enabled = false;

            //right_hand.SetActive(false);
            //left_hand.SetActive(false);

            return;
        }


        right_hand.detectCollisions = true; //if someone is in front of kinect and tracked, make true detectCollision.
        left_hand.detectCollisions = true;

        // right_hand.enabled = true;
        //   left_hand.enabled = true;

        //right_hand.SetActive(true);
        //left_hand.SetActive(true);

        // shoulder_left_deg = Math.Round(WrapAngle(shoulder_left.localEulerAngles.x) + 90.0f, 1); //this is correct


        // shoulder_left_deg = Math.Round(WrapAngle(shoulder_left.localEulerAngles.x) + 60.0f, 1); //this is correct

        // double shoulder_left_deg_2 = Math.Round(WrapAngle(shoulder_left.localEulerAngles.x), 1);

        // double shoulder_left_deg_3 = Math.Round(shoulder_left.localEulerAngles.x); //for Debug


      //  shoulder_left_deg_priv = shoulder_left_deg_current;



        // shoulder_left_deg_current = Math.Round(shoulder_left.eulerAngles.x, 0);

        //shoulder_left_deg_current = Math.Round(shoulder_left.eulerAngles.x, 1);

        //shoulder_left_deg = Math.Round(360 - shoulder_left_deg_current, 1);


        //shoulder_l.text = "Shoulder_l deg: " + shoulder_left_deg + " current: " + shoulder_left_deg_current
        //  + " privious: " + shoulder_left_deg_priv;

        if (exit_trigger_s_l) //if left hand exit from collider area, this variable set to true and other formula for compute shoulder 
                              //angle  used.
        {
            shoulder_left_deg_current = Math.Round(shoulder_left.eulerAngles.x, 1);
            shoulder_left_deg = Math.Round(shoulder_left_deg_current - 180, 1);
            //  Debug.Log("inside collision UI_text " + "Shoulder left: " + shoulder_left_deg);

            //shoulder_l.text = "Shoulder_l deg: " + shoulder_left_deg;

            shoulder_l.text = shoulder_left_deg.ToString();

            //+ " current: " + shoulder_left_deg_current
            // + " privious: " + shoulder_left_deg_priv;
        }


        if (exit_trigger_s_r) //same as above, but for right hand.
        {
            shoulder_right_deg_current = Math.Round(shoulder_right.eulerAngles.x, 1);
          //  shoulder_right_deg = Math.Round(shoulder_right_deg_current - 180, 1);
            shoulder_right_deg = Math.Round(180 - shoulder_right_deg_current , 1);

            //  Debug.Log("inside collision UI_text " + "Shoulder left: " + shoulder_left_deg);

           // shoulder_r.text = "Shoulder_r deg: " + shoulder_right_deg;

            shoulder_r.text =  shoulder_right_deg.ToString();

            //+ " current: " + shoulder_right_deg_current;


        }
        //***************
        //double diff_shoulder_left = shoulder_left_deg_current - shoulder_left_deg_priv;

        ////threshold 2 not detected
        //if (diff_shoulder_left <0.05)
        //{
        //    shoulder_left_deg = 360 - shoulder_left_deg_current;

        //}
        //else if (diff_shoulder_left>0.05)
        //{
        //    shoulder_left_deg = shoulder_left_deg_current - 180;
        //}



        //shoulder_l.text = "Shoulder_l deg: "+ shoulder_left_deg + " current: " + shoulder_left_deg_current
        //    + " privious: " + shoulder_left_deg_priv + "diff: " + diff_shoulder_left;

        //***************

        // shoulder_l.text = "Shoulder_l deg: " + shoulder_left_deg + " " + shoulder_left_deg_2 + " " + shoulder_left_deg_3;




        // Elbow_left_deg = 180.0f - Math.Round(WrapAngle(Elbow_left.eulerAngles.z), 1);

        Elbow_left_deg = Math.Round(180.0f - WrapAngle(Elbow_left.localEulerAngles.z) + 10.0f, 1); //compute angle of Elbow left,
                                                                                                       //want just one precision.
        // Elbow_left_deg = Math.Round(Elbow_left.localEulerAngles.z), 1);
     // float b =  my_kienct_mange.GetAngleAtJoint(my_kienct_mange.GetPrimaryUserID(), 5);
        //second approach to measure degree elbow
       // Vector3 elbow_shoulder_l = shoulder_left.position - Elbow_left.position;
        //  Vector3 elbow_wrist_l =Wrist_left.position - Elbow_left.position;
        
        // double AB = elbow_shoulder_l.x * elbow_wrist_l.x + elbow_shoulder_l.y * elbow_wrist_l.y + elbow_shoulder_l.z * elbow_wrist_l.z;
        // double A_B = elbow_shoulder_l.magnitude * elbow_wrist_l.magnitude;
        //double  Elbow_left_deg_2 = Math.Acos(AB / A_B);

        // Elbow_left_deg_2 = Math.Round(Elbow_left_deg_2 * ( 180/Math.PI ),1);

        // double Elbow_left_deg_2 = Vector3.Angle(elbow_shoulder_l, elbow_wrist_l);

       // elbow_l.text = "Elbow_l deg:" + Elbow_left_deg + " "; //update UI of Elbow.


        elbow_l.text =  Elbow_left_deg.ToString(); //update UI of Elbow.


        //+ " "+ Elbow_left_deg_2;



        //+ " " + Elbow_left_deg_2;
        //wrist_l.text = "Wrist_r deg:" +;


        //Wrist_left_deg = Math.Round( Wrist_left.localEulerAngles.z,1);
        //Wrist_left_deg = Wrist_left.localEulerAngles.x;


        // wrist_l.text = "Wrist_l deg:" + Wrist_left_deg;



        //*****???? have problem ??????????/



        // shoulder_right_deg = Math.Round(WrapAngle(shoulder_right.localEulerAngles.x) + 90.0f, 1); //neshte -70<Dar halet khabar_dar vs azjelo<70

        //  shoulder_right_deg = Math.Round(WrapAngle(shoulder_right.localEulerAngles.x) + 60.0f, 1); //neshte -70<Dar halet khabar_dar vs azjelo<70


        // double shoulder_right_deg_2 = Math.Round(WrapAngle(shoulder_right.localEulerAngles.x), 1);
        //double shoulder_right_deg_3 = Math.Round(shoulder_right.localEulerAngles.x);


        //shoulder_right_deg = Math.Round(WrapAngle(shoulder_right.localEulerAngles.x) + 90.0f, 1); //halat istade

        // shoulder_right_deg = Math.Round(WrapAngle(shoulder_right.localEulerAngles.x) + 90.0f, 1); //Jadid


        // Debug.Log("shoulder right_angle:" + shoulder_right.localEulerAngles.x);


        //shoulder_r.text = "Shoulder_r deg: " + shoulder_right_deg ;



        //  shoulder_r.text = "Shoulder_r deg: " + shoulder_right_deg + " " + shoulder_right_deg_2 + " " + shoulder_right_deg_3;

        //Debug.Log("x: " + WrapAngle(shoulder_right.eulerAngles.x) +" y: " + WrapAngle(shoulder_right.eulerAngles.y)
        //    +" z: " + WrapAngle(shoulder_right.eulerAngles.z));

        //Debug.Log("x: " + shoulder_right.eulerAngles.x + " y: " + shoulder_right.eulerAngles.y
        //    + " z: " + shoulder_right.eulerAngles.z);


        //Debug.Log(" y: " + WrapAngle(shoulder_right.eulerAngles.y));
        // Debug.Log(" z: " + WrapAngle(shoulder_right.eulerAngles.z));

        //if (shoulder_right.eulerAngles == UnityEditor.TransformUtils.GetInspectorRotation(shoulder_right.transform))
        //{
        //    Debug.Log("Equal");

        //}

        //  Debug.Log("euler" + shoulder_right.eulerAngles);
        // Debug.Log("local euler" + shoulder_right.localEulerAngles);
        // Debug.Log("local euler wrap" + WrapAngle(shoulder_right.localEulerAngles.x)+"-" + WrapAngle(shoulder_right.localEulerAngles.y)
        //    +"-" + WrapAngle(shoulder_right.localEulerAngles.z));
        // Debug.Log("UnityEdiyot" + UnityEditor.TransformUtils.GetInspectorRotation(shoulder_right.transform));
        // Debug.Log("transform"+ shoulder_right.transform.eulerAngles);

        //Debug.Log(UnityEditor.TransformUtils.GetInspectorRotation(shoulder_right.transform));

        //if (88.0f <= shoulder_right_deg && shoulder_right_deg <= 94.0f)
        //{
        //    Debug.Log(UnityEditor.TransformUtils.GetInspectorRotation(shoulder_right.transform));
        //}
        ////zamani ke kolan dast agelo nezam hast, zavie 164.5 tashkhish dade mishe
        //else if (160.0f <= shoulder_right_deg && shoulder_right_deg <= 182.0f)
        //{

        //}




        //Debug.Log("shoulder degree"+ Math.Round(shoulder_right.localRotation.x, 1) + 90.0f);
        // Debug.Log("euler ang1: " + shoulder_right.localRotation.eulerAngles.x);
        //Debug.Log("euler ang2: " + shoulder_right.localEulerAngles.x);
        //Debug.Log("angle " + shoulder_right.localRotation.x);
        //Debug.Log("angle4 " + shoulder_right.localRotation.x);

        //Debug.Log("angle " +WrapAngle (shoulder_right.localEulerAngles.x));


        // Debug.Log(Math.Round(shoulder_right.localRotation.x,1));
        // Debug.Log(Math.Round(shoulder_right.localRotation.x + 90.0f, 1));

        // Debug.Log(shoulder_right.localRotation.eulerAngles);


        //******************
        //Debug.Log("shulrder angle: "+shoulder_right.eulerAngles.x);
        //Debug.Log("Wrap angle: " + WrapAngle(shoulder_right.eulerAngles.x));


        Elbow_right_deg = Math.Round(180.0f - WrapAngle(Elbow_right.localEulerAngles.z) + 10.0f, 1); //same as above but for Right Elbow.
       // Elbow_right_deg = Math.Round(Elbow_right.localEulerAngles.z, 1);

        // Debug.Log("Elbow_right.localRotation.z" + Elbow_right.localRotation.z);
        // Debug.Log("Elbow_right_deg " + Elbow_right_deg);


       // elbow_r.text = "Elbow_r deg: " + Elbow_right_deg; //same as above


        elbow_r.text =  Elbow_right_deg.ToString(); //same as above




        // wrist_r.text = "Wrist_l deg:" +;


        //Todo: ehsan compute degree based on Vector 
        //Vector3 shoulder_elbow = new Vector3(shoulder_right.transform.position.x - Elbow_right.transform.position.x,
        //                                    shoulder_right.transform.position.y - Elbow_right.transform.position.y,
        //                                    0);
        //Vector3 elbow_Wrist = new Vector3(Elbow_right.transform.position.x - Wrist_right.transform.position.x,
        //                                     Elbow_right.transform.position.y - -Wrist_right.transform.position.y,
        //                                    0);
        //shoulder_elbow.Normalize();
        //elbow_Wrist.Normalize();



        //Vector3 crossProduct = Vector3.Cross(shoulder_elbow, elbow_Wrist);

        //double crossProductLength = crossProduct.z;

        //double dotProduct = Vector3.Dot(shoulder_elbow, elbow_Wrist);

        //double segmentAngle = Math.Atan2(crossProductLength, dotProduct);

        //double degrees = segmentAngle * (180 / Math.PI);

        //Debug.Log("Elbow angle:" + degrees);

        //double S_E_R = (shoulder_elbow.x * elbow_Wrist.x) + (shoulder_elbow.y * elbow_Wrist.y) + (shoulder_elbow.z * elbow_Wrist.z);

        //S_E_R = S_E_R / (shoulder_elbow.magnitude * elbow_Wrist.magnitude);

        //S_E_R = Math.Acos(S_E_R) * (180 / Math.PI);

        //  Debug.Log("Elbow angle:" + S_E_R);





        //Debug.Log("Square magnitute: "+new Vector2(3,4).magnitude);

        ////** important debug for zavie elbow

        ////zamani ke  dast 90 darage hast , zavie 93.5 tashkhish dade mishe
        //if (88.0f<=Elbow_right_deg && Elbow_right_deg <= 94.0f)
        //{

        //}
        ////zamani ke kolan dast agelo nezam hast, zavie 164.5 tashkhish dade mishe
        //else if (160.0f <= Elbow_right_deg && Elbow_right_deg <= 182.0f)
        //{

        //}

        count_not_track = false;

    }


    //private void LateUpdate()
    //{
    //    //   shoulder_left_deg_current = Math.Round(shoulder_left.eulerAngles.x, 1);

    //    //  double diff_shoulder_left = Math.Round(shoulder_left_deg_current - shoulder_left_deg_priv,1);

    //    //threshold 2 not detected
    //    //  if (diff_shoulder_left < 0.5)
    //    //  {
    //    //    shoulder_left_deg = Math.Round(360 - shoulder_left_deg_current,1);

    //    //  }
    //    //else if (diff_shoulder_left >= 0.5)
    //    //{
    //    //    shoulder_left_deg = Math.Round(shoulder_left_deg_current - 180,1);
    //    //}



    //    //  shoulder_l.text = "Shoulder_l deg: " + shoulder_left_deg + " current: " + shoulder_left_deg_current
    //    //   + " privious: " + shoulder_left_deg_priv;
    //    //+ "diff: " + diff_shoulder_left;


    // //   shoulder_l.text = "Shoulder_l deg: " + shoulder_left_deg + " current: " + shoulder_left_deg_current
    // //+ " privious: " + shoulder_left_deg_priv;

    //}
    private static float WrapAngle(float angle) //in order to see angle like in unity Inspector, we had to use this method.
    {
        angle %= 360;
        if (angle > 180)
            return angle - 360;

        return angle;
    }

    //private void OnCollisionStay(Collision collision)
    //{
       
    //      shoulder_left_deg = Math.Round(shoulder_left_deg_current - 180,1);
    //    Debug.Log("inside collision UI_text " + "Shoulder left: " + shoulder_left_deg);
    //    //shoulder_l.text = "Shoulder_l deg: " + shoulder_left_deg + " current: " + shoulder_left_deg_current
    //    // + " privious: " + shoulder_left_deg_priv;
    //}
    //private void OnCollisionExit(Collision collision)
    //{
    //    Debug.Log("Collision exit UI_text ");
    //}

    private void OnTriggerStay(Collider other) //we have two Formula for computing angle of Shoulders, one for bellow of 3 and 9 clock and other for
                                               //above them, in order to detect when it is in bellow  3 and 9, we use Trigger.
    {
        if (other.gameObject.tag == "Left") // if Left hand Collide with this area
        {
            exit_trigger_s_l = false; //Left hand doesn't exit from Collider area, so this variable must set to false.

            //shoulder_left_deg_current = Math.Round(shoulder_left.eulerAngles.x, 1);

            //shoulder_left_deg = Math.Round(360 - shoulder_left_deg_current, 1);


            shoulder_left_deg = Math.Round(WrapAngle(shoulder_left.localEulerAngles.x) + 90.0f, 1); //get value of euler angle x and increase
                                                                                                    //it with 90.0f in order to be in range of 
                                                                                                    //0 and 180.

           // shoulder_l.text = "Shoulder_l deg: " + shoulder_left_deg; //update  UI label with new degree

            shoulder_l.text = shoulder_left_deg.ToString(); //update  UI label with new degree



            //+ " current: " + shoulder_left_deg_current
            //  + " privious: " + shoulder_left_deg_priv;

            //  Debug.Log("inside On trigger staty, collide with " + other.gameObject);




        }

        if (other.gameObject.tag == "Right") //same as above but for Right hand
        {
            exit_trigger_s_r = false;

            //shoulder_right_deg_current = Math.Round(shoulder_right.eulerAngles.x, 1);

            //shoulder_right_deg = Math.Round(shoulder_right_deg_current,1);

            shoulder_right_deg = Math.Round(WrapAngle(shoulder_right.localEulerAngles.x) + 90.0f, 1);

            

            //shoulder_r.text = "Shoulder_r deg: " + shoulder_right_deg ;

            shoulder_r.text =  shoulder_right_deg.ToString();



            // shoulder_r.text = "Shoulder_r deg: " + shoulder_right_deg_current + " current: " + shoulder_right_deg_current;

            //  Debug.Log("inside On trigger staty, collide with " + other.gameObject);

        }
        //shoulder_left_deg = Math.Round(shoulder_left_deg_current - 180, 1);
        //Debug.Log("inside collision UI_text " + "Shoulder left: " + shoulder_left_deg);

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Left") //if Left hand exit from Collider area, set exit_trigger_s_l variable to true.
        {
            exit_trigger_s_l = true;
          //  Debug.Log("inside On trigger Exit, collide with" + other.gameObject);
        }

        if (other.gameObject.tag == "Right") //same as above
        {
            exit_trigger_s_r = true;
          //  Debug.Log("inside On trigger Exit, collide with" + other.gameObject);
        }

            //Debug.Log("Collision exit UI_text ");




        }


    //private void OnMouseDrag()
    //{
    //    this.GetComponent<Collider>().enabled = false;

    //    this.GetComponent<Rigidbody>().detectCollisions = false;


    //    Debug.Log("inside Drag UI_Text!");


    //    //RaycastHit hit;
    //    //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //    //if (Physics.Raycast(ray, out hit, 100.0f, 9))
    //    //{

    //    //    //  Debug.Log("hit: " + hit.transform.gameObject);
    //    //    if (hit.transform.tag == "Balls")
    //    //    {
    //    //        Debug.Log("hit: " + hit.transform.gameObject);

    //    //    }


    //    //}
    //}

    //private void OnMouseUp()
    //{
    //    this.GetComponent<Collider>().enabled = true;

    //    this.GetComponent<Collider>().enabled = true;

    //    //   this.GetComponent<Rigidbody>().detectCollisions = true;

    //    Debug.Log("inside Mouse UP UI_Text!");

    //}
}
