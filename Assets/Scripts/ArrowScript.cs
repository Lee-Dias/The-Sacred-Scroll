using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    [SerializeField]
    private float force;
    [SerializeField]
    private float timeUntilDissapear;

    private float timer;
    private GameObject player;
    private GameObject source;
    private Rigidbody2D rb;
    private AudioSource src;
    [SerializeField]
    private AudioClip Release,hitFloor,hitPlayer;


    private BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        source = GameObject.FindGameObjectWithTag("Source");
        src = source.GetComponent<AudioSource>();
        src.PlayOneShot(Release);
        rb =GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");



        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player"){
            src.PlayOneShot(hitPlayer);
            collision.GetComponent<Health>().TakeDamage(0.5f);
            Destroy(gameObject);
        }else{
            src.PlayOneShot(hitFloor);
            Destroy(gameObject);
        }
    }

    void Update(){
        timer += Time.deltaTime;
        if(timer > timeUntilDissapear){
            Destroy(gameObject);
        }
    }

}
