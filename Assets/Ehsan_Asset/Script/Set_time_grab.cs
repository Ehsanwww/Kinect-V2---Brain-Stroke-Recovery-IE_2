using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Set_time_grab : MonoBehaviour
{
    //when Ball is selected with mouse, we want that input_field which appears, show value of Time_handStay
    // in Input_Field.

    private Ball my_ball; //in order to have Time_handStay of ball.

    [HideInInspector]
    public TMP_InputField input_time_grab; //show value of Time_handStay in input_Field.


    // Start is called before the first frame update
    void Start()
    {
        my_ball =GetComponentInParent<Ball>(); //Get Component ball which is parent of object which this script assigned.
        input_time_grab = GetComponent<TMP_InputField>(); //Get component input_field Ball.

        input_time_grab.text = my_ball.Time_handStay.ToString();  //get value of Time_handStay and put it in input_field.

        // input_time_grab.onValueChanged.AddListener(check_value_input);
    }

    //public void check_value_input(string my_text)
    //{
    //    float value = float.Parse(my_text);
    //    Debug.Log("check input!!!!!!!!!!!! " + my_text);
    //}



}
