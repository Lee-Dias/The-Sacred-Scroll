using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pontuacao : MonoBehaviour
{
    public float currentPoints { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        currentPoints = 0;
    }
    
    public void GainPoints(float gain){
        currentPoints += gain;
    }
}
