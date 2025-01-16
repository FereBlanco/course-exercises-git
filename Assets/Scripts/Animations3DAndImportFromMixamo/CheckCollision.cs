using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;

public class CheckCollision : MonoBehaviour
{
    [SerializeField] GameObject ragdollPrefab;

    void Awake()
    {
        Assert.IsNotNull(ragdollPrefab, "ERROR: ragdoll gameobject is empty");
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Death")
        {
            Debug.Log("YOU ARE DEAD!!!");
            GameObject ragdoll = Instantiate(ragdollPrefab, transform.position, transform.rotation);
            ragdoll.name = transform.gameObject.name + "_Ragdoll";

            // First of all we deactivate the new ragdoll
            ragdoll.SetActive(false);

            // Update all bones position and rotations 
            Transform ragdollCurrent = ragdoll.transform;
            Transform current = transform;
            bool first = true;

            while (current != null && ragdollCurrent != null)
            {
                if (first || ragdollCurrent.name == current.name) // Becoise the firt GameObject could has a differente name (first)
                {
                    ragdollCurrent.rotation = current.rotation;
                    ragdollCurrent.position = current.position;
                    first = false;
                }

                if (current.childCount > 0)
                {
                    // Get first child
                    current = current.GetChild(0);
                    ragdollCurrent = ragdollCurrent.GetChild(0);
                }
                else
                {
                    while (current != null)
                    {
                        if (current.parent == null || ragdollCurrent.parent == null)
                        {
                            // No more transforms to find
                            current = null;
                            ragdollCurrent = null;
                        }
                        else
                        {
                            if (current.GetSiblingIndex() == current.parent.childCount - 1 ||
                                current.GetSiblingIndex() + 1 >= ragdollCurrent.parent.childCount)
                            {
                                // Need to go up one level
                                current = current.parent;
                                ragdollCurrent = ragdollCurrent.parent;
                            }
                            else
                            {
                                // Found next sibling for next iteration
                                current = current.parent.GetChild(current.GetSiblingIndex() + 1);
                                ragdollCurrent = ragdollCurrent.parent.GetChild(ragdollCurrent.GetSiblingIndex() + 1);
                                break;
                            }
                        }
                    }

                }
            }

            // Finally we activate the ragdoll again
            transform.gameObject.SetActive(false);
            ragdoll.SetActive(true);
        }

    }
}
