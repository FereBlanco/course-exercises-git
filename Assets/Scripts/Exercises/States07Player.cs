using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class States07Player : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        transform.parent.GetComponent<States07>().ManageCollision(other);
    }
}
