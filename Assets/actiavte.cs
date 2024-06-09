using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actiavte : MonoBehaviour
{
    [SerializeField] private GameObject[] childs;
    [SerializeField] private float timeInArena;
    private bool active = false;
    private SpriteRenderer spriteRend;
    private Key player;

    private void Awake(){
        GameObject playerObject = GameObject.FindWithTag("Player");
        player = playerObject.GetComponent<Key>();
    }




    private void OnTriggerEnter2D(Collider2D collision){
        player.aumentarcahves();
        spriteRend = GetComponent<SpriteRenderer>();
        if(collision.tag == "Player"){
            spriteRend.color = new Color(1,1,1, 0f);
            for(int i = 0; i < childs.Length; i++){
                childs[i].SetActive(true);
            }
            active = true;
        }
        if(active == true){
            timeInArena = Time.time;
        }
        if (timeInArena >= 15){
            for(int i = 0; i < childs.Length; i++){
                childs[i].SetActive(false);
            }
            gameObject.SetActive(false);
        }
    }
}
