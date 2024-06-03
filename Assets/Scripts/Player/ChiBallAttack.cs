using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ChiBallAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown; 
    [SerializeField] private Transform ChiPoint; 
    [SerializeField] private GameObject[] ChiBalls; 
    
    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.CanAttack()){
            anim.SetTrigger("attack");
            cooldownTimer = 0;
        }

        cooldownTimer += Time.deltaTime;
    }
    private void playAnimation(){
        anim.SetTrigger("attack");
        cooldownTimer = 0;
    }
    private void Attack()
    {
        
        

        ChiBalls[FindChiBall()].transform.position = ChiPoint.position;
        ChiBalls[FindChiBall()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));

    }

    private int FindChiBall(){
        for (int i = 0;i<ChiBalls.Length; i++){
            if (!ChiBalls[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
