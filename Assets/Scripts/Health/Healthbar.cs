using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private UnityEngine.UI.Image currentHealthBar;

    void Start()
    {
        
    }


    void Update()
    {
        currentHealthBar.fillAmount = playerHealth.currentHealth / 6;
    }
}
