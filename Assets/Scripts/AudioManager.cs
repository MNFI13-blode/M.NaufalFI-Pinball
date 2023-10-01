using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgmAudio;
    public GameObject sfxaudio;

    private void Start()
    {
        
    }
    private void playBGM()
    {
        bgmAudio.Play();
    }
    public void playSFX(Vector3 Spawnposition)
    {
        GameObject.Instantiate(sfxaudio, Spawnposition, Quaternion.identity);
    }
}
