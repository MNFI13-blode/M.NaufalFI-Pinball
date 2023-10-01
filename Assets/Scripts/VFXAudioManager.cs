using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXAudioManager : MonoBehaviour
{
    public GameObject sfxAudioSource;

    // Update is called once per frame
    public void playVFX(Vector3 spawnPosition)
    {
        GameObject.Instantiate(sfxAudioSource, spawnPosition, Quaternion.identity);
    }
}
