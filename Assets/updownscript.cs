using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updownscript : MonoBehaviour
{
    [SerializeField]
    private Transform ButtonPosition1;
    [SerializeField]
    private Transform ButtonPosition2;
    void Start()
    {
        transform.position = ButtonPosition1.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.DownArrow)){
            Change1();
        }

        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
            Change2();
        }
    }
    void Change1(){
            transform.position = ButtonPosition1.position;     
    }
    void Change2(){
            transform.position = ButtonPosition2.position;     
    }
}
