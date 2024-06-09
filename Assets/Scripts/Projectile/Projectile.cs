using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private Pontuacao points;
    private float lifetime;
    [SerializeField] private float lifetimeMax = 5;


    private void Awake(){
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        GameObject playerObject = GameObject.FindWithTag("Player");
        points = playerObject.GetComponent<Pontuacao>();


    }

    private void Update(){
        if(hit)return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed,0,0); 

        lifetime += Time.deltaTime;
        if(lifetime >= lifetimeMax) {
            lifetime = 0;
            gameObject.SetActive(false);
            
        }
            
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player"){
            return;
        }
        
        if (collision.tag == "Enemy"){
            collision.GetComponent<Health>().TakeDamage(1f);
            points.GainPoints(12.5f);
        }else{
            hit = true;
            boxCollider.enabled = false;
            anim.SetTrigger("explode");
        }
    }
    public void SetDirection(float _direction){
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true; 

        float localScaleX = transform.localScale.x;
        if(Mathf.Sign(localScaleX) != _direction){
            localScaleX = -localScaleX;
        }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate(){
        gameObject.SetActive(false);
    }
}
