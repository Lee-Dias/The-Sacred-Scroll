using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseFunction : MonoBehaviour
{
    [SerializeField]
    private PauseMenu pauseMenu;
    [SerializeField]
    private AudioSource src;
    [SerializeField]
    private AudioClip button;
    public void PlayGame(){
        src.PlayOneShot(button);
        pauseMenu.ResumeGame();
    }
    public void QuitGame(){
        src.PlayOneShot(button);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
