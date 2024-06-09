using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    
    public int currentKeyCount { get; private set; }

    private void Awake(){
        currentKeyCount = 0;
    }

    public void aumentarcahves(){
        currentKeyCount +=1;
    }
}
