using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform bulletPos;
    [SerializeField]   
    private float ShootTime = 3f; 
    [SerializeField]   
    private float distanceToShoot = 150f; 

    private float timer = 0;    

    private GameObject player;
    private Animator anim;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        

        float Distance = Vector2.Distance(transform.position, player.transform.position);

        if (Distance < distanceToShoot){
            timer += Time.deltaTime;
            if (timer > ShootTime){
                anim.SetTrigger("shoot");
                timer = 0;
            }
        }else{
            timer = 0;
        }
    }
    private void Shoot(){
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
