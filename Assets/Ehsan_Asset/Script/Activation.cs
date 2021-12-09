using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using UnityEngine;
using BestHTTP;
using System;
using Newtonsoft.Json;
using TMPro;
using UnityEngine.Networking;

public class Activation : MonoBehaviour
{
    public String base_url_Web_API = "https://localhost:44323/";

    private LicenseDB_User my_license;

    private bool response_successfull = false;

    private GameObject Panel_activation;

    public TextMeshProUGUI text_activation;

    private TMP_InputField my_email;

    private string my_mac;
    private string Get_MacAddress()
    {

        string macAddr =
    (
        from nic in NetworkInterface.GetAllNetworkInterfaces()
        where nic.OperationalStatus == OperationalStatus.Up
        select nic.GetPhysicalAddress().ToString()
       
    ).FirstOrDefault();


        return macAddr;

    }

    private void Get_Reqeust(string Web_API)
    {
        HTTPRequest Get_req = new HTTPRequest(new Uri(Web_API), HTTPMethods.Get, Get_request_recv);

       // "api / LicenseDBs"


        Get_req.SetHeader("Content-Type", "application/json");
        Get_req.SetHeader("Accept", "application/json");


        Get_req.Send();

    }

    private void Get_request_recv(HTTPRequest originalRequest, HTTPResponse response)
    {
      

        string my_response;


        switch (originalRequest.State)
        {
            case HTTPRequestStates.Initial:
                Debug.LogWarning("Initial!");
                text_activation.text = "Initial!";
                return;
                break;
            case HTTPRequestStates.Queued:
                Debug.LogWarning("Queued");
                text_activation.text = "Queued!";
                return;
                break;
            case HTTPRequestStates.Processing:
                Debug.LogWarning("Processing");
                text_activation.text = "Processing!";
                return;
                break;
            case HTTPRequestStates.Finished:
                if (response.IsSuccess)
                {

                }

                else
                {
                    Debug.LogWarning(string.Format("Request finished Successfully, but the server sent an error. Status Code: {0}-{1} Message: {2}",
                                               response.StatusCode,
                                               response.Message,
                                               response.DataAsText));
                    if (response.StatusCode == 404)
                    {
                        text_activation.text = "Please Activate The Game";
                    }
                    else
                    {
                        text_activation.text = "server sent an error! " + response.StatusCode;

                    }
                    
                    return;
                }

                break;
            case HTTPRequestStates.Error:
                Debug.LogWarning("Request got error" + originalRequest.Exception.Message + "/" + originalRequest.Exception.StackTrace);
                text_activation.text = "Request got error: " + originalRequest.Exception.Message;
                return;
                break;
            case HTTPRequestStates.Aborted:
                Debug.LogWarning("Request Aborted!");
                text_activation.text = "Request Aborted!";
                return;
                break;
            case HTTPRequestStates.ConnectionTimedOut:
                Debug.LogWarning("Connection Timed Out!");
                text_activation.text = "Connection Timed Out!";
                return;
                break;
            case HTTPRequestStates.TimedOut:
                Debug.LogWarning("Processing the request Timed Out!");
                text_activation.text = "Processing the request Timed Out!";
                return;
                break;

            default:
                Debug.LogWarning("in default state");
                break;
        }


        //error handling because of Free Web API, for Post method
        //if (response.Message != "Created")
        //{
        //    return;
        //}

        Debug.Log("Get Request Finished! response message " + response.Message);
        Debug.Log("Get Request Finished! status code " + response.StatusCode);
        Debug.Log("Get Request Finished! body " + response.DataAsText);


        if (response.StatusCode==404)
        {
            response_successfull = false;
            return;
        }
        else
        {
            //try
            //{
           


                my_response = response.DataAsText;

            if (my_response.Length < 5)
            {
                return;
            }

            Debug.Log("Response " + my_response);

              //  my_response = my_response.Substring(20);

                //Debug.Log("Response " + my_response);


               // my_response = my_response.Remove(my_response.Length - 1);
                //   Debug.Log("my response: " + my_response);



                my_license = JsonConvert.DeserializeObject<LicenseDB_User>(my_response);

                Debug.Log(my_license.MacAdd + "/" + my_license.Email + "/" + my_license.is_activated + "/");

                response_successfull = true;



            Check_Activation_boolean();

        }

       
     


    }

    private void Upload_MacAddress(string Web_API,string Email)
    {
        // my_send_button.interactable = false;

        HTTPRequest Post_req = new HTTPRequest(new Uri(Web_API), HTTPMethods.Post, Post_request_recv);


        Post_req.AddField("MacAdd", my_mac);
        Post_req.AddField("Email", Email);

        Post_req.AddField("is_activated", "true"); //in next update of game with UI, this field must be updated at server

        // Post_req.AddField("MacAdd", "12345");
        //  Post_req.AddField("Email", "ehsan.akhlaghy@gmail.com");


        //Post_req.FormUsage = BestHTTP.Forms.HTTPFormUsage.UrlEncoded;



        Debug.Log("Get Mac address:"+ my_mac);

       // Post_req.SetHeader("Authorization", "Bearer ddce057c39d0941d0431d815a608d1a5347a60f1fda14d9c7d7eaa8aa301f65f");
       // Post_req.SetHeader("Content-Type", "application/json");
        Post_req.SetHeader("Content-Type", "multipart/form-data");

        Post_req.SetHeader("Accept", "application/json");
        //Post_req.SetHeader("charset", "utf-8");

       
       // Debug.Log("before send upload http");
        Post_req.Send();
        // Debug.Log("after send upload http");



        
    }

    private void Post_request_recv(HTTPRequest originalRequest, HTTPResponse response)
    {

        string my_response;


        switch (originalRequest.State)
        {
            case HTTPRequestStates.Initial:
                Debug.LogWarning("Initial!");
                text_activation.text = "Initial!";
                return;
                break;
            case HTTPRequestStates.Queued:
                Debug.LogWarning("Queued");
                text_activation.text = "Queued!";
                return;
                break;
            case HTTPRequestStates.Processing:
                Debug.LogWarning("Processing");
                text_activation.text = "Processing!";
                return;
                break;
            case HTTPRequestStates.Finished:
                if (response.IsSuccess)
                {

                }

                else
                {
                    Debug.LogWarning(string.Format("Request finished Successfully, but the server sent an error. Status Code: {0}-{1} Message: {2}",
                                               response.StatusCode,
                                               response.Message,
                                               response.DataAsText));
                    text_activation.text = "server sent an error! " + response.StatusCode;
                    return;
                }
                
                break;
            case HTTPRequestStates.Error:
                Debug.LogWarning("Request got error" + originalRequest.Exception.Message + "/" + originalRequest.Exception.StackTrace);
                text_activation.text = "Request got error: " + originalRequest.Exception.Message;
                return;
                break;
            case HTTPRequestStates.Aborted:
                Debug.LogWarning("Request Aborted!");
                text_activation.text = "Request Aborted!";
                return;
                break;
            case HTTPRequestStates.ConnectionTimedOut:
                Debug.LogWarning("Connection Timed Out!");
                text_activation.text = "Connection Timed Out!";
                return;
                break;
            case HTTPRequestStates.TimedOut:
                Debug.LogWarning("Processing the request Timed Out!");
                text_activation.text = "Processing the request Timed Out!";
                return;
                break;

            default:
                Debug.LogWarning("in default state");
                break;
        }


        //error handling because of Free Web API, for Post method
        //if (response.Message != "Created")
        //{
        //    return;
        //}

        //  Debug.Log("Get Request Finished! status code " + response.StatusCode);

        //if (response.StatusCode == 404)
        //{
        //    response_successfull = false;
        //    return;
        //}
        //else
        //{
            my_response = response.DataAsText;
        Debug.Log("response Post: "+ my_response);

            //my_response = my_response.Substring(20);

            //my_response = my_response.Remove(my_response.Length - 1);
            //   Debug.Log("my response: " + my_response);



            my_license = JsonConvert.DeserializeObject<LicenseDB_User>(my_response);

            Debug.Log(my_license.MacAdd + "/" + my_license.Email + "/" + my_license.is_activated + "/");


        Check_Activation_boolean();

        // }

    }

    private bool Check_Activation()
    {

        Get_Reqeust("https://localhost:44323/api/LicenseDBs/" + my_mac);


        if (response_successfull)
        {
            if (my_license.is_activated)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            //no record for this mac address in DB
            return false;
        }

        //  return true;
    }


    private void Check_Activation_boolean()
    {
        if (my_license!=null)
        {
            if (my_license.is_activated)
            {
                Panel_activation.SetActive(false);
            }
           
        }
    
    }
    
    //private string GetMacAddress_2()
    //{
    //    const int MIN_MAC_ADDR_LENGTH = 12;
    //    string macAddress = string.Empty;
    //    long maxSpeed = -1;

    //    foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
    //    {
    //        Debug.Log(
    //            "Found MAC Address: " + nic.GetPhysicalAddress() +
    //            " Type: " + nic.NetworkInterfaceType);

    //        string tempMac = nic.GetPhysicalAddress().ToString();
    //        if (nic.Speed > maxSpeed &&
    //            !string.IsNullOrEmpty(tempMac) &&
    //            tempMac.Length >= MIN_MAC_ADDR_LENGTH)
    //        {
    //            Debug.Log("New Max Speed = " + nic.Speed + ", MAC: " + tempMac);
    //            maxSpeed = nic.Speed;
    //            macAddress = tempMac;
    //        }
    //    }

    //    return macAddress;
    //}

    private bool Valid_Email()
    {
         my_email = Panel_activation.GetComponentInChildren<TMP_InputField>();
        
        //switch (my_email.text)
        //{
        //    case "null":
        //            break;
        //    case my_email.text.:


        //    default:
        //}

        try
        {
            System.Net.Mail.MailAddress my_email_ = new System.Net.Mail.MailAddress(my_email.text);

            return my_email_.Address == my_email.text;

            
        }
        catch
        {

            return false;
        }
        


    }

    public void Check_Email()
    {

        if (Valid_Email())
        {
            text_activation.text = "Activating...";
            Debug.Log("email addre:"+ my_email.text);

            Upload_MacAddress(base_url_Web_API + "api/LicenseDBs/", my_email.text);
            

            //"https://localhost:44323/"
        }
        else
        {
            text_activation.text = "Please enter valid email Address";
        }
    }



    
    //private void Update()
    //{
    //    Debug.Log("Mac Address:" + Get_MacAddress());

    //   // Debug.Log("Mac Address:" + GetMacAddress_2());

    //}

    private void Start()
    {
        HTTPManager.KeepAliveDefaultValue = false;

        my_mac = Get_MacAddress();
        Debug.Log("My mac:" + my_mac);

        Panel_activation = GameObject.FindGameObjectWithTag("Activation_panel");
        Panel_activation.SetActive(false);

      //  Debug.Log(Panel_activation);

        if (!Check_Activation())
        {
            Panel_activation.SetActive(true);
        }


       
    }
}