using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Timeline;

namespace Scripts.Exercises
{
    public class TopDown : MonoBehaviour
    {
        SpriteRenderer[] spriteRenderers;

        void Awake()
        {
            spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
            if (spriteRenderers.Length < 1) throw new System.Exception("ERROR: no spriteRenderer to orden");
            foreach(var spriteRenderer in spriteRenderers)
            {
                spriteRenderer.sortingOrder = Mathf.RoundToInt(-10 * spriteRenderer.transform.position.y);
            }
        }
    }
}
