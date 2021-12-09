using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_11_12_1 : MonoBehaviour
{
    public Transform right_puppet;
    public Transform left_puppet;


    //public BoxCollider my_box_collider; 
    //public BoxCollider Exit;

    private hand_event my_hand;

    // Start is called before the first frame update
    //void Start()
    //{

    //}

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Right")
        {
            my_hand = collision.gameObject.GetComponent<hand_event>();

        }
        else if (collision.gameObject.tag == "Left")
        {

        }
        
    }




}
