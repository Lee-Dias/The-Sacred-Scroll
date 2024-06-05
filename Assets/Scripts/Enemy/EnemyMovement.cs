using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private float chaseDistance;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float XScale = 1;
    [SerializeField]
    private float YScale = 1;

    private bool isChasing;
    private Animator anim;

    private void Awake(){
        anim = GetComponent<Animator>();
    }
    
    void Update(){
        Vector3 localScale = transform.localScale;
        if(isChasing){
            if(Vector2.Distance(transform.position, playerTransform.position) > chaseDistance){
                isChasing = false;
                anim.SetBool("moving",false);
            }
            if(transform.position.x > (playerTransform.position.x+20)){
                transform.localScale = new Vector3(XScale,YScale,1);
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }
            else if(transform.position.x < (playerTransform.position.x-20)){
                transform.localScale = new Vector3(-XScale,YScale,1);
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }else{
                anim.SetBool("moving",false);
            }
        }else{
            if(Vector2.Distance(transform.position, playerTransform.position) < chaseDistance){
                isChasing = true;
                anim.SetBool("moving",true);
            }

            
        }
    }
}
