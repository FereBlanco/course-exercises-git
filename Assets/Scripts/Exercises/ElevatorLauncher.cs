using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorLauncher : MonoBehaviour
{
    [SerializeField] GameObject elevator;
    [SerializeField] GameObject movingObject;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == movingObject.name)
        {
            elevator.GetComponent<SliderDynamicController>().ChangeSpeed(3);
        }
    }

}
