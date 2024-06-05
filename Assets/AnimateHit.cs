using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateHit : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;
    [SerializeField] 
    private GameObject bow; 
    [SerializeField] 
    private Bow bowrot; 
    // Start is called before the first frame update
    public void Acticate()
    {
        bow.SetActive(true);
    }

    // Update is called once per frame
    public void Deactivate()
    {
        bow.SetActive(false);
    }

    void Update()
    {
        if(transform.position.x > (playerTransform.position.x+20)){
            transform.localScale = new Vector3(1,1,1);
            bowrot.Rotate(180f);
        }
        else if(transform.position.x < (playerTransform.position.x-20)){
            transform.localScale = new Vector3(-1,1,1);
            bowrot.Rotate(0f);
        }
    }

}
