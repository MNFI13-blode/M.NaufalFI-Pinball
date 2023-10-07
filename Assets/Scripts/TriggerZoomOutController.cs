using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoomOutController : MonoBehaviour
{
    public Collider Bola;
    public CameraController CameraController;
    private void OnTriggerEnter(Collider other)
    {
        if (other == Bola)
        {
            CameraController.GobackToDefault();
        }
    }
}
