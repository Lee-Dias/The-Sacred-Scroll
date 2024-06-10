using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updownscript : MonoBehaviour
{
    [SerializeField]
    private Transform ButtonPosition1;
    [SerializeField]
    private Transform ButtonPosition2;
    [SerializeField]
    private MainMenu men;
    void Start()
    {
        transform.position = ButtonPosition1.position;
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K)) && transform.position == ButtonPosition1.position){
            men.PlayGame();
        }
        if((Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K)) && transform.position == ButtonPosition2.position){
            men.QuitGame();
        }
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
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
