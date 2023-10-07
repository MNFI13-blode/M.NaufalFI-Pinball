using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private enum SwitchState
    {
        Off,
        On,
        Blink
    }
    public Collider Bola;
    public Material off;
    public Material on;
    public float score;
    private SwitchState state;
    private Renderer render;
    public ScoreManager scoreManager;
    private void Start()
    {
        render = GetComponent<Renderer>();
        Set(false);
        StartCoroutine(BlinkTimerStart(5));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == Bola)
        {
            toogle();
        }
    }
    private void Set(bool active)
    {
        if (active == true)
        {
            state = SwitchState.On;
            render.material = on;
            StopAllCoroutines();
        }else if (active == false)
        {
            state = SwitchState.Off;
            render.material = off;
            StartCoroutine(BlinkTimerStart(5));
        }
    }
    private void toogle()
    {
        if (state == SwitchState.On)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }
        scoreManager.AddScore(score);
    }
    private IEnumerator Blink(int times)
    {
        state = SwitchState.Blink;
        for (int i = 0; i < times;i++)
        {
            render.material = on;
            yield return new WaitForSeconds(0.5f);
            render.material = off;
            yield return new WaitForSeconds(0.5f);
        }
        state = SwitchState.Off;
        StartCoroutine(BlinkTimerStart(5));
    }
    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
}
