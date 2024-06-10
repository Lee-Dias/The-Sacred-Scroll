using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAudio : MonoBehaviour
{
    [SerializeField]
    private AudioSource src;
    [SerializeField]
    private AudioClip Music;
    // Start is called before the first frame update
    void Start()
    {
        src.loop=true;
        src.clip=Music;
        src.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
