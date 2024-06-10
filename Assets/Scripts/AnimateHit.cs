using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateHit : MonoBehaviour
{

    [SerializeField] 
    private GameObject bow; 
    [SerializeField] 
    private Bow bowrot; 
    private Transform player;
    public void Acticate()
    {
        bow.SetActive(true);
    }

    // Update is called once per frame
    public void Deactivate()
    {
        bow.SetActive(false);
    }

    void Start(){
        GameObject playerObject = GameObject.FindWithTag("Player");
        player = playerObject.GetComponent<Transform>();
    }

    void Update()
    {
        if(transform.position.x > (player.position.x+20)){
            transform.localScale = new Vector3(1,1,1);
            bowrot.Rotate(180f);
        }
        else if(transform.position.x < (player.position.x-20)){
            transform.localScale = new Vector3(-1,1,1);
            bowrot.Rotate(0f);
        }
    }

}
