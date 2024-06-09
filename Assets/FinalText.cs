using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinalText : MonoBehaviour
{
    [SerializeField]
    private TMP_Text pontuacao;
    [SerializeField]
    private Pontuacao pon;
    void Update()
    {
        this.pontuacao.text =  $"{pon.currentPoints.ToString()}";
    } 
}
