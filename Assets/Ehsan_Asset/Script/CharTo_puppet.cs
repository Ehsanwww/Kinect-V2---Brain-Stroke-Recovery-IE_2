using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharTo_puppet : MonoBehaviour
{
    //** get left and right hand of 3d avatar(not hands of puppet!!)
    private Transform left_3dchar;
    private Transform right_3dchar;
    //**

    public static float z_offset_puppet ; // offset of z value that must increase to z of positon puppet.
    private void Start()
    {
        left_3dchar = GameObject.FindGameObjectWithTag("LeftHand_3dChar").GetComponent<Transform>();
        right_3dchar = GameObject.FindGameObjectWithTag("RightHand_3dChar").GetComponent<Transform>();


    }


    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Right_puppet") //this scirpt assigned to puppets, which is left and right puppet,
                                              //if this is Right, 
        {
            //this.transform.position = new Vector3 (right_3dchar.position.x, right_3dchar.position.y,0);
            //this.transform.position += new Vector3(0,0,2.9f);

            //this.transform.rotation = right_3dchar.rotation;



            // this.transform.rotation += new Quaternion(0,90,0,0);
            //this.transform.Rotate(new Vector3(0,90,0));

            this.transform.position = right_3dchar.position; //set position of Right puppet to position of Right hand of 3d avatar.
            this.transform.rotation = right_3dchar.localRotation; //set rotation of Right puppet to rotation of Right hand of 3d avatar.

            //this.transform.position += new Vector3(0, 0, 2.0f);
            this.transform.position += new Vector3(0, 0, z_offset_puppet ); //in order that hands can be near ball and grab them,
                                                                            //increase z offset.


        }
        else if (gameObject.tag == "Left_puppet")
        {
            this.transform.position = left_3dchar.position;
            this.transform.rotation = left_3dchar.localRotation;

            //this.transform.position += new Vector3(0, 0, 2.0f);
            this.transform.position += new Vector3(0, 0, z_offset_puppet );

        }

    }
}
