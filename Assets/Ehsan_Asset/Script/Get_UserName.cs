using nuitrack;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Get_UserName : MonoBehaviour
{
    public static string user_name; //in order to access to name in other scripts. for example when righting CSV file.

    public TMP_InputField UI_userName; //input field of getting name from user.

    public GameObject alert_text; //alerts_text, when no data is in input field taken and Enter Button push.

    private GameObject my_kinect; //we don't want kinect track us, Until Data in input field put.

    private GameObject Panel_UI; //a simple panel, TMP_InputField  put on it. after push enter Button, it DeActivate.

    private void Start()
    {
        my_kinect = GameObject.FindGameObjectWithTag("Kinect_manager");

        my_kinect.SetActive(false);


        Panel_UI = GameObject.FindGameObjectWithTag("Panel_UI");

    }


    public void GetName()
    {
        //DontDestroyOnLoad(this.gameObject);

        if (UI_userName.text.Length != 0)
        {
            user_name = UI_userName.text;
            alert_text.SetActive(false);
            SceneManager.LoadScene("Room");
          //  Debug.Log("userName "+ UI_userName.text);
        }
        else 
        {
            alert_text.SetActive(true);
        }
    
    }

    public void GetName2()
    {
        //DontDestroyOnLoad(this.gameObject);
        
        //if data is in input field enters, DeActivate Panel and Active Kinect Tracking.
        if (UI_userName.text.Length != 0)
        {
            user_name = UI_userName.text;
            alert_text.SetActive(false);
            // SceneManager.LoadScene("Room");
            //  Debug.Log("userName "+ UI_userName.text);

            Panel_UI.SetActive(false);

            my_kinect.SetActive(true);

           

        }
        //if no Data enters in input field, Alert Text Activate.
        else
        {
            alert_text.SetActive(true);
        }

    }


}
