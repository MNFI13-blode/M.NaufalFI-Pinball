using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider Bola;
    public float multiplier;
    public Color color;
    private Renderer render;
    private Animator animator;
    public AudioManager audioManager;   
    public VFXAudioManager audioManagerInstance;
    public ScoreManager scoreManager;
    public float score;
    private void Start()
    {
        render = GetComponent<Renderer>();
        animator = GetComponent<Animator>();
        render.material.color = color;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == Bola)
        {
            Rigidbody bolarig = Bola.GetComponent<Rigidbody>();
            bolarig.velocity *= multiplier;

            animator.SetTrigger("Hit");

            audioManager.playSFX(collision.transform.position);

            audioManagerInstance.playVFX(collision.transform.position);

            scoreManager.AddScore(score);
        }
    }
}
