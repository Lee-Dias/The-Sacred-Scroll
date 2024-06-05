using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform player;
    
    void Update()
    {
        transform.position  = new Vector3(player.position.x, player.position.y+10, transform.position.z);
        
    }
}