using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public KeyCode input;
    private float Targetpressed;
    private float Targetreleased;
    private HingeJoint hinge;
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        Targetreleased = hinge.limits.min;
        Targetpressed = hinge.limits.max;
    }

    void Update()
    {
        ReadInput();
    }
    private void ReadInput()
    {
        JointSpring jointSpring = hinge.spring;
        if (Input.GetKey(input))
        {
            jointSpring.targetPosition = Targetpressed;
        }
        else
        {
            jointSpring.targetPosition = Targetreleased;
        }
        hinge.spring = jointSpring;
    }
}
