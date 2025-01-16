using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Components08 : MonoBehaviour
{
    [SerializeField] GameObject go1;
    [SerializeField] GameObject go2;
    void Awake()
    {
        if (go1 == null || go2 == null) throw new System.Exception("ERROR: Invalid objects!!!");

        SpriteRenderer sr1 = go1.GetComponent<SpriteRenderer>();
        SpriteRenderer sr2 = go2.GetComponent<SpriteRenderer>();
        if (sr1 == null || sr2 == null) throw new System.Exception("ERROR: Onjecto with NO SpriteRenderer!!!");

        int orderTemp = sr1.sortingOrder;
        sr1.sortingOrder = sr2.sortingOrder;
        sr2.sortingOrder = orderTemp;
    }
}
