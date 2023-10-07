using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerGameOver : MonoBehaviour
{
    public Collider Bola;
    public GameObject GameOverCanvas;
    private void OnTriggerEnter(Collider other)
    {
        if (other == Bola)
        {
            GameOverCanvas.SetActive(true);
        }
    }
}
