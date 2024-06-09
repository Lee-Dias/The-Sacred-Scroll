using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Count : MonoBehaviour
{
    [SerializeField]
    private TMP_Text pontuacao;
    [SerializeField]
    private Pontuacao pon;
    void Update()
    {
        this.pontuacao.text =  $"Points: {pon.currentPoints.ToString()}";
    }
}
