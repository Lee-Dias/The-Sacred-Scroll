using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Win : MonoBehaviour
{
    [SerializeField]
    private AudioSource src;
    [SerializeField]
    private AudioClip win;
    // Start is called before the first frame update
    public void goToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    void Update(){
        src.PlayOneShot(win);
        Time.timeScale = 0f;
    }

}
