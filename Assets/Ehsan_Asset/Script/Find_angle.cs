using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Find_angle : MonoBehaviour
{
   public  Transform shoulder_right;
   public  Transform Elbow_right;


    public  Transform shoulder_left;
    public  Transform Elbow_left;


     // public Transform pelvis; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Vector3.Angle(pelvis.position, shoulder_right.position));
        Debug.Log("shoulder_right angle with body:"+ shoulder_right.localRotation.x);
        Debug.Log("shoulder_right angle with body:" + shoulder_left.localRotation.x);

        Debug.Log("Elbow_right angle with body:" + Elbow_right.rotation.z + 180.0f); //??????
        Debug.Log("Elbow_right angle with body:" + Elbow_left.rotation.z + 180.0f); //??????
    }
}
