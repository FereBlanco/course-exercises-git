using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Components07 : MonoBehaviour
{
    [SerializeField] GameObject go1;
    [SerializeField] GameObject go2;
    void Awake()
    {
        if (go1 == null || go2 == null) throw new System.Exception("ERROR: Invalid objects!!!");

        Vector3 p = go1.transform.position;
        go1.transform.position = go2.transform.position;
        go2.transform.position = p;

        go1.transform.SetParent(go2.transform);
    }
}
