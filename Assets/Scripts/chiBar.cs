using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chiBar : MonoBehaviour
{
    [SerializeField] private Chi playerChi;
    [SerializeField] private UnityEngine.UI.Image ChiBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChiBar.fillAmount = playerChi.currentChi / 3;
    }
}
