using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAtaque : MonoBehaviour
{
   
    [SerializeField] private float attackCooldown; 
    public static PlayerAtaque instance;
    public bool CanRecieveInput = true;
    public int ComboNumber = 0;
    public bool InputRecieved = false;
    private Animator anim;
    private PlayerMovement playerMovement;
    private GameObject attack;
    public bool attacking = false;
    private float cooldownTimer = Mathf.Infinity;
    private Chi chi;
    private Pontuacao points;


    // Update is called once per frame
    private void Awake()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        points = playerObject.GetComponent<Pontuacao>();
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        chi = GetComponent<Chi>();
        attack = transform.GetChild(2).gameObject;
        instance = this;
    }
    void Update()
    {
        cooldownTimer += Time.deltaTime;
        attack.SetActive(attacking);
        if (Input.GetKeyDown(KeyCode.J) && cooldownTimer > attackCooldown && playerMovement.CanAttack() && CanRecieveInput){
            InputRecieved = true;
        }
    }

    private void MeleeHit(){
        attacking = true;
        attack.SetActive(attacking);
    }
    public void InputManager(){
        if (!CanRecieveInput) {
            CanRecieveInput = true;
        }else{
            CanRecieveInput = false;
        }
    }
}
