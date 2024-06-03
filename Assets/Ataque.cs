using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    public PlayerAtaque pAtaque;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Enemy"){
            collision.GetComponent<Health>().TakeDamage(0.5f);
            pAtaque.attacking = false;
        }
    }
    void FixedUpdate()
    {
        pAtaque.attacking = false;
    }

}
