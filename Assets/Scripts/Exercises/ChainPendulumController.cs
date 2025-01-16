using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumController : MonoBehaviour
{
    [SerializeField] GameObject[] chains;
    // Start is called before the first frame update

    int timeTop = 500;
    int time = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time++;
        if (time > timeTop)
        {
            time = 0;
            if (timeTop == 500) timeTop = 1000;         
            foreach (GameObject chain in chains)
            {
                JointMotor2D jm2D = chain.GetComponent<HingeJoint2D>().motor;
                jm2D.motorSpeed *= (-1); 
                chain.GetComponent<HingeJoint2D>().motor = jm2D;
            }
        }   
    }
}
