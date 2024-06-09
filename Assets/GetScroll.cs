using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetScroll : MonoBehaviour
{
    [SerializeField]
    private GameObject scroll;
    
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Player"){
            scroll.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
