using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bow : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private Transform turretRotationPoint;
    [SerializeField] private LayerMask playerMask;

    [Header("Attribute")]
    [SerializeField] private float targetingRange = 5f;
    [SerializeField] private float rotationSpeed = 5f;

    public float rot = 180;
    private Transform target;

    private void Update(){
        if (target == null){
            FindTarget();
            return;
        }

        RotateTowardTarget();

        if (!CheckTargetIsInRange()){
            target = null;
            turretRotationPoint.rotation = Quaternion.Euler(new Vector3(0f,0f,90f));
        }
    }

    private void FindTarget(){

        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position,targetingRange,(Vector2) transform.position, 0f, playerMask);

        if(hits.Length>0){
            target = hits[0].transform;
        }
    }

    private bool CheckTargetIsInRange(){
        return Vector2.Distance(target.position,transform.position) <= targetingRange;
    }

    private void RotateTowardTarget(){
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg + rot;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f,0f,angle));
        turretRotationPoint.rotation = Quaternion.RotateTowards(turretRotationPoint.rotation,
        targetRotation,rotationSpeed * Time.deltaTime);
    }

    public void Rotate(float ol) {
        rot = ol;
    }
}
