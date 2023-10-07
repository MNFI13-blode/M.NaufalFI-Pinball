using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    private Vector3 defaultPosition;
    public float returnTime;
    public float followSpeed;
    public float length;
    public Transform target;
    public bool hasTarget { get { return target != null; } }

    private void Start()
    {
        defaultPosition = transform.position;
        target = null;
    }
    private void Update()
    {
        if(hasTarget)
        {
            Vector3 targetToCameraDirection = transform.rotation * -Vector3.forward;
            Vector3 targetPosition = target.position + (targetToCameraDirection * length);
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
    public void FollowTarget(Transform targetTransform, float targetlength)
    {
        StopAllCoroutines();
        target = targetTransform;
        length = targetlength;
    }
    public void GobackToDefault()
    {
        target = null;

        //gerakan ke posisi tertentu dalam waktu return time
        StopAllCoroutines();
        StartCoroutine(movePosition(defaultPosition, returnTime));
    }
    private IEnumerator movePosition(Vector3 targett, float time) 
    {
        float timer = 0;
        Vector3 start = transform.position;

        while (timer < time)
        {
            //pindahkan posisi kamera bertahap
            transform.position = Vector3.Lerp(start, targett, Mathf.SmoothStep(0.0f,1.0f,timer/time));
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        } 
        transform.position = targett;
    }
}
