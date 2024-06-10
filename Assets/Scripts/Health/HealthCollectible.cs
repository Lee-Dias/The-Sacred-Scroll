using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField] private float healthvalue;
    private GameObject source;
    private AudioSource src;
    [SerializeField]
    private AudioClip heal;
    private void Start(){
        source = GameObject.FindGameObjectWithTag("Source");
        src = source.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Player"){
            src.PlayOneShot(heal);
            collision.GetComponent<Health>().AddHealth(healthvalue);
            gameObject.SetActive(false);
        }
    }
}
