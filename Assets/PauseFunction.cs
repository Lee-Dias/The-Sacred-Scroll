using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseFunction : MonoBehaviour
{
    [SerializeField]
    private PauseMenu pauseMenu;
    public void PlayGame(){
        pauseMenu.ResumeGame();
    }
    public void QuitGame(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
