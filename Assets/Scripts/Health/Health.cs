using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;

    [Header ("IFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    private PlayerMovement playerMovement;
    private Pontuacao points;

    [Header ("Components")]
    [SerializeField] private Behaviour[] components;

    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        points = playerObject.GetComponent<Pontuacao>();
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    public void TakeDamage(float _damage)
    {
        
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0){
            if(GetComponent<PlayerMovement>() !=null){
                playerMovement.changeSpeed(1f);
            }
            
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
        }
        else
        {
            if (!dead){
                points.GainPoints(50);
                //Player
                if(GetComponent<PlayerMovement>() !=null){
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                //Enemy
                StartCoroutine(dieflashes());;
            }
            
        }
        
    }
    private IEnumerator dieflashes(){
        anim.SetTrigger("die");
        foreach(Behaviour component in components){
            component.enabled = false;
        }
        for (int i = 0; i < 3; i++) {
            spriteRend.color = new Color(1,1,1, 0.5f);
            yield return new WaitForSeconds(0.1f);
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(0.1f);
        } 
        die();
    }
    public void die(){
        foreach(Behaviour component in components){
            gameObject.SetActive(false);
            component.enabled = false;
        }
        dead = true;
    }
    public void AddHealth(float _value){
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth); 
    }
    private void Update(){
    }

    private IEnumerator Invunerability(){
        //ficar invulneravel contra enemies
        Physics2D.IgnoreLayerCollision(7,8,true);
        for (int i = 0; i < numberOfFlashes; i++) {
            spriteRend.color = new Color(1,1,1, 0.5f);
            yield return new WaitForSeconds(iFramesDuration/(numberOfFlashes*2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration/(numberOfFlashes*2));
        } 
        Physics2D.IgnoreLayerCollision(7,8,false);
    }

}
