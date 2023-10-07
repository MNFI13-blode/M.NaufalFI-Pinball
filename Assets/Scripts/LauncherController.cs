using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public Collider Ball;
    public Color color;
    public KeyCode input;
    private Renderer render;
    public float maxTimeHold;
    public float maxforce;
    private bool isHold;
    private void Start()
    {
        render = GetComponent<Renderer>();
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider == Ball)
        {
            ReadInput(Ball);
        }
    }
    private void ReadInput(Collider collider)
    {
        if (Input.GetKey(input) && !isHold)
        {
            StartCoroutine(StartingHold(collider));
        }
    }
    private IEnumerator StartingHold(Collider collider)
    {
        isHold = true;
        float force = 0.0f;
        float timehold = 0.0f;
        while (Input.GetKey(input))
        {
            render.material.color = color;
            force = Mathf.Lerp(0, maxforce, timehold/maxTimeHold);
            yield return new WaitForEndOfFrame();
            timehold += Time.deltaTime;
        }
        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * maxforce);
        isHold = false;
    }
}
