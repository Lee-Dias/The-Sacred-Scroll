using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    public PlayerAtaque pAtaque;
    [SerializeField]
    private Chi chi;
    [SerializeField]
    private Pontuacao points;
        [SerializeField]
    private AudioSource src;
    [SerializeField]
    private AudioClip hit;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Enemy"){
            collision.GetComponent<Health>().TakeDamage(0.5f);     
            src.PlayOneShot(hit);      
            if (pAtaque.ComboNumber == 4){
                chi.GainChi(0.5f);
                points.GainPoints(25);
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
