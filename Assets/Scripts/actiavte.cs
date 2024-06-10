using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actiavte : MonoBehaviour
{
    [SerializeField] private GameObject[] childs;
    [SerializeField] private float timeInArena;
    private float time; 
    private bool active = false;
    private Key player;
    private SpriteRenderer spriteRend;

    private void Start(){
        GameObject playerObject = GameObject.FindWithTag("Player");
        player = playerObject.GetComponent<Key>();
        time = 0;
        spriteRend = GetComponent<SpriteRenderer>();
    }

    void Update(){
        if(active == false){
            time = 0;
        }else{
            time += Time.deltaTime;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision){
        player.aumentarcahves();
        if(collision.tag == "Player"){
            spriteRend.color = new Color(1,1,1, 0f);
            active = true;
            for(int i = 0; i < childs.Length; i++){
                childs[i].SetActive(true);
            }
            
        }
        if (time >= timeInArena){
            
            for(int i = 0; i < childs.Length; i++){
                childs[i].SetActive(false);
            }
            gameObject.SetActive(false);
            active = false;
        }
    }
}
