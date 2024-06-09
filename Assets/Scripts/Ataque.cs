using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    public PlayerAtaque pAtaque;
    [SerializeField]
    private Chi chi;
    private Pontuacao points;
    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject playerObject = GameObject.FindWithTag("Player");
        points = playerObject.GetComponent<Pontuacao>();
        if (collision.tag == "Enemy"){
            collision.GetComponent<Health>().TakeDamage(0.5f);           
            if (pAtaque.ComboNumber == 4){
                chi.GainChi(1f);
                points.GainPoints(50);
                pAtaque.ComboNumber = 0;
            }
            pAtaque.attacking = false;
            points.GainPoints(5);
            this.gameObject.SetActive(false);
        }
    }
    void FixedUpdate()
    {
        pAtaque.attacking = false;
    }

}
