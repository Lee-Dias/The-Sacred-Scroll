using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiBallAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown; 
    [SerializeField] private Transform ChiPoint; 
    [SerializeField] private GameObject[] ChiBalls; 
    
    private Animator anim;
    private PlayerMovement playerMovement;

    private Chi chi;
    private float cooldownTimer = Mathf.Infinity;

    [SerializeField]
    private AudioSource src;
    [SerializeField]
    private AudioClip bola;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        chi = GetComponent<Chi>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && cooldownTimer > attackCooldown && playerMovement.CanAttack() && chi.currentChi >1){
            playerMovement.changeSpeed(4f);
            chi.LoseChi(2);
            anim.SetTrigger("attack");
            src.PlayOneShot(bola);
            cooldownTimer = 0;
        }

        cooldownTimer += Time.deltaTime;
    }
    private void Attack()
    {
        
        playerMovement.changeSpeed(1f);
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
