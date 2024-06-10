using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chi : MonoBehaviour
{
    [Header ("Chi")]
    [SerializeField] private float startingChi;

    public float currentChi { get; private set; }

    void Start()
    {
        currentChi = startingChi;
    }
    public void LoseChi(float _chiLose)
    {
        if (currentChi > 0){
            currentChi= Mathf.Clamp(currentChi- _chiLose, 0, startingChi);
        }
    }

    public void GainChi(float _chiLose)
    {
        currentChi = Mathf.Clamp(currentChi + _chiLose, 0, startingChi); 
    }
}
