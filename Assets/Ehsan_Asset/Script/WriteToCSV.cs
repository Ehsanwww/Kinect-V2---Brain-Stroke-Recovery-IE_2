using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class WriteToCSV : MonoBehaviour
{
    private static string FilePath = "Reports/Report"; //Folder of CSV file 
    //*** get Time in order to write name of file.
    private DateTime time_start;  
    private TimeSpan saat;

    private uint hour;
    private uint min;
    private uint sec;
    //***
    void Start()
    {
        time_start  = DateTime.Now;
        saat = time_start.TimeOfDay;

        //hour = Math.Round(saat.TotalHours);
        //min = Math.Round(saat.TotalMinutes);
        //sec = Math.Round(saat.TotalSeconds);


        hour = (uint)saat.Hours;
        min = (uint)saat.Minutes;
        sec = (uint)saat.Seconds;

        Directory.CreateDirectory("Reports"); //Create Directory of Reports in root of Build.

        FilePath += "- " + time_start.Date.ToString("MM_dd_yyyy ") +"- " + hour + "_" + min
                                                                    + "_"+ sec + ".txt";
        //***
        write_header(); //header of CSV file

      //  write_record("3", "2", "3", "4", "5", "6", "7");
    }

  
   // public static void write_record(string ID,string shoulder_R,string elbow_R,string wrist_R,
                                 //   string shoulder_L, string elbow_L, string wrist_L)
    //method of write Record of CSV file.
    public static void write_record(string name ,string shoulder, string elbow, string wrist,
                                    string Which_hand, string State, string Time,string Time_takes_to_Grab, string Delta_Time,
                                    string level,
                                    string ball_number,
                                    string score) 
    {
        
        using (StreamWriter file = new StreamWriter(@FilePath,true))
        {
            //  file.WriteLine(ID + "," + shoulder_R + "," + elbow_R + "," + wrist_R + "," + shoulder_L + "," + elbow_L + "," + wrist_L 
            //            );

            if (level == "0") //we dont have current Scenario in each ball and just next and privious Scenario, next 
                              //Scenario level 7 is 1 which when want to find what is current scenario must minus from one
                              // and it will be 0 which is not good. so we fix it here.
            {
                level = "7";
            }

            file.WriteLine(name + "," +shoulder + "," + elbow+ "," + wrist + "," + Which_hand + "," + State + "," + Time +
                          "," + Time_takes_to_Grab + "," + Delta_Time + "," + level + "," + ball_number + "," + score);

        }
        
    }

    //method of write  header CSV file.
    public void write_header()
    {
        using (StreamWriter file = new StreamWriter(@FilePath, true))
        {
            //  file.WriteLine("ID" + "," + "shoulder_R" + "," + "elbow_R" + "," + "wrist_R" + "," + "shoulder_L" + "," +
            //  "elbow_L" + "," + "wrist_L");


            //file.WriteLine("ID" + "," + "Shoulder" + "," + "Elbow" + "," + "Wrist" + "," + "Which_hand" + "," +
            //  "State" + "," + "Time(second)");

            ////***
            //file.WriteLine("Ehsan Akhlaghi");

            file.WriteLine("Name" + "," + "Shoulder" + "," + "Elbow" + "," + "Wrist" + "," + "Which_hand" + "," +
              "State" + "," + "Time_create_record" + "," + "Time_grab - Time_start_objective (sec)" + "," + "Time_put - Time_pickup(sec)"
              + "," + "Level" + "," + "Ball_number" + "," + "Score");

        }

    }

}
