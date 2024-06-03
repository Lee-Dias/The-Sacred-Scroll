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

    [Header ("Components")]
    [SerializeField] private Behaviour[] components;

    void Start()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0){
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
        }
        else
        {
            if (!dead){
                //Player
                if(GetComponent<PlayerMovement>() !=null){
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                //Enemy

                foreach(Behaviour component in components){
                    component.enabled = false;
                    Die();
                    spriteRend.color = new Color(0,0,0, 0f);
                }
                  
                dead = true;
            }
            
        }
        
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.E)){
            TakeDamage(1);
        }
    }
    public void AddHealth(float _value){
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth); 
    }

    private IEnumerator Invunerability(){
        //ficar invulneravel contra enemies
        Physics2D.IgnoreLayerCollision(7,8,true);
        for (int i = 0; i < numberOfFlashes; i++) {
            spriteRend.color = new Color(1,0,0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration/(numberOfFlashes*2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration/(numberOfFlashes*2));
        } 
        Physics2D.IgnoreLayerCollision(7,8,false);
    }

    private IEnumerator Die(){
        //ficar invulneravel contra enemies
        Physics2D.IgnoreLayerCollision(7,8,true);
        for (int i = 0; i < 2; i++) {
            spriteRend.color = new Color(1,0,0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration/(numberOfFlashes*2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration/(numberOfFlashes*2));
        } 
        Physics2D.IgnoreLayerCollision(7,8,false);
    }
}
