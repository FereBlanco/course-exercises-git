using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderDynamicController : MonoBehaviour
{
    int timeTop = 400;
    int time = 0;

    JointMotor2D jm2D;
    float speed = 0f;

    void Start()
    {
        jm2D = gameObject.GetComponent<SliderJoint2D>().motor;
        speed = jm2D.motorSpeed;
    }

    void Update()
    {
        time++;
        if (time > timeTop)
        {
            time = 0;
            speed *= (-1);
            jm2D.motorSpeed = speed; 
            gameObject.GetComponent<SliderJoint2D>().motor = jm2D;
        }   
    }

    public void ChangeSpeed(float newSpeed)
    {
        speed = newSpeed;
        jm2D.motorSpeed = speed; 
        gameObject.GetComponent<SliderJoint2D>().motor = jm2D;
    }
}
