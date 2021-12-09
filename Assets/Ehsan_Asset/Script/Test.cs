//using Boo.Lang.Environments;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Rigidbody my_rb;
   // public int speed;
    // Start is called before the first frame update
    void Start()
    {
         my_rb = GetComponent<Rigidbody>();

        //my_rb = GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position.z = transform.position.z * Time.deltaTime;
        //transform.Translate(0, 0, 1 * Time.deltaTime);
        //transform.position += new Vector3(0,0,1 * Time.deltaTime);

       // Kinect2Interface a = new Kinect2Interface();
       // Debug.Log("number sensor" + a.GetSensorsCount());
    }

    private void FixedUpdate()
    {
        //my_rb.velocity = new Vector3(0,0,1* speed);
       // my_rb.MovePosition(transform.position + (new Vector3(0, 0, 1) * speed * Time.deltaTime));
       
    }
}
